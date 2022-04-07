import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Usuario } from 'src/app/models/Usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  formLogin : FormGroup;
  constructor(private fb:FormBuilder, private usuarioService : UsuarioService,private toastr : ToastrService,private router : Router) {
    this.formLogin = this.fb.group({
      username : ['',Validators.required],
      password : ['',Validators.required],
    })
   }

  ngOnInit(): void {
  }

  registerUser():void{
    const usuario : Usuario = {
      username : this.formLogin.value.username,
      password : this.formLogin.value.password,
    }

    this.usuarioService.createUser(usuario).subscribe(data=>{
      this.toastr.success(data.message, "Registro exitoso.");
      this.router.navigate(['/inicio/login']);
    },error=>{console.log(error)})
  }

}
