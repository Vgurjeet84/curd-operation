import { Component, NgModule } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-User',
  templateUrl: './Products.component.html'
})

export class ManageProducts {
  public ProductList : Products[];
  public BaseUrl: string = 'http://localhost:61197/api/';

  constructor(http: HttpClient) {
    http.get<Products[]>(this.BaseUrl + 'user/GetUsers').subscribe(result => {
      this.ProductList = result;
    }, error => console.error(error));
  }
}

 class Products {
  rebate_product_seq: number;
  product_code: string;
  product_name: string;
  brand_name: string;
}
