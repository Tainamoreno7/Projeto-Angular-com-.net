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

}
