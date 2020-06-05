using System.Collections.ObjectModel;
using ToDoList.Model;

namespace ToDoList.Data
{
    public static class Database
    {
        public static ObservableCollection<Activity> activities = new ObservableCollection<Activity>();
    }
}
