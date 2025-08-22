using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Source;

using SFML.Graphics;

namespace GameEngine
{
    internal class Game : Engine
    {
        Shape2D shape;

        public Game() : base((uint)800, (uint)800, "SHAPE 2D", Color.Black) { }
        public override void OnLoad()
        {
            shape = new Shape2D(
                Shape2D.SHAPES.RECTANGLE, 
                new Vector2(500,500), 
                new Vector2(45, 45), 
                "ShapeObject",
                Color.Transparent,
                Color.Green);



        }
    }
}
