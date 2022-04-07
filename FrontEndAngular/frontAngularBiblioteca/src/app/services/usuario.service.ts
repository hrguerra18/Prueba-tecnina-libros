import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from '../models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  MyAppUrl: string;
  MyApiUrl: string;
  constructor(private http:HttpClient) {
    this.MyAppUrl = environment.endpoint;
    this.MyApiUrl = "/api/Usuario"
   }

   createUser(usuario : Usuario) : Observable<any> {
     return this.http.post(this.MyAppUrl + this.MyApiUrl, usuario);
   }
}
