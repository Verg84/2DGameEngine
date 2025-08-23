using GameEngine.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    internal class Player : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public Player(Vector2 position,Vector2 scale,string tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;
        }

        public override void OnDestroy()
        {
        }

        public override void OnLoad()
        {
            Sprite2D player_sprite = new Sprite2D(
                "Assets/idle.png", 
                new Vector2(), 
                new Vector2(16, 16), 
                new Vector2(4, 4), 
                "Player Sprite"
                );
            AddChild(player_sprite);
        }

        public override void OnUpdate()
        {
            if (Input.ActionPressed("Left"))
                this.Position.x -= 10;
            if (Input.ActionPressed("Right"))
                this.Position.x += 10;
        }
    }
}
