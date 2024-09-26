using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facebook_clone.Dtos;
using facebook_clone.Dtos.UserProfile;
using facebook_clone.Models;

namespace facebook_clone.Mappers
{
    public static class UserProfileMappers
    {
        public static UserProfileDto ToUserProfileDto(this UserProfile userProfile)
        {
            return new UserProfileDto
            {
                Id = userProfile.Id,
                Name = userProfile.Name,
                ProfilePicture = userProfile.ProfilePicture,
                CoverPicture = userProfile.CoverPicture,
                City = userProfile.City,
                Country = userProfile.Country,
                Bio = userProfile.Bio
            };
        }
        public static UserProfile ToUserProfileFromCreateDTO(this CreateUserProfileDto userProfileDto){
            return new UserProfile{
                    Name = userProfileDto.Name,
                    ProfilePicture = userProfileDto.ProfilePicture,
                    CoverPicture = userProfileDto.CoverPicture,
                    City = userProfileDto.City,
                    Country = userProfileDto.Country,
                    Bio = userProfileDto.Bio
            };
        }
    }
}