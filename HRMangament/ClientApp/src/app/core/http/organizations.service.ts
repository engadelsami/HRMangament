import { map } from 'rxjs/operators';
import { OrganizationsModel } from './../../organizations/organizations';
import { Observable } from 'rxjs';
import { environment as env } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
//import { environment as env} from '@env/environment';
import { Injectable } from '@angular/core';



@Injectable({
  providedIn: 'root'
})
export class OrganizationsService {
  constructor(private http :HttpClient) { }
  getorganizations()
  {
     return this.http.get(`${env.apiroot}/Organizations/GetOrganization`);
  }

  addorganization(organization :OrganizationsModel)
  {
      console.log("data is :",organization)
      return this.http.post<OrganizationsModel>(`${env.apiroot}/Organizations/AddOrganization`, organization).pipe(map((res)=>{return res;}));
  }

  deleteorganization(data :any)
  {
    console.log("data",data);
     return this.http.delete(`${env.apiroot}/Organizations/DeleteOrganization?organizationId=${data}`);
  }

  getOrganizationById(data :any)
  {
    console.log("data",data);
    return this.http.get(`${env.apiroot}/Organizations/GetOrganizationById?organizationId=${data}`);
  }


  editorganization(data :any)
  {
    console.log("data",data);
     return this.http.put(`${env.apiroot}/Organizations/UpdateOrganization`,data);
  }
}
