using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facebook_clone.Data;
using facebook_clone.Dtos.UserProfile;
using facebook_clone.Mappers;
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
            var userProfiles = _context.UserProfiles.ToList()
                .Select(u => u.ToUserProfileDto()); // This line is not needed in the original code

            return Ok(userProfiles);    
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var userProfile = _context.UserProfiles.FirstOrDefault(u => u.Id == id);

            if(userProfile == null){
                return NotFound();
            }

            return Ok(userProfile.ToUserProfileDto());  
        }
         
    [HttpPost]
    public IActionResult Create([FromBody] CreateUserProfileDto userProfileDto){
        var userProfile = userProfileDto.ToUserProfileFromCreateDTO();

        _context.UserProfiles.Add(userProfile);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new {id = userProfile.Id}, userProfile.ToUserProfileDto());

    }
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateUserProfileRequestDto updateUserProfileDto){
        var userProfile = _context.UserProfiles.FirstOrDefault(u => u.Id == id);

        if(userProfile == null){
            return NotFound();
        }

        userProfile.Name = updateUserProfileDto.Name;
        userProfile.ProfilePicture = updateUserProfileDto.ProfilePicture;
        userProfile.CoverPicture = updateUserProfileDto.CoverPicture;
        userProfile.City = updateUserProfileDto.City;
        userProfile.Country = updateUserProfileDto.Country;
        userProfile.Bio = updateUserProfileDto.Bio;

        _context.SaveChanges();

        return NoContent();

    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var userProfile = _context.UserProfiles.FirstOrDefault(u => u.Id == id);

        if(userProfile == null){
            return NotFound();
        }

        _context.UserProfiles.Remove(userProfile);
        _context.SaveChanges();

        return NoContent();
    }
    }
}