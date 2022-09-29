using HRMangament.Domain.Organizationses.Commands;
using HRMangament.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Domain.Organizationses.AccessLayer
{
    public interface IOrganizationsDataAdapter
    {
        List<Organizations> GetOrganizations();
        void AddOrganization(Organizations organization);
        void DeleteOrganization(int organizationId);
        void UpdateOrganization(UpdateOrganizationCommand organization);
        Organizations GetOrganizationById(int organizationId);
    }
    public class OrganizationsDataAdapter: IOrganizationsDataAdapter
    {
        private readonly HrContext _context;
        public OrganizationsDataAdapter(HrContext context)
        {
            _context = context;
        }
        public void AddOrganization(Organizations organization)
        {
            _context.Organizations.Add(organization);
            _context.SaveChanges();
        }

        public void DeleteOrganization(int organizationId)
        {
            var organization = _context.Organizations.FirstOrDefault(e => e.OrganizationId == organizationId);
            _context.Remove(organization);
            _context.SaveChanges();
        }

        public void UpdateOrganization(UpdateOrganizationCommand _organization)
        {
            // _context.Entry(organization).State = EntityState.Modified;
            var organization = _context.Organizations.FirstOrDefault(e => e.OrganizationId == _organization.OrganizationId);
            organization.OrganizationName = _organization.OrganizationName;
            organization.subscribtionStartDate = _organization.subscribtionStartDate;
            organization.subscribtionEndDate = _organization.subscribtionEndDate;
            organization.MaxEmployeesNumber = _organization.MaxEmployeesNumber;
            organization.OrganizationId = _organization.OrganizationId;

            _context.Update(organization);
            _context.SaveChanges();
        }
        public Organizations GetOrganizationById(int organizationId)
        {
            return _context.Organizations.FirstOrDefault(e => e.OrganizationId == organizationId);
        }
        public List<Organizations> GetOrganizations()
        {
            return _context.Organizations.ToList();
        }
    }
}
