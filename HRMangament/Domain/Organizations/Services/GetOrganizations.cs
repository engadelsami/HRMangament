using HRMangament.Domain.Organizationses.Commands;
using HRMangament.Domain.Organizationses.AccessLayer;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Organizationses.Services
{
    public interface IGetOrganizations
    {
        List<GetOrganizationsCommand> Excute();
    }
    public class GetOrganizations: IGetOrganizations
    {
        private readonly IOrganizationsDataAdapter _organizationsDataAdapter;
        public GetOrganizations(IOrganizationsDataAdapter organizationsDataAdapter)
        {
            _organizationsDataAdapter = organizationsDataAdapter;
        }
        public List<GetOrganizationsCommand> Excute()
        {
            var Organizations = new List<GetOrganizationsCommand>();

            foreach (var item in _organizationsDataAdapter.GetOrganizations())
            {
                var model = new GetOrganizationsCommand();

                model.OrganizationId = item.OrganizationId;
                model.OrganizationName = item.OrganizationName;
                model.MaxEmployeesNumber = item.MaxEmployeesNumber;
                model.subscribtionStartDate = item.subscribtionStartDate;
                model.subscribtionEndDate = item.subscribtionEndDate;


                Organizations.Add(model);
            }
            return Organizations;

        }
    }
}
