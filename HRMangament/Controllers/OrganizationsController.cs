using HRMangament.Domain.Organizationses.Commands;
using HRMangament.Domain.Organizationses.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangament.Controllers
{
    [ApiController]
    public class OrganizationsController: ControllerBase
    {
        private readonly IGetOrganizations      _getOrganizations;
        private readonly IAddOrganization       _addOrganization;
        private readonly IDeleteOrganization    _deleteOrganization;
        private readonly IUpdateOrganization    _updateOrganization;
        private readonly IGetOrganizationById   _getOrganizationById;

        public OrganizationsController(IGetOrganizations getOrganizations, IAddOrganization addOrganization, IDeleteOrganization deleteOrganization,
                                    IUpdateOrganization updateOrganization, IGetOrganizationById getOrganizationById)
        {
            _getOrganizations = getOrganizations;
            _addOrganization = addOrganization;
            _deleteOrganization = deleteOrganization;
            _updateOrganization = updateOrganization;
            _getOrganizationById = getOrganizationById;
        }
        [HttpGet]
        public IActionResult GetOrganization()
        {
            return new JsonResult(_getOrganizations.Excute());
        }
        [HttpGet]
        public IActionResult GetOrganizationById( int organizationId)
        {
            return new JsonResult(_getOrganizationById.Excute(organizationId));
        }

        [HttpPost]
        [Route("AddOrganization")]
        public IActionResult AddOrganization([FromBody] AddOrganizationCommand organization)
        {
            _addOrganization.Excute(organization);
            return Ok();
        }
        [HttpDelete]
        [Route("AddOrganization")]

        public IActionResult DeleteOrganization( int organizationId)
        {
            _deleteOrganization.Excute(organizationId);
            return Ok();
        }
        [Route("AddOrganization")]


        public IActionResult UpdateOrganization( UpdateOrganizationCommand organization)
        {
            _updateOrganization.Excute(organization);
            return Ok();
        }
    }
}
