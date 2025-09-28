import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SupportComponent } from './support/support.component';
import { AboutComponent } from './about/about.component';
import { EmployeeComponent } from './employee/employee.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path : "home", component:HomeComponent},
  {path : "support", component : SupportComponent},
  {path : "about",component:AboutComponent},
  {path : "employee", component: EmployeeComponent},
  {path : "contact", component:ContactComponent},
  {path: "login", component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
