using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using todo.domain;

namespace todo.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var repl = new TodoREPL(Console.In, Console.Out);

            repl.Start();

        }
    }

    public class TodoREPL
    {
        public List<ToDoItem> ToDos { get; set; }
        private readonly TextReader input;
        private readonly TextWriter output;

        public TodoREPL(TextReader input, TextWriter output)
        {
            ToDos = new List<ToDoItem> {
                new ToDoItem { Id = 1, Identifier = Guid.NewGuid(), Description = $"ToDo with Id: 1" },
                new ToDoItem { Id = 2, Identifier = Guid.NewGuid(), Description = $"ToDo with Id: 2" },
                new ToDoItem { Id = 3, Identifier = Guid.NewGuid(), Description = $"ToDo with Id: 3" }
            };

            this.input = input;
            this.output = output;
        }

        public void Start()
        {
            var input = "false";

            foreach (var todo in ToDos)
            {
                output.WriteLine($"Id: {todo.Id}");
                output.WriteLine($"Identifier: {todo.Identifier}");
                output.WriteLine($"Description: {todo.Description}");
                output.WriteLine($"{Environment.NewLine}");
            }


            while (!input.Equals("quit"))
            {
                Prompt();
                var action = Read();

                switch (action)
                {
                    case "quit":
                    case "x":
                    case "exit":
                        Console.WriteLine("good bye");
                        input = "quit";
                        break;
                    case "list":
                    case "show":
                        foreach (var todo in ToDos)
                        {
                            output.WriteLine($"Id: {todo.Id}");
                            output.WriteLine($"Identifier: {todo.Identifier}");
                            output.WriteLine($"Description: {todo.Description}");
                            output.WriteLine($"{Environment.NewLine}");
                        }
                        break;
                    case "add":
                        output.WriteLine("enter description:");
                        var descriptiom = Read();
                        var newTodo = new ToDoItem { Id = ToDos.Count + 1, Identifier = Guid.NewGuid(), Description = descriptiom };
                        ToDos.Add(newTodo);
                        break;
                    case "del":
                    case "delete":
                    case "rm":
                    case "remove":
                        output.WriteLine("enter description:");
                        int id = int.Parse(Read());
                        ToDos.Remove(ToDos.Single(x => x.Id.Equals(id)));
                        break;
                    default:
                        Console.WriteLine("try again");
                        break;
                }
            }
        }

        private string Read()
        {
            return input.ReadLine();
        }

        private void Prompt()
        {
            output.Write("ToDo: > ");
            output.Flush();
        }
    }
}
