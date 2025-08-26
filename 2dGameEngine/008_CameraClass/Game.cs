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
        Player player;

        Shape2D cubeA;
        Shape2D cubeB;
        public Game():base((uint)800,(uint)800,"ANIMATION 2D",Color.Black){}
        public override void OnLoad()
        {
            player = new Player(new Vector2(400, 400), new Vector2(), "player");
            cubeA = new Shape2D(Shape2D.SHAPES.RECTANGLE, new Vector2(400, 350), new Vector2(15, 15), "CUBE001", Color.Blue, Color.Green);
            cubeB = new Shape2D(Shape2D.SHAPES.RECTANGLE, new Vector2(450, 350), new Vector2(15, 15), "CUBE001", Color.Green, Color.Blue);

        }
    }
}
