using Microsoft.Data.Sqlite;
using System.Data.Common;
using WebApplicationAngularWebPortal.Services;

namespace WebApplicationAngularWebPortal;

public interface IDatabaseService
{
	void InitializeDatabase();
}

public sealed class DatabaseService : IDatabaseService, IDisposable
{
	private readonly SqliteConnection connection;

	public DatabaseService(string connectionString)
	{
		this.connection = new SqliteConnection(connectionString);
	}

	public void InitializeDatabase()
	{
		this.connection.Open();
		this.CreateTables();
		this.InitializeTables();
		CheckTablesContent();
		this.InsertOrders();
	}

	private void CheckTablesContent()
	{
		using (var transaction = connection.BeginTransaction())
		{
			try
			{
				CheckCustomers(transaction);

				transaction.Commit();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				transaction.Rollback();
			}
		}
	}

	private void CheckCustomers(SqliteTransaction transaction)
	{
		string selectQuery = "SELECT * FROM Customers";
		using (var command = new SqliteCommand(selectQuery, connection, transaction))
		{
			using (var reader = command.ExecuteReader())
			{
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						int id = reader.GetInt32(reader.GetOrdinal("ID"));
						DateTime createdDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
						string customerName = reader.GetString(reader.GetOrdinal("CustomerName"));
						string address = reader.IsDBNull(reader.GetOrdinal("Address"))
							? "N/A"
							: reader.GetString(reader.GetOrdinal("Address"));

						Console.WriteLine(
							$"ID: {id}, CreatedDate: {createdDate}, CustomerName: {customerName}, Address: {address}");
					}
				}
				else
				{
					Console.WriteLine("No rows found.");
				}
			}
		}
	}

	public void Dispose()
	{
		this.connection.Dispose();
	}

	private static void ExecuteScript(SqliteConnection connection, TextReader reader)
	{
		using var transaction = connection.BeginTransaction();

		try
		{
			int lineNumber = 1;
			string? line;

			while ((line = reader.ReadLine()) is not null)
			{
				lineNumber++;

				if (string.IsNullOrWhiteSpace(line))
				{
					continue;
				}

				try
				{
					using var command = new SqliteCommand(line, connection, transaction);
					var count = command.ExecuteNonQuery();
					Console.WriteLine(count);
				}
				catch (Exception e)
				{
					throw new SqlScriptException(
						$"Exception during executing an SQL command on line {lineNumber}: \"{line}\".", e);
				}
			}

			transaction.Commit();
		}
		catch (Exception)
		{
			transaction.Rollback();
			throw;
		}
	}

	private void CreateTables()
	{
		using var reader = new StringReader(SqlScripts.CreateTables);
		ExecuteScript(this.connection, reader);
	}

	private void InitializeTables()
	{
		using var reader = new StringReader(SqlScripts.InsertData);
		ExecuteScript(this.connection, reader);
	}

	private void InsertOrders()
	{
		using var reader = new StringReader(SqlScripts.InsertOrders);
		ExecuteScript(this.connection, reader);
	}
}

public class SqlScriptException : DbException
{
	public SqlScriptException()
	{
	}

	public SqlScriptException(string message)
		: base(message)
	{
	}

	public SqlScriptException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}