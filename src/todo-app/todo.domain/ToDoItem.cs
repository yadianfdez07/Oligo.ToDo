using System;

namespace todo.domain
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public Guid Identifier { get; set; }
        public string Description { get; set; }

    }
}
