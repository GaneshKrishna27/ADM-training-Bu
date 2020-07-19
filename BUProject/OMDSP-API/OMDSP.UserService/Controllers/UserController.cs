using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OMDSP.UserService.Models;
using OMDSP.UserService.Repositories;


namespace OMDSP.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Route("addMedicine")]
        public IActionResult addMedicine(MedicineList obj)
        {
            try
            {
                _repo.donateMedicine(obj);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("viewNgolist")]
        public IActionResult viewNgolist()
        {
            try
            {
                return Ok(_repo.searchNgo());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
