using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Room
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public List<string> Description { get; internal set; }
        public Person Person { get; internal set; }
        public Item Item { get; internal set; }

        internal Room(int id, string name, List<string> description, Person person, Item item)
        {
            Id = id;
            Name = name;
            Description = description;
            Person = person;
            Item = item;
        }

        public Room GetRoomInfo()
        {
            return this;
        }


    }

}
