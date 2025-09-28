import { Component } from '@angular/core';
import { LoginService } from './login.service';
import { Router} from "@angular/router"

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'AngularProjectWithJWTIF';
  constructor(public loginService: LoginService, private router: Router){}
  logout(){
    sessionStorage.clear();
    this.loginService.currentUserName ="";
    this.router.navigateByUrl("/login");
    
  }
}
