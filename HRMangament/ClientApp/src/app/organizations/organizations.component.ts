import { OrganizationsService } from "./../core/http/organizations.service";
import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { stringify } from "querystring";
import { FormBuilder, FormGroup } from "@angular/forms";
import { OrganizationsModel } from "./organizations";

@Component({
  selector: "app-organizations",
  templateUrl: "./organizations.component.html",
  styleUrls: ["./organizations.component.css"],
})
export class OrganizationsComponent implements OnInit {
  organizations: any;
  organizationId: any;
  formValue!: FormGroup;
  OrganizationsModelObj: OrganizationsModel = new OrganizationsModel();
  showAdd: boolean = true;
  showUpdate: boolean = false;
  constructor(
    private OrganizationsService: OrganizationsService,
    private formbuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    //-------- get organization ---------
    this.dogetorganizations();
    //-------- add organization ---------
    this.formValue = this.formbuilder.group({
      organizationName: [""],
      subscribtionStartDate: [""],
      subscribtionEndDate: [""],
      maxEmployeesNumber: [""],
    }); // formvalue

    this.OrganizationsService.getOrganizationById(4).subscribe((response) => {
      console.log("res", JSON.stringify(response));
    });


  } // ngoninit

  dogetorganizations() {
    this.OrganizationsService.getorganizations().subscribe((response) => {
      console.log("res", JSON.stringify(response));
      this.organizations = response;
    });
  } // get organizations

  doaddorganization() {
    this.showAdd = true;
    this.showUpdate = false;
    this.OrganizationsModelObj.organizationName =
      this.formValue.value.organizationName;
    this.OrganizationsModelObj.subscribtionStartDate =
      this.formValue.value.subscribtionStartDate;
    this.OrganizationsModelObj.subscribtionEndDate =
      this.formValue.value.subscribtionEndDate;
    this.OrganizationsModelObj.maxEmployeesNumber =
      this.formValue.value.maxEmployeesNumber;
    console.log(this.OrganizationsModelObj);
    this.OrganizationsService.addorganization(
      this.OrganizationsModelObj
    ).subscribe(
      (response) => {
        alert("organization added successfully");
        this.dogetorganizations();
        this.formValue.reset();
      },
      (err) => {
        alert("something wrong !");
      }
    ); // subscribe
  } // Add organization

  dodeleteorganization(row: any) {
    console.log(row);
    this.OrganizationsService.deleteorganization(row).subscribe((response) => {
      console.log("response", response);

      alert("organization deleted successfully");
      this.dogetorganizations();
    });
  } // delete organization

  onEdit(row: any) {
    this.showAdd = false;
    this.showUpdate = true;
    this.formValue.controls["organizationName"].setValue(row.organizationName);
    this.formValue.controls["subscribtionStartDate"].setValue(
      row.subscribtionStartDate
    );
    this.formValue.controls["subscribtionEndDate"].setValue(
      row.subscribtionEndDate
    );
    this.formValue.controls["maxEmployeesNumber"].setValue(
      row.maxEmployeesNumber
    );
    this.organizationId = row.organizationId;
    console.log("form", this.formValue.value);
  }
  doEditOrganization() {
    this.OrganizationsModelObj.organizationName =
      this.formValue.value.organizationName;
    this.OrganizationsModelObj.subscribtionStartDate =
      this.formValue.value.subscribtionStartDate;
    this.OrganizationsModelObj.subscribtionEndDate =
      this.formValue.value.subscribtionEndDate;
    this.OrganizationsModelObj.maxEmployeesNumber =
      this.formValue.value.maxEmployeesNumber;
    this.OrganizationsModelObj.organizationId = this.organizationId;

    console.log("edit", this.OrganizationsModelObj);

    this.OrganizationsService.editorganization(
      this.OrganizationsModelObj
    ).subscribe((response) => {
      alert("Updated successfully");
      this.showAdd = false;
      this.showUpdate = true;

      this.formValue.reset();
      this.dogetorganizations();
    });
  } // Edit organization
}
