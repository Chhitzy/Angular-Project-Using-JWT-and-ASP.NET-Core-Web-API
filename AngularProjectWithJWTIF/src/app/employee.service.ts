import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from './employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpClient:HttpClient) { }

  getEmployees():Observable<any>{
    return this.httpClient.get("https://localhost:7130/api/Employees");
  }

  saveEmployees(employee:Employee):Observable<any>{
    return this.httpClient.post("https://localhost:7130/api/Employees",employee);
  }

  updateEmployee(employee:Employee):Observable<any>{
    return this.httpClient.put("https://localhost:7130/api/Employees",employee);
  }

  deleteEmployee(id:number):Observable<any>{
    return this.httpClient.delete("https://localhost:7130/api/Employees/"+ id);
  }

}
