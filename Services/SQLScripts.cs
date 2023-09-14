namespace WebApplicationAngularWebPortal.Services;

public class SqlScripts
{
	public const string CreateTables =
		@"
CREATE TABLE Customers (ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,  CreatedDate DATETIME NOT NULL, CustomerName NVARCHAR(255) NOT NULL, Address NVARCHAR(500));

CREATE TABLE Products (ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,    ProductName NVARCHAR(255) NOT NULL,    Description NVARCHAR(500),    Category INT,    ProdiceSize INT,    Quantity INT,    Price DECIMAL(18, 2));

CREATE TABLE Orders (	ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,		CustomerID INT NOT NULL,	Comment NVARCHAR(500),	TotalCost DECIMAL(18, 2),	Status INT,		FOREIGN KEY (CustomerID) REFERENCES Customers(ID)		);
		
CREATE TABLE OrderDetails (		ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,		OrderID INT NOT NULL,	ProductID INT NOT NULL,		Quantity INT,	Comment NVARCHAR(500),	FOREIGN KEY (OrderID) REFERENCES Orders(ID),	FOREIGN KEY (ProductID) REFERENCES Products(ID)		);
";

	public const string InsertData =
		@"
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-01', 'Alice', '123 Main St',1);
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-02', 'Bob', '456 Park Ave',2);
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-03', 'Charlie', '789 Elm St',3);
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-04', 'Dave', '101 Maple St',4);
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-05', 'Eve', '202 Oak St',5);
INSERT INTO Customers (CreatedDate, CustomerName, Address, ID) VALUES ('2023-01-06', 'Frank', '303 Cedar St',6);

INSERT INTO Products (ProductName, Description, Category, ProdiceSize, Quantity, Price, ID) VALUES ('Apple', 'Fresh Apples', 0, 2, 100, 1.20,1);
INSERT INTO Products (ProductName, Description, Category, ProdiceSize, Quantity, Price, ID) VALUES ('Laptop', 'Gaming Laptop', 1, 3, 20, 1200.00,2);
INSERT INTO Products (ProductName, Description, Category, ProdiceSize, Quantity, Price, ID) VALUES ('Shirt', 'Cotton T-Shirt', 2, 1, 50, 20.00,3);
INSERT INTO Products (ProductName, Description, Category, ProdiceSize, Quantity, Price, ID) VALUES ('Table', 'Wooden Table', 3, 3, 10, 250.00,4);
INSERT INTO Products (ProductName, Description, Category, ProdiceSize, Quantity, Price, ID) VALUES ('Face Cream', 'Moisturizing Face Cream', 4, 1, 30, 35.00,5);
";

	public const string InsertOrders =
		@"
INSERT INTO Orders (ID, CustomerID, Comment, TotalCost, Status) VALUES (1, 1, 'First Order', 121.20, 1);
INSERT INTO Orders (ID, CustomerID, Comment, TotalCost, Status) VALUES (2, 2, 'Urgent', 1220.00, 2);
INSERT INTO Orders (ID, CustomerID, Comment, TotalCost, Status) VALUES (3, 3, 'No comment', 270.00, 3);
INSERT INTO Orders (ID, CustomerID, Comment, TotalCost, Status) VALUES (4, 4, 'ASAP', 1251.20, 4);
INSERT INTO Orders (ID, CustomerID, Comment, TotalCost, Status) VALUES (5, 5, 'Regular order', 56.20, 1);
INSERT INTO Orders (ID, CustomerID, Comment, TotalCost, Status) VALUES (6, 6, 'Holiday gifts', 270.00, 2);
INSERT INTO Orders (ID, CustomerID, Comment, TotalCost, Status) VALUES (7, 1, 'Second Order', 40.00, 3);

INSERT INTO OrderDetails (ID, OrderID, ProductID, Quantity, Comment) VALUES (1, 1, 1, 100, 'Need fresh ones');
INSERT INTO OrderDetails (ID, OrderID, ProductID, Quantity, Comment) VALUES (2, 2, 2, 1, 'Latest model');
INSERT INTO OrderDetails (ID, OrderID, ProductID, Quantity, Comment) VALUES (3, 3, 4, 1, 'Brown color');
INSERT INTO OrderDetails (ID, OrderID, ProductID, Quantity, Comment) VALUES (4, 3, 5, 1, 'For dry skin');
INSERT INTO OrderDetails (ID, OrderID, ProductID, Quantity, Comment) VALUES (5, 4, 1, 1, 'Organic only');
INSERT INTO OrderDetails (ID, OrderID, ProductID, Quantity, Comment) VALUES (6, 4, 4, 1, 'Any color');
INSERT INTO OrderDetails (ID, OrderID, ProductID, Quantity, Comment) VALUES (7, 5, 5, 1, 'Sensitive skin');
INSERT INTO OrderDetails (ID, OrderID, ProductID, Quantity, Comment) VALUES (8, 5, 3, 1, 'Size M');
INSERT INTO OrderDetails (ID, OrderID, ProductID, Quantity, Comment) VALUES (9, 6, 4, 1, 'Dark wood');
INSERT INTO OrderDetails (ID, OrderID, ProductID, Quantity, Comment) VALUES (10, 6, 5, 1, 'For oily skin');
INSERT INTO OrderDetails (ID, OrderID, ProductID, Quantity, Comment) VALUES (11, 7, 3, 2, 'Size L');

";
}