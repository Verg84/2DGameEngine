using GameEngine.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace GameEngine
{
    internal class DemoLevel : Level
    {
        public override string LevelName { get; set; }
        public override bool LevelInit { get; set; }

        public Color ShapeColor { get; set; }

        public DemoLevel(string levelName,Color shapeColor):base(levelName)
        {
            this.ShapeColor = shapeColor;
        }
        public override void OnLoad()
        {
            Shape2D shape = new Shape2D(Shape2D.SHAPES.RECTANGLE, new Vector2(500, 500), new Vector2(50, 50), "LevelShape", ShapeColor, ShapeColor);
        }

        public override void OnUpdate()
        {
        }
    }
}
