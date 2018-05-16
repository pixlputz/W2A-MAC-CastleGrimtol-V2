﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Game
    {
        //Game Info:
        internal string Title { get; private set; }
        internal string Version { get; private set; }
        internal string Developer { get; private set; }
        internal string DateLastUpdated { get; private set; }
        internal List<string> Description { get; private set; }

        internal bool Played { get; set; }

        internal Room CurrentRoom { get; set; }
        internal Room PreviousRoom { get; set; }


        public Game(string title, string version, string developer, string dateLastUpdated, List<string> description)
        {
            Title = title;
            Version = version;
            Developer = developer;
            DateLastUpdated = dateLastUpdated;
            Description = description;
        }
    }
}
