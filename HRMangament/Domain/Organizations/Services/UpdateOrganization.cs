using HRMangament.Domain.Organizationses.AccessLayer;
using HRMangament.Domain.Organizationses.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Organizationses.Services
{
    public interface IUpdateOrganization
    {
        void Excute(UpdateOrganizationCommand organization);
    }
    public class UpdateOrganization: IUpdateOrganization
    {
        private readonly IOrganizationsDataAdapter _organizationsDataAdapter;
        public UpdateOrganization(IOrganizationsDataAdapter organizationsDataAdapter)
        {
            _organizationsDataAdapter = organizationsDataAdapter;
        }
        public void Excute(UpdateOrganizationCommand organization)
        {
            var oldOrganization = new Organizations
            {
              //OrganizationId = organization.OrganizationId,
              //OrganizationName = organization.OrganizationName,
              //subscribtionStartDate = organization.subscribtionStartDate,
              //subscribtionEndDate = organization.subscribtionEndDate,
              //MaxEmployeesNumber = organization.MaxEmployeesNumber,

            };
            _organizationsDataAdapter.UpdateOrganization(organization);
        }
    }
}
