import { Component, OnInit } from '@angular/core';
import { debug } from 'console';
import { UserDataService } from '../_data-server/user.data.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: any[] = [];
  user: any = {}; // objeto vazio
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

  save() {
    if (this.user.id) {
      this.put();
    } else {
      this.post();
    }
  }
  post() {

    //console.log(this.user);
    
    this.userDataService.post(this.user).subscribe(data => {
      
      if (data) {
        alert('Usuário cadastrado com sucesso');
        this.get();
        this.user = {};
        this.showList = false;
      } else {
        alert('Erro ao cadastrar usuário');
      }
    }, error => {
        console.log(error);
       { { debugger } }
      alert('erro interno do sistema');
    })
  }
  put() {
    this.userDataService.put(this.user).subscribe(data => {
      if (data) {
        alert('Usuário atualizado com sucesso');
        this.get();
        this.user = {};
      } else {
        alert('Erro ao atualizar usuário');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }


  
}
