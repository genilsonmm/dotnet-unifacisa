using System;

namespace ToDoList.Model
{
    public class Activity
    {
        public string Name { get; }
        public DateTime Date { get;}

        public Activity(string activity)
        {
            this.Date = DateTime.Now;
            this.Name = activity;
        }
    }
}
