using System;
using System.Collections.Generic;
using todo.domain;

namespace todo.services
{
    public class ToDoItemService : IToDoItemService
    {
        public List<ToDoItem> ToDos { get; private set; }

        public List<ToDoItem> GetToDoItems()
        {
            ToDos = new List<ToDoItem> {
                new ToDoItem { Id = 1, Identifier = Guid.NewGuid(), Description = $"ToDo with Id: 1" },
                new ToDoItem { Id = 2, Identifier = Guid.NewGuid(), Description = $"ToDo with Id: 2" },
                new ToDoItem { Id = 3, Identifier = Guid.NewGuid(), Description = $"ToDo with Id: 3" }
            };

            return ToDos;
        }
    }
}
