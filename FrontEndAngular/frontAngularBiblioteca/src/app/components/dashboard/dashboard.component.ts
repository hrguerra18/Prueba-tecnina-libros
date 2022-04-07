import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Libro } from 'src/app/models/Libro';
import { LibroService } from 'src/app/services/libro.service';
import { LoginService } from 'src/app/services/login.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
   listLibros : Libro[] = [];
   loading = false;
   login : FormGroup;
   mostrarCardAgregar = false
   cardEditar = false
   libro : Libro = {}
   username : string = "";

  constructor(private libroService:LibroService,private toastr: ToastrService, private fb : FormBuilder,private loginService:LoginService) {
    this.login = this.fb.group({
      title: ['',Validators.required],
      autor: ['',Validators.required],
      publisher: ['',Validators.required],
      genre: ['',Validators.required],
      price: ['',Validators.required],
    })
   }

  ngOnInit(): void {
    this.username = this.loginService.username;
    this.getLibros();
  }

  getLibros(): void {
    this.loading = true;
    this.libroService.getLibros().subscribe(data => {
      this.listLibros = data.libros;
      console.log(this.listLibros);
      this.loading = false;
    },error => {
      console.log(error);
      this.loading = false;
    });
  }

  editLibro(id : number) : void{
    console.log(id);
  }

  eliminarLibro(id:number) : void{
    var resp = confirm("Seguro que lo desea eliminar")
    if(resp == true){
      this.loading = true;
      this.libroService.eliminarLibro(id).subscribe(data => {
        this.toastr.error(data.message, "Registro borrado")
        this.getLibros();
        this.loading = false;
      },error=> {
        console.log(error)
        this.loading = false;

      });
    }
  }

  mostrarCardAdd(): void {
    this.mostrarCardAgregar = true;
    this.cardEditar = false
    this.login.reset()
  }

  cancelarCard():void{
    this.mostrarCardAgregar = false;
    this.cardEditar  = false
  }

  AgregarLibro():void{
    const libro : Libro = {
      title: this.login.value.title,
      autor: this.login.value.autor,
      publisher: this.login.value.publisher,
      genre: this.login.value.genre,
      price: this.login.value.price,
    }
    this.loading = true;
    this.libroService.agregarLibro(libro).subscribe(data => {
      this.toastr.success(data.message, "Registro exitoso!")
      this.loading = false;
      this.getLibros();
      console.log(data)
      this.login.reset();
      this.mostrarCardAgregar = false;
    },error => {
      this.loading = false;
      console.log(error)
    })
  }

  mostrarCardEditar(libro : Libro): void{
    this.cardEditar = true
    this.mostrarCardAgregar = false;
    this.libro = libro;
  }

  actualizarLibro():void{
    const libro : Libro = {
      id: this.libro.id,
      title: this.login.value.title,
      autor: this.login.value.autor,
      publisher: this.login.value.publisher,
      genre: this.login.value.genre,
      price: this.login.value.price,
    }
    this.loading = true;
    this.libroService.actualizarLibro(libro).subscribe(data => {
      this.toastr.info(data.message, "Actualizacion exitosa");
      this.getLibros();
      this.login.reset();
      this.cardEditar = false;
      this.loading = false;
    },error => {
      console.log(error);
      this.loading = false;
    })
  }



}
