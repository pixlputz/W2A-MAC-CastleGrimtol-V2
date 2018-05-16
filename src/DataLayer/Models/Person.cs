using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Person
    {
        public enum MoodStatus
        {
            Good,
            Bad
        }

        public string Title { get; internal set; }
        public MoodStatus Mood { get; internal set; }

        public Person(string title, MoodStatus mood)
        {
            Title = title;
            Mood = mood;
        }


    }

}
