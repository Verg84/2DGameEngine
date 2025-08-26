using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    internal class Animation2D
    {
        public Sprite AnimSprite { get; set; }
        public Texture SpriteTexture { get; set; }
        public Vector2 FrameSize { get; set; }
        public int TotalFrames { get; set; }

        public string Tag { get; set; }

        public IntRect FrameRectangle { get; set; }

        public Animation2D(string spriteSheetPath,Vector2 frameSize,int totalFrames)
        {
            this.FrameSize = frameSize;
            this.TotalFrames = totalFrames;
            try
            {
                this.SpriteTexture = new Texture(spriteSheetPath);
            }catch(Exception ex)
            {
                Log.Error($"SpriteSheet {spriteSheetPath} was not found::\nERROR::{ex}");
            }

            this.AnimSprite = new Sprite(SpriteTexture);
            this.FrameRectangle = new IntRect((int)this.FrameSize.x, 0, (int)FrameSize.x, (int)FrameSize.y);

            this.AnimSprite.Origin = this.FrameSize * new Vector2(0.5f, 0.5f);

            Log.Info($"animation 2d registered");
        }

    }
}
