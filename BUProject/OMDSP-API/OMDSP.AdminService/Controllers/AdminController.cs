using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMDSP.AdminService.Models;
using OMDSP.AdminService.Repositories;

namespace OMDSP.AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repo;
        public AdminController(IAdminRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("viewMedicinelist")]
        public IActionResult viewMedicinelist()
        {
            try
            {
                return Ok(_repo.medicineList());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("addNgolist")]
        public IActionResult addNgolist(NgoList obj)
        {
            try
            {
                _repo.ngoRegistration(obj);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("userList")]
        public IActionResult userList()
        {
            try
            {
                return Ok(_repo.userList());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Route("deleteNgo/{NgoId}")]
        public IActionResult deleteNgo(string NgoId)
        {
            try
            {
                _repo.deleteNgo(NgoId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("updateNgo")]
        public IActionResult updateNgo(NgoList ngolist)
        {
            try
            {
                _repo.updateNgo(ngolist);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("getNgoid/{NgoId}")]
        public IActionResult GetNgoId(string NgoId)
        {
            try
            {
                return Ok(_repo.GetNgoId(NgoId));
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }

    }
}
