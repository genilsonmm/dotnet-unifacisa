using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Domain
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        //ManyToOne
        public User User { get; set; }
        public virtual Guid UserId { get; set; }
    }
}
