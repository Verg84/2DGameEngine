using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    internal class AnimatedSprite2D : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public float FrameTime { get; set; }
        public int FlipH = 1;
        public int FlipV = 1;

        public Animation2D CurrentAnimation{ get; set; }
        public string CurrentAnimationName { get; set; }

        private Dictionary<string, Animation2D> AllAnimations = new Dictionary<string, Animation2D>();
        private int currentFrame = 0;
        private float elapsedTime;

        private static float animationSpeed = 30.0f;

        public AnimatedSprite2D(float frameTime,Vector2 scale,string tag)
        {
            this.FrameTime = 1 / 10 * frameTime;
            this.Position = Vector2.Zero();
            this.Scale = scale;
            this.Tag = tag;
        }

        public void Play(string animationName)
        {
            if (animationName.Equals(CurrentAnimationName))
                return;
            if(AllAnimations.ContainsKey(animationName))
            {
                CurrentAnimation = AllAnimations[animationName];
                CurrentAnimationName = animationName;
                currentFrame = 0;
            }
            else
            {
                Log.Error($"Animation {animationName} doesn't exist");
            }
        }

        public void AddAnimation(string animationName,Animation2D animation)
        {
            AllAnimations.Add(animationName, animation);
            CurrentAnimation = animation;
            CurrentAnimationName = animationName;
        }

        public void RemoveAnimation(string animationName)
        {
            if(AllAnimations.ContainsKey(animationName))
            {
                AllAnimations.Remove(animationName);
            }
        }
        public override void OnDestroy()
        {
            
        }

        public override void OnLoad()
        {
           
        }

        public override void OnUpdate()
        {
            if (CurrentAnimation == null)
                return;
            elapsedTime += Time.deltaTime;
            if(elapsedTime>=FrameTime && CurrentAnimation.TotalFrames!=1)
            {
                currentFrame = (currentFrame == CurrentAnimation.TotalFrames - 1) ? 0 : currentFrame + 1;
                elapsedTime = 0;
            }
            CurrentAnimation.FrameRectangle = new IntRect((int)(currentFrame * CurrentAnimation.FrameSize.x), 0, (int)CurrentAnimation.FrameSize.x, (int)CurrentAnimation.FrameSize.y);
            CurrentAnimation.AnimSprite.Position = Position;
            CurrentAnimation.AnimSprite.Scale = new Vector2(Scale.x * FlipH, Scale.y * FlipV);

            CurrentAnimation.AnimSprite.TextureRect = CurrentAnimation.FrameRectangle;

            Engine.APP.Draw(CurrentAnimation.AnimSprite);
        }
    }
}
