using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class Player
    {
        private string username;
        private ConsoleColor color;
        private ResourcesManager resources;

        public Player(string username, ConsoleColor color)
        {
            this.username = username;
            this.color = color;
            resources = new ResourcesManager();
        }

        public ResourcesManager Resources
        {
            get { return resources; }
            set { resources = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
