using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Comtrollers{

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository,IMapper mapper)
        {
            _repository = repository;   
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<CommanderReadDtos>> GetAllCommands() {

            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommanderReadDtos>>(commandItems));

        }
        [HttpGet("{id}",Name="GetCommandById")]
        public ActionResult <CommanderReadDtos> GetCommandById(int id) {

            var commandItem = _repository.GetCommandById(id);
             if(commandItem != null) return Ok(_mapper.Map<CommanderReadDtos>(commandItem));
             return NotFound();

        }

        [HttpPost]
        public ActionResult <CommanderReadDtos> CreateCommand(CommanderCreateDtos cmd) {
            var commandModel = _mapper.Map<Command>(cmd);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();
            var commandReadDto = _mapper.Map<CommanderReadDtos>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById),new {Id = commandReadDto.Id},commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommanderUpdateDtos cmd) {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) return NotFound();
            _mapper.Map(cmd,commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id,JsonPatchDocument<CommanderUpdateDtos> patchDoc) {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) return NotFound();
            var commandToPatch = _mapper.Map<CommanderUpdateDtos>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch,ModelState);
            if(!TryValidateModel(commandToPatch)) return ValidationProblem(ModelState);
            _mapper.Map(commandToPatch,commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id){
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) return NotFound();
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        }
        
    }