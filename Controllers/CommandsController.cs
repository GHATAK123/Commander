using System.Collections.Generic;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Comtrollers{

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase {
        
        public ActionResult <IEnumerable<Command>> GetAllCommands() {
            


        }

        public ActionResult <Command> GetCommandById(int id) {

        }
        
    }
}