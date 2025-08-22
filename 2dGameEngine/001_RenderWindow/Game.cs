using GameEngine.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace GameEngine
{
    internal class Game : Engine
    {
        public Game() : base((uint)800, (uint)800, "RENDER WINDOW", Color.Black) { }
    }
}
