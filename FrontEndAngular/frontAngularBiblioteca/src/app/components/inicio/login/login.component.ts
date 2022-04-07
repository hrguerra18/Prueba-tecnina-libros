import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Usuario } from 'src/app/models/Usuario';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login : FormGroup;
  constructor(private toastr : ToastrService, private fb: FormBuilder, private router : Router, private loginService: LoginService) {
    this.login = this.fb.group({
      username : ['',Validators.required],
      password : ['',Validators.required]
    })
  }

  ngOnInit(): void {
  }

  validarLogin(): void{
    const usuario : Usuario = {
      username : this.login.value.username,
      password : this.login.value.password
    }

    this.loginService.login(usuario).subscribe(data => {
      this.loginService.username = usuario.username!;
      this.toastr.success(`El usuario ${usuario.username} ingreso correctamente`, "Login exitoso!");
      console.log(data.token)
      this.loginService.setLocalStorage(data.token);
      this.router.navigate(['/dashboard']);
    },error => {
      this.toastr.error(error.error.message, "Error!")
      this.login.reset();
    })

  }

}
