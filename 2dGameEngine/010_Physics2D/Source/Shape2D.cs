using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace GameEngine.Source
{
    internal class Shape2D : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public enum SHAPES { RECTANGLE}

        public SHAPES Shape;
        public Color ShapeColor = Color.White;
        public Color OutlineColor = Color.White;
        public float OutlineThickness = 1.0f;

        public Shape2D(SHAPES shape,Vector2 position,Vector2 scale,string tag,Color shapeColor,Color outlineColor)
        {
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;

            this.Shape = shape;
            this.ShapeColor = shapeColor;
            this.OutlineColor = outlineColor;

            Log.Info($"GameObject {tag} registered");
        }

        public override void OnDestroy()
        {
            
        }

        public override void OnLoad()
        {
        }

        public override void OnUpdate()
        {
            if(this.Shape==SHAPES.RECTANGLE)
            {
                RectangleShape graphics = new RectangleShape(this.Scale);
                graphics.Position = this.Position;
                graphics.Origin = this.Scale * new Vector2(0.5f, 0.5f);

                graphics.FillColor = this.ShapeColor;
                graphics.OutlineColor = this.OutlineColor;
                graphics.OutlineThickness = this.OutlineThickness;

                Engine.APP.Draw(graphics);
                
            }
        }
    }
}
