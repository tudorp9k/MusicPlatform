﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlatform.DataLayer;
using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.Business.Services
{
    public class ArtistService
    {
        private readonly UnitOfWork unitOfWork;

        private readonly AuthorizationService authService;

        public ArtistService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        public List<Artist> GetAll()
        {
            return unitOfWork.Artists.GetAll();
        }
    }
}