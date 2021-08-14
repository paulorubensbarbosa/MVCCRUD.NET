using System.Collections.Generic;
using AutoMapper;
using CRUD.Data;
using CRUD.Dtos;
using CRUD.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IcommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(IcommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //private readonly MockCommanderRepo _repository = new MockCommanderRepo(); 
                                //oque retorna "<IEnumerable<Commands>>
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        //GET api/commands/{id}
        [HttpGet("{id}", Name ="GetCommandByID")]
        public ActionResult <CommandReadDto> GetCommandByID(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null)
            {
            return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel= _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandByID), new {Id = commandReadDto.Id}, commandReadDto);
            //return Ok(commandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandMoldelFromRepo = _repository.GetCommandById(id);
            if(commandMoldelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandMoldelFromRepo);

            _repository.UpdateCommand(commandMoldelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandMoldelFromRepo = _repository.GetCommandById(id);
            if(commandMoldelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandMoldelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

             _mapper.Map(commandToPatch, commandMoldelFromRepo);

             _repository.UpdateCommand(commandMoldelFromRepo);

             _repository.SaveChanges();

             return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandMoldelFromRepo = _repository.GetCommandById(id);
            if(commandMoldelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandMoldelFromRepo);
            _repository.SaveChanges();
            
            return NoContent();
        }
        
    }
}