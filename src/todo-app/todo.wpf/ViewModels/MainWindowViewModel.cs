using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using todo.domain;
using todo.services;

namespace todo.wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IToDoItemService toDoItemService;

        public ObservableCollection<ToDoItem> ToDos { get; set; }

        public MainWindowViewModel(IToDoItemService toDoItemService)
        {
            this.toDoItemService = toDoItemService;

            ToDos = new ObservableCollection<ToDoItem>();

            ToDos.AddRange(toDoItemService.GetToDoItems());
        }
    }
}
