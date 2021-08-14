using AutoMapper;
using CRUD.Dtos;
using CRUD.Models;

namespace CRUD.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source ->Target
            CreateMap<Command, CommandReadDto>();

            CreateMap<CommandCreateDto, Command>();

            CreateMap<CommandUpdateDto, Command>();

            CreateMap<Command, CommandUpdateDto>();
        }

    }
}