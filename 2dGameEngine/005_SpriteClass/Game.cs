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
        Shape2D shape;
        Sprite2D sprite;

        public Game():base((uint)800,(uint)800,"SPRITE CLASS",Color.Black){}
        public override void OnLoad()
        {
            shape = new Shape2D(
                Shape2D.SHAPES.RECTANGLE,
                new Vector2(500, 500),
                new Vector2(30, 30),
                "SHAPE OBJECT",
                Color.Green,
                Color.Green);

            Sprite2D sprite = 
                new Sprite2D(
                    "Assets/idle.png", 
                    new Vector2(), new Vector2(16, 16), 
                    new Vector2(4, 4), "player's sprite");

        }
    }
}
