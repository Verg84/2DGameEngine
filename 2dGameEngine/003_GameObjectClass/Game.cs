using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameEngine.Source;
using SFML.Graphics;

namespace GameEngine
{
    internal class Game:Engine
    {
        TestObject testObject;
        
        public Game() : base((uint)800, (uint)800, "GAME OBJECT", Color.Black) { }

        

        public override void OnLoad()
        {
            testObject = new TestObject();
        }
    }
}
