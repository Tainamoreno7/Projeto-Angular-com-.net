import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../_data-server/user.data.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: any[] = [];//variavel
  showList: boolean = true;

  constructor(private userDataService: UserDataService) { }

  ngOnInit() {
    this.get();
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
}
