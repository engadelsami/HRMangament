using HRMangament.Domain.Organizationses.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Organizationses.Services
{
    public interface IDeleteOrganization
    {
        void Excute(int organizationId);
    }
    public class DeleteOrganization:IDeleteOrganization
    {
        private readonly IOrganizationsDataAdapter _organizationsDataAdapter;
        public DeleteOrganization(IOrganizationsDataAdapter organizationsDataAdapter)
        {
            _organizationsDataAdapter = organizationsDataAdapter;
        }
        public void Excute(int organizationId)
        {
            _organizationsDataAdapter.DeleteOrganization(organizationId);
        }
    }
}
