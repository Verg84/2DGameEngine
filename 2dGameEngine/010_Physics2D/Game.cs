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
        public Game():base((uint)800,(uint)800,"PHYSICS 2D",Color.Black){}
        public override void OnLoad()
        {
            player = new Player(new Vector2(400, 400), new Vector2(), "player");
            player.CollisionDebug(true);


            DemoLevel level1 = new DemoLevel("LEVEL001", Color.Blue);
            DemoLevel level2 = new DemoLevel("LEVEL002",Color.Yellow);
            LevelManager.SwitchLevel("LEVEL001");
        }

        public override void OnUpate()
        {
            if (Input.ActionPressed("Up"))
                LevelManager.SwitchLevel("LEVEL002");
            if (Input.ActionPressed("Down"))
                LevelManager.SwitchLevel("LEVEL001");
            base.OnUpate();
        }
    }
}
