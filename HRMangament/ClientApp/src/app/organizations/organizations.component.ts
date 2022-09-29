import { OrganizationsService } from './../core/http/organizations.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { stringify } from 'querystring';
import { FormBuilder, FormGroup } from '@angular/forms';
import { OrganizationsModel } from './organizations';

@Component({
  selector: 'app-organizations',
  templateUrl: './organizations.component.html',
  styleUrls: ['./organizations.component.css']
})
export class OrganizationsComponent implements OnInit {
  organizations :any;
  formValue !: FormGroup;
  OrganizationsModelObj :OrganizationsModel=new OrganizationsModel();
  showAdd : boolean =true;
  showUpdate :boolean =false;
  constructor(private OrganizationsService :OrganizationsService,private formbuilder :FormBuilder ) { }

  ngOnInit():void {
    //-------- get organization ---------
    this.dogetorganizations();
    //-------- add organization ---------
    this.formValue= this.formbuilder.group
    ({
      OrganizationName :[''],
      subscribtionStartDate:[''],
     subscribtionEndDate :[''],
       MaxEmployeesNumber :['']
  })// formvalue

    }// ngoninit

  dogetorganizations()
  {
    this.OrganizationsService.getorganizations().subscribe(response=>{
      console.log('res',JSON.stringify(response));
      this.organizations = response;
    })
  }// get organizations

  doaddorganization()
  {
    this.showAdd=true;
    this.showUpdate=false;
    this.OrganizationsModelObj.organizationName= this.formValue.value.OrganizationName;
    this.OrganizationsModelObj.subscribtionStartDate= this.formValue.value.subscribtionStartDate;
    this.OrganizationsModelObj.subscribtionEndDate= this.formValue.value.subscribtionEndDate;
    this.OrganizationsModelObj.maxEmployeesNumber= this.formValue.value.MaxEmployeesNumber;
    console.log(this.OrganizationsModelObj);
    this.OrganizationsService.addorganization(this.OrganizationsModelObj).subscribe(response=>
     {
         alert("organization added successfully");
         this.formValue.reset();
     },err=>
     {
       alert("something wrong !")
     })// subscribe
     this.dogetorganizations();

  }// Add organization

 dodeleteorganization(row :any)
  {
    console.log(row);
     this.OrganizationsService.deleteorganization(row).subscribe(response=>{
     console.log("response",response );

     alert("organization deleted successfully");
     this.dogetorganizations();
    })
  }// delete organization

  onEdit(row:any)
  {
      this.showAdd=false;
      this.showUpdate=true;
      this.formValue.controls['OrganizationName'].setValue(row.OrganizationName);
      this.formValue.controls['subscribtionStartDate'].setValue(row.subscribtionStartDate);
      this.formValue.controls['subscribtionEndDate'].setValue(row.subscribtionEndDate);
      this.formValue.controls['MaxEmployeesNumber'].setValue(row.MaxEmployeesNumber);
      console.log("form",this.formValue.value);
  }
  doEditOrganization()
  {
    this.OrganizationsModelObj.organizationName= this.formValue.value.OrganizationName;
    this.OrganizationsModelObj.subscribtionStartDate= this.formValue.value.subscribtionStartDate;
    this.OrganizationsModelObj.subscribtionEndDate= this.formValue.value.subscribtionEndDate;
    this.OrganizationsModelObj.maxEmployeesNumber= this.formValue.value.MaxEmployeesNumber;

    console.log("edit",this.OrganizationsModelObj);

     this.OrganizationsService.editorganization(this.OrganizationsModelObj).subscribe(response=>
      {
          alert("Updated successfully");
          this.showAdd=false;
          this.showUpdate=true;

          this.formValue.reset();
          this.dogetorganizations();
      })
  }// Edit organization
}
