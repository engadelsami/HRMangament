using HRMangament.Domain.Organizationses.AccessLayer;
using HRMangament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Organizationses.Services
{
    public interface IGetOrganizationById
    {
        Organizations Excute(int organizationId);
    }
    public class GetOrganizationById: IGetOrganizationById
    {
        private readonly IOrganizationsDataAdapter _organizationsDataAdapter;
        public GetOrganizationById(IOrganizationsDataAdapter organizationsDataAdapter)
        {
            _organizationsDataAdapter = organizationsDataAdapter;
        }
        public Organizations Excute(int organizationId)
        {
            return _organizationsDataAdapter.GetOrganizationById(organizationId);
        }
    }
}
