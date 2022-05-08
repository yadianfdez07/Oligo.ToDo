using System;
using System.Collections.Generic;
using System.Text;
using todo.domain;

namespace todo.services
{
    public interface IToDoItemService
    {
        List<ToDoItem> GetToDoItems();
    }
}
