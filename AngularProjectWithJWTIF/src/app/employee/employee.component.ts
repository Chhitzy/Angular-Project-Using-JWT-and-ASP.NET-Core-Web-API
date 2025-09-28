import { Component } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.scss'
})
export class EmployeeComponent {

  constructor(private employeeService:EmployeeService){}

  employeesList :Employee[]=[];

  newEmployee :Employee = new Employee();
  editEmployee : Employee = new Employee();

  getAll(){
    this.employeeService.getEmployees().subscribe(
      (response)=>{
        this.employeesList = response;
        console.log(response);
      }, //success port
      (error)=>{
        console.log("Unable To Gain Access of API");
      }, //failure port
    );
  }
  ngOnInit(){
    this.getAll();
  }

  editClick(emp:Employee){
    this.editEmployee = emp;
  }

  saveClick(){
    this.employeeService.saveEmployees(this.newEmployee).subscribe(
      
      (response)=>{
      alert("Data Saved");
      this.getAll();
      this.ClearRec();
    },
    (error)=>{
      console.log("Unable to access api");
    },
  );
  }

  updateClick(){
    this.employeeService.updateEmployee(this.editEmployee).subscribe(
      (response)=>{
        alert("Data Updated");
        this.getAll();
        this.ClearRec();
      },
      (error)=>{
        console.log("Unable to Access API!!!");
      },
    );
  }

  deleteClick(id:number){
    let ans = window.confirm("Want to Delete Data?");
    if(!ans) return;

    this.employeeService.deleteEmployee(id).subscribe(
      (response)=>{
        alert("Data Deleted");
        this.getAll();
      },
      (error)=>{
        console.log("Unable to gain access to API.");
      },
    );
  }

  ClearRec(){
    this.newEmployee.name = "";
    this.newEmployee.address = "";
    this.newEmployee.salary = 0;
  }

}
