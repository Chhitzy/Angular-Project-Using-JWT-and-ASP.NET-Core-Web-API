import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from './login';
import { Observable } from 'rxjs';
import{map} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  currentUserName:string ="";

  constructor(public httpClient : HttpClient) { }

  CheckUser(login:Login):Observable<any>{
    return this.httpClient.post<any>("https://localhost:7130/api/Account/Authenticate",login).pipe(map(user=>{
      if(user){
        this.currentUserName = user.username;
        sessionStorage["CurrentUser"] = JSON.stringify(user);
      }
      return null;
    }));
  }
  

}
