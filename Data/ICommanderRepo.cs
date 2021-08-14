using System.Collections.Generic;
using CRUD.Models;

namespace CRUD.Data
{
    public interface IcommanderRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    
        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);

        void DeleteCommand(Command cmd);
    }  
}