using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facebook_clone.Data;
using Microsoft.AspNetCore.Mvc;

namespace facebook_clone.Controllers
{
    [Route("api/userprofile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserProfileController(ApplicationDBContext applicationDBContext)
        {
            _context = applicationDBContext;
            
        }
        [HttpGet]
        public IActionResult GetAll(){
            var userProfiles = _context.UserProfiles.ToList();

            return Ok(userProfiles);    
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var userProfile = _context.UserProfiles.FirstOrDefault(u => u.Id == id);

            if(userProfile == null){
                return NotFound();
            }

            return Ok(userProfile);
        }
         

    }
}