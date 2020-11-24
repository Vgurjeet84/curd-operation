import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/observable';
import { UserDetailsList } from './../app.module';

@Injectable()
export class UserService {

  employees: UserDetailsList[];
  constructor(private http: Http) {
  }
  public BaseUrl: string = 'http://localhost:61197/api/';
  GetUserList(): Observable<UserDetailsList[]> {
    return this.http.get(this.BaseUrl + 'user/GetUsers').map((res: Response) => res.json());
  }
  AddUser(user: UserDetailsList): Observable<UserDetailsList[]> {
    let data = JSON.stringify(user);
    let headers: Headers = new Headers({ "content-type": "application/json" });
    let options: RequestOptions = new RequestOptions({ headers: headers });
    return this.http.post(this.BaseUrl + 'user/AddNewUser', data, options).map((res: Response) => res.json());
  }
  UpdateUser(user: UserDetailsList): Observable<UserDetailsList[]> {
    let data = JSON.stringify(user);
    let headers: Headers = new Headers({ "content-type": "application/json" });
    let options: RequestOptions = new RequestOptions({ headers: headers });
    return this.http.post(this.BaseUrl + 'user/EditUser', data, options).map((res: Response) => res.json());
  }
  Deleteemployee(user: UserDetailsList): Observable<UserDetailsList[]> {
    let data = JSON.stringify(user);
    let headers: Headers = new Headers({ "content-type": "application/json" });
    let options: RequestOptions = new RequestOptions({ headers: headers });
    return this.http.post(this.BaseUrl + 'user/EditUser', data, options).map((res: Response) => res.json());
  }
}
