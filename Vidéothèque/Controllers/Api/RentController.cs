using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;

using Vidéothèque.Dtos;
using Vidéothèque.Models;

namespace Vidéothèque.Controllers.Api
{
    public class RentController : ApiController
    {
        private ApplicationDbContext _context;

        public RentController()
        {
            _context = new ApplicationDbContext();

        }

        //GET /api/movies
        public IHttpActionResult GetRents()
        {
            var rentDtos = _context.Rents.ToList().Select(Mapper.Map<Rent, RentDto>);
            return Ok(rentDtos);
        }

    }
}
