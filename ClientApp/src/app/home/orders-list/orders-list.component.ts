import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html'
})
export class OrdersListComponent implements OnInit {
  public orders: Order[] = [];
  public orderDetail: OrderDetailDto | null = null; // New field to hold the detailed order

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    // Fetch the list of orders
    this.http.get<Order[]>(`${this.baseUrl}orders/getorders`).subscribe(result => {
      this.orders = result;
    }, error => console.error(error));

    // Fetch the detailed order with ID = 1
    this.http.get<OrderDetailDto>(`${this.baseUrl}orders/1`).subscribe(result => {
      this.orderDetail = result;
    }, error => console.error(error));
  }
}

interface Order {
  id: number;
  customerID: number;
  productID: number;
  totalCost: number;
  status: string;
  customerName: string;
  customerAddress: string;
  statusName: string;
}

interface OrderDetailDto {
  // Add your fields here, similar to those defined on the server-side
  orderNumber: number;
  orderDate: string;
  customerId: number;
  customerName: string;
  statusId: number;
  statusName: string;
  totalCost: number;
  products: ProductDetailDto[];
}

interface ProductDetailDto {
  // Add your fields here
  productId: number;
  productName: string;
  productCategoryId: number;
  productCategoryName: string;
  productSizeId: number;
  productSizeName: string;
  quantity: number;
  price: number;
  comment: string;
}

