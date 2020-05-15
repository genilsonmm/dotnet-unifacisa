using System;
using System.Collections.Generic;

namespace ProjectTest.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //OneToMany
        public List<Post> Posts { get; set; }
    }
}
