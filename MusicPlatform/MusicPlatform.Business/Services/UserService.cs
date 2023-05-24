using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlatform.Business.Dtos;
using MusicPlatform.DataLayer;
using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.Business.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;

        private readonly AuthorizationService authService;

        public UserService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }

        public void Register(UserDto registerData)
        {
            if (registerData == null)
            {
                return;
            }

            var hashedPassword = authService.HashPassword(registerData.Password);

            var user = new User
            {
                Username = registerData.Username,
                PasswordHash = hashedPassword,
            };

            unitOfWork.Users.Insert(user);
            unitOfWork.SaveChanges();
        }

        public void Register(ArtistDto registerData)
        {
            if (registerData == null)
            {
                return;
            }

            var hashedPassword = authService.HashPassword(registerData.Password);

            var user = new Artist
            {
                Username = registerData.Username,
                PasswordHash = hashedPassword,
                Name = registerData.Name,
                Description = registerData.Description,
                Genre = registerData.Genre,
            };

            unitOfWork.Users.Insert(user);
            unitOfWork.SaveChanges();
        }

        public string Validate(UserDto payload, string role)
        {
            var user = unitOfWork.Users.GetByUsername(payload.Username);

            var passwordFine = authService.VerifyHashedPassword(user.PasswordHash, payload.Password);

            if (passwordFine)
            {
                return authService.GetToken(user, role);
            }
            else
            {
                return null;
            }

        }
    }
}
