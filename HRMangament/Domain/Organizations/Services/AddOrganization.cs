using HRMangament.Domain.Organizationses.AccessLayer;
using HRMangament.Domain.Organizationses.Commands;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Organizationses.Services
{
    public interface IAddOrganization
    {
        void Excute(AddOrganizationCommand organization);
    }
    public class AddOrganization: IAddOrganization
    {
        private readonly IOrganizationsDataAdapter _organizationsDataAdapter;
        public AddOrganization(IOrganizationsDataAdapter organizationsDataAdapter)
        {
            _organizationsDataAdapter = organizationsDataAdapter;
        }
        public void Excute(AddOrganizationCommand organization)
        {
            Organizations newOrganization = new Organizations()
            {
                OrganizationName = organization.OrganizationName,
                subscribtionEndDate = organization.subscribtionEndDate,
                subscribtionStartDate = organization.subscribtionStartDate,
                MaxEmployeesNumber = organization.MaxEmployeesNumber

            };
            _organizationsDataAdapter.AddOrganization(newOrganization);
        }
    }
}
