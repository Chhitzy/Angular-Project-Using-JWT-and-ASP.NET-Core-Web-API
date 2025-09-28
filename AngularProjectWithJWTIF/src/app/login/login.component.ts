import { Component } from '@angular/core';
import { LoginService } from '../login.service';
import { Login } from '../login';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})

export class LoginComponent {

  user:Login = new Login();

  constructor(private loginService:LoginService, private router: Router){}

  loginClick(){
    this.loginService.CheckUser(this.user).subscribe(
      (response)=>{
        this.router.navigateByUrl("/home");
      },
      (error)=>{
        alert("Wrong Username|Password");
        this.user.username = "";
        this.user.password ="";
      }
    );
  }
}
