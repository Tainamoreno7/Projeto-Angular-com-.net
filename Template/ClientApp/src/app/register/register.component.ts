import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../_data-server/user.data.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  users: any[] = [];
  user: any = {};
  userlogin: any = {};
  userLogin: any = {};
  userLogged: any = {};
  showList: boolean = true;
  isAuthenticated: boolean = false;
  

  constructor(private userDataService: UserDataService) { }

  ngOnInit() {

  }
  get() {
    this.userDataService.get().subscribe((data: any[]) => {
      this.users = data;
      this.showList = true;
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }


  openDetails(user) {
    this.showList = false;
    this.user = user;
  }

  authenticate() {
    this.userDataService.authenticate(this.userLogin).subscribe((data: any) => {
      if (data.user) {
        debugger;
        localStorage.setItem('user_logged', JSON.stringify(data)); //convertendo as informações em String
        this.getUserData();
      } else {
        alert('Cliente não cadastrado.');
      }
    }, error => {
      console.log(error);
      alert('Cliente não cadastrado');
    })
  }

  getUserData() {
    this.userLogged = JSON.parse(localStorage.getItem('user_logged'));
    this.isAuthenticated = this.userLogged != null;
  }

}
