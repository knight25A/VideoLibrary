using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidéothèque.Dtos;
using Vidéothèque.Models;

namespace Vidéothèque.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            //Domain to DTO
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Rent, RentDto>();

            //DTO to Domain
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<RentDto, Rent>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}