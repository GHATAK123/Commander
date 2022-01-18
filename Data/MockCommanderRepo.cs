using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data {
    public class MockCommanderRepo:ICommanderRepo {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands() {
            // throw new NotImplementedException();
            var commands = new List<Command> {
                new Command{Id =0,HowTo = "Boil an Egg",Line = "Boil Water",Platform="Kettle & Pan"},
                new Command{Id =1,HowTo = "Make a maggie",Line = "Boil Water",Platform="Kettle & Pan"},
                new Command{Id =2,HowTo = "Make a Tea",Line = "Boil Milk",Platform="Kettle & Pan"},
                new Command{Id =3,HowTo = "Make boiled Eggs",Line = "Boil Eggs Water",Platform="Kettle & Pan"}

            };
            return commands;

        }
        public Command GetCommandById(int id) {
            //throw new NotImplementedException();
            return new Command{Id =0,HowTo = "Boil an Egg",Line = "Boil Water",Platform="Kettle & Pan"};
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}