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

        AnimatedSprite2D animator;
        Camera cam;

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
            animator = new AnimatedSprite2D(0.5f, new Vector2(4, 4), "Player graphics");
            Animation2D run = new Animation2D("Assets/Run.png", new Vector2(16, 16), 4);
            Animation2D idle = new Animation2D("Assets/Idle.png", new Vector2(16, 16), 1);
            animator.AddAnimation("Run", run);
            animator.AddAnimation("Idle", idle);
            AddChild(animator);

            cam = new Camera(true, "Player's Camera");
            AddChild(cam);

        }

        public override void OnUpdate()
        {
            if (Input.ActionPressing("Right"))
            {
                animator.Play("Run");
                animator.FlipH = 1;
                Position.x += 1 * Time.deltaTime * 300f;
            }

            else if (Input.ActionPressing("Left"))
            {
                animator.Play("Run");
                animator.FlipH = -1;
                Position.x -= 1 * Time.deltaTime * 300f;

            }

            else
                animator.Play("Idle");
        }
    }
}
