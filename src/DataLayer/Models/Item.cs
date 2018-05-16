using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Item
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public bool Completed { get; internal set; }
        public bool Submitted { get; internal set; }


        public Item(int id, string name, bool completed, bool submitted)
        {
            Id = id;
            Name = name;
            Completed = completed;
            Submitted = submitted;
        }


    }



}
