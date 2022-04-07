import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Libro } from '../models/Libro';
@Injectable({
  providedIn: 'root'
})
export class LibroService {
  MyAppUrl: string;
  MyApiUrl: string;
  constructor(private http : HttpClient) {
    this.MyAppUrl = environment.endpoint;
    this.MyApiUrl = "/api/Libro"
   }

   getLibros():Observable<any> {
     return this.http.get(this.MyAppUrl+this.MyApiUrl);
   }

   eliminarLibro(id : number):Observable<any> {
     return this.http.delete(this.MyAppUrl+this.MyApiUrl+"/"+id);
   }

   agregarLibro(libro : Libro) : Observable<any> {
     return this.http.post(this.MyAppUrl+this.MyApiUrl,libro);
   }

   actualizarLibro(libro : Libro) : Observable<any> {
     return this.http.put(this.MyAppUrl+this.MyApiUrl,libro);
   }
}
