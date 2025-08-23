using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    internal class Sprite2D : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        private Texture STexture { get; set; }
        private Vector2 FrameSize { get; set; }
        public Sprite ImageSprite { get; set; }

        public Sprite2D(string TexturePath,Vector2 position,Vector2 frameSize,Vector2 scale,string tag)
        {
            this.Position = position;
            this.FrameSize = frameSize;
            this.Scale = scale;
            this.Tag = tag;

            try
            {
                STexture = new Texture(TexturePath);
            }catch(Exception ex)
            {
                Log.Error($"texture path not found {TexturePath}");

            }

            this.ImageSprite = new Sprite(this.STexture);
            this.Origin = new Vector2(0.5f, 0.5f) * frameSize;
        }

        public override void OnDestroy()
        {
            
        }

        public override void OnLoad()
        {
            
        }

        public override void OnUpdate()
        {
            this.ImageSprite.Position = this.Position;
            this.ImageSprite.Scale = this.Scale;
            Engine.APP.Draw(this.ImageSprite);
        }
    }
}
