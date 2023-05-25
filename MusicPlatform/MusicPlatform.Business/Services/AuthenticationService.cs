using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlatform.Business.Dtos;
using MusicPlatform.DataLayer;
using MusicPlatform.DataLayer.Enums;
using MusicPlatform.DataLayer.Models;
using MusicPlatform.DataLayer.Repositories;

namespace MusicPlatform.Business.Services
{
    public class AuthenticationService
    {
        private readonly UnitOfWork unitOfWork;

        private readonly AuthorizationService authService;

        public AuthenticationService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
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
                Role = UserRole.Listener.ToString()
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

            var hashedPassword = authService.HashPassword(registerData.PasswordHash);

            var artist = new Artist
            {
                Username = registerData.Username,
                PasswordHash = hashedPassword,
                Name = registerData.Name,
                Description = registerData.Description,
                Genre = (Genre) Enum.Parse(typeof(Genre), registerData.Genre),
                Role = UserRole.Artist.ToString()
            };

            unitOfWork.Artists.Insert(artist);
            unitOfWork.SaveChanges();
        }

        public string Validate(UserDto payload)
        {
            var artist = unitOfWork.Artists.GetByUsername(payload.Username);

            if (artist != null && authService.VerifyHashedPassword(artist.PasswordHash, payload.Password))
            {
                return authService.GetToken(artist, artist.Role);
            }

            var user = unitOfWork.Users.GetByUsername(payload.Username);

            if (user != null && authService.VerifyHashedPassword(user.PasswordHash, payload.Password))
            {
                return authService.GetToken(user, user.Role);
            }

            return null;

        }
    }
}
