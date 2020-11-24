import { Component, Inject, TemplateRef } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-User',
  templateUrl: './PricingMatrix.component.html'
})

export class PricingMatrix {
  public BaseUrl: string = 'http://localhost:61197/api/';
  public Detail: PricingMatrixList[]

  constructor(private httpClient: HttpClient) {

    let headers = new Headers();

    headers.append('Content-Type', 'application/json');
    headers.append('Accept', 'application/json');
    //headers.append('Origin', 'http://localhost:61197');

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    this.httpClient.post<PricingMatrixList[]>(this.BaseUrl + 'user/GetPricingMatrix',
      {
        "Local_Fk": "",
        "Region_fk": "1",
        "Language_fk": "",
        "mediatype": "",
        "POSTypeFilter": "",
        "SizeFilter": ""
      }, httpOptions)
      .subscribe(
        data => {
          //console.log("POST Request is successful ", data);
          this.Detail = data;
        },
        error => {
          console.log("Error", error);
        }
      );
  }
}


class PricingMatrixList {
  id: number;
  PriceMatrixName: string;
  Media_type: string;
  POS_Type: string;
  Size: string;
  Dim_Sval: string;
  Sno: string;
  language_fk: string;
  language: string;
  Matrial: string;
  PriceType: string;
}
