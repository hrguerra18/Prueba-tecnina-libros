import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from '../models/Usuario';
import { JwtHelperService } from "@auth0/angular-jwt";


@Injectable({
  providedIn: 'root'
})
export class LoginService {
  MyAppUrl: string;
  MyApiUrl: string;
  username: string = "";
  constructor(private http:HttpClient) {
    this.MyAppUrl = environment.endpoint;
    this.MyApiUrl = "/api/Login"
   }

   login(usuario : Usuario) : Observable<any> {
    return this.http.post(this.MyAppUrl + this.MyApiUrl, usuario);
  }

  setLocalStorage(token : string):void{
    localStorage.setItem("token", token);
  }

  removeLocalStorage(): void{
    localStorage.removeItem('token');
  }

  getTokenDecoded():any{
    const helper = new JwtHelperService();
    const decodedToken = helper.decodeToken(localStorage.getItem('token')!);
    return decodedToken;
  }
}
