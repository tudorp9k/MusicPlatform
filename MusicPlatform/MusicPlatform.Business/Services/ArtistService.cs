using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlatform.DataLayer;

namespace MusicPlatform.Business.Services
{
    public class ArtistService
    {
        private readonly UnitOfWork unitOfWork;

        private readonly AuthorizationService authService;

        public ArtistService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }
    }
}
