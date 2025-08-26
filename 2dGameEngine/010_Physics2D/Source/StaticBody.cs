using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using nkast.Aether.Physics2D.Dynamics;

namespace GameEngine.Source
{
    internal class StaticBody : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public Body body { get; set; }
        public bool collisionDisabled=false;
        public bool collisionDebug = false;
        private Shape2D shape;

        public List<OnCollisionEventHandler> onCollisionEventHandlers = new List<OnCollisionEventHandler>();
        public List<OnSeparationEventHandler> onSeparationEventHandlers = new List<OnSeparationEventHandler>();

        public StaticBody(Vector2 position,Vector2 scale,string tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;

            // collision box
            shape = new Shape2D(Shape2D.SHAPES.RECTANGLE, this.Position, this.Scale, tag, Color.Transparent, Color.Transparent);
            
        }

        public override void OnDestroy()
        {
            shape.DestroySelf();

            if (Engine.world.BodyList.Contains(body))
                Engine.world.Remove(body);
        }

        public override void OnLoad()
        {
            // Create the body
            body = Engine.world.CreateBody();
            // Set the shape
            body.CreateRectangle(Scale.x, Scale.y, 1f, new Vector2());
            // Set body type
            body.BodyType = BodyType.Static;
            
            body.IgnoreGravity = true;

            // Collision handlers
            body.IgnoreCCD = collisionDisabled;
            // Add tag to the body
            body.FixtureList[0].Tag = this.Tag;

            onCollisionEventHandlers.Add(Body_OnCollision);
            onSeparationEventHandlers.Add(Body_OnSeperation);

            foreach(OnCollisionEventHandler handler in onCollisionEventHandlers)
            {
                body.OnCollision += handler;
            }

            foreach(OnSeparationEventHandler handler in onSeparationEventHandlers)
            {
                body.OnSeparation += handler;
            }
        }

        public override void OnUpdate()
        {
            Position = new Vector2(body.Position.X, body.Position.Y);
            shape.Position = Position;
        }

        public void CollisionDebug(bool debugValue)
        {
            collisionDebug = debugValue;
            if (collisionDebug)
                shape.ShapeColor = Color.Green;
            else
                shape.ShapeColor = Color.Transparent;
        }

        // Handling Collision Events
        private void Body_OnSeperation(Fixture sender,Fixture other,nkast.Aether.Physics2D.Dynamics.Contacts.Contact contact)
        {
        }

        private bool Body_OnCollision(Fixture sender, Fixture other, nkast.Aether.Physics2D.Dynamics.Contacts.Contact contact)
        {
            return true;
        }
    }
}
