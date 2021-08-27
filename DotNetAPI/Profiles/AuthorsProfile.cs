using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PracticeAPI.Helpers;

namespace PracticeAPI.Profiles
{
    public class AuthorsProfile : Profile
    {
        //Maps data from the Author Entity class (that we want to control consummer visability to) to the AuthoDto (Data transfer object) that the consummer can access
        public AuthorsProfile()
        {
            CreateMap<CourseLibrary.API.Entities.Author, Models.AuthorDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

            CreateMap<Models.AuthorForCreationDto, CourseLibrary.API.Entities.Author>();
        }
    }
}
