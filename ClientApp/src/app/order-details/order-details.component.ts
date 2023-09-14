import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

  public orderDetail: OrderDetailDto | null = null; // New field to hold the detailed order

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {

    // Fetch the detailed order with ID = 1
    this.http.get<OrderDetailDto>(`${this.baseUrl}orders/1`).subscribe(result => {
      this.orderDetail = result;
    }, error => console.error(error));
  }
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
