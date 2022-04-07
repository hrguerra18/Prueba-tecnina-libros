import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { BienvenidaComponent } from './components/inicio/bienvenida/bienvenida.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { LoginComponent } from './components/inicio/login/login.component';
import { RegisterComponent } from './components/inicio/register/register.component';

const routes: Routes = [
  {path: '',redirectTo: '/inicio', pathMatch: 'full'},
  {path:'inicio', component:InicioComponent, children: [
    {path:'', component:BienvenidaComponent},
    {path:'login', component:LoginComponent},
    {path:'register', component:RegisterComponent},
  ]},
  {path: 'dashboard', component: DashboardComponent},
  {path: '**', redirectTo: '/inicio', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
