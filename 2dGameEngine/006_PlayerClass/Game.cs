using GameEngine.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace GameEngine
{
    internal class Game:Engine
    {
        Player player;
        public Game() : base((uint)800, (uint)800,"Player Class", Color.Black) { }
        
        public override void OnLoad()
        {
            player = new Player(new Vector2(400, 400), new Vector2(),"Player");
        }
    }
}
