import { Component, Inject, ViewChild, ElementRef } from '@angular/core';
import { UserService } from './app.UserService';
import { HttpClient } from '@angular/common/http';
import { debug } from 'util';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { Http, Response, RequestOptions, Headers } from '@angular/http';


@Component({
  selector: 'app-User',
  templateUrl: './UserDetails.component.html',
  providers: [UserService]
})

export class UserDetails {
  public userdetail: UserDetailsList[]
  public user: UserDetailsList = new UserDetailsList();
  public BaseUrl: string = 'http://localhost:61197/api/';

  EditUserForm: any;
  AddUserForm: any;
  @ViewChild('closeBtn') closeBtn: ElementRef;

  constructor(private userService: UserService, private formbulider: FormBuilder) {
        this.EditUserForm = new FormGroup({
      Name: new FormControl(),
      Email: new FormControl(),
      Role: new FormControl()
        });

    this.AddUserForm = new FormGroup({
      Name: new FormControl(),
      Email: new FormControl(),
      Role: new FormControl()
    });
  }
  ngOnInit() {
    this.GetUsers();
  }

  public GetUsers() {    
    this.userService.GetUserList().subscribe(users => { this.userdetail = users }, error => console.error(error));
  }

  public EditUser(Id: number) {    
    var result = this.userdetail.filter(a => a.ID == Id)
    this.EditUserForm = this.formbulider.group({
      Name: result[0].Name,
      Email: result[0].Email,
      Role: result[0].Role,
      ID: result[0].ID
    });    
  }

  public updateUser() {            
    this.userService.UpdateUser(this.EditUserForm.value).subscribe(users => this.userdetail = users);
    this.closeBtn.nativeElement.click();
    this.GetUsers();
  }

  public AddNewUser() {
    
    this.userService.AddUser(this.AddUserForm.value).subscribe(users => this.userdetail = users);
    this.AddUserForm.reset();
    this.closeBtn.nativeElement.click();
    this.GetUsers();
  }

  public DeleteUser(Id: number) {
    this.EditUserForm.value.ID = Id;
    this.userService.Deleteemployee(this.EditUserForm.value).subscribe(users => this.userdetail = users);
    this.GetUsers();
  }

}

class UserDetailsList {
  ID: number;
  Name: string;
  Email: string;
  Status: string;
  Role: string
}
