using System.Collections.Generic;
using CRUD.Models;

namespace CRUD.Data
{
    public class MockCommanderRepo : IcommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id = 0, HowTo = "JustTesting", Line = "JustTestingAgain", Plataform = "OnceMore"},
                new Command{Id = 1, HowTo = "DoingSomething", Line = "WithSomething", Plataform = "Doing & Something"},
                new Command{Id = 2, HowTo = "Making Something", Line = "In somewhere", Plataform = "Making & where"},
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return  new Command{Id = 0, HowTo = "JustTesting", Line = "JustTestingAgain", Plataform = "OnceMore"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}