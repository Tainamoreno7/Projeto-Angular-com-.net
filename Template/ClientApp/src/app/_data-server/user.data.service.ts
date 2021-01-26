//contem informações que faz comunicação com banco
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable() //tornar o metodo injetável

export class UserDataService {

  module: string = '/api/users'; //modelos internos utilizaram esse modulo

    constructor(private http: HttpClient) {
    //comandos de comunicação com o banco
  }
  
  get() {
    return this.http.get(this.module);
  }

  post(data) {
    return this.http.post(this.module, data);
  }

  put(data) {
    return this.http.put(this.module, data);
  }

  authenticate(data) {
    return this.http.get(this.module + '/register', data);
  }

 

}
