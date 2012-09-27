using System.Collections.Generic;

namespace MvcApplication1.Models
{
    public class Person
    {
        public virtual int id { get; set; }
        public virtual int cpr { get; set; }
        public virtual string name { get; set; }
    }
}