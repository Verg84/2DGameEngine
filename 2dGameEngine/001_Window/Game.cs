using GameEngine.Source;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    internal class Game:Engine
    {
        public Game() : base((uint)8000, (uint)800, "WINDOW", Color.Black) { }
    }
}
