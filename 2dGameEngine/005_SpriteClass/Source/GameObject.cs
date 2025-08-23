using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    abstract class GameObject
    {
        abstract public Vector2 Position { get; set; }
        abstract public Vector2 Origin { get; set; }
        abstract public Vector2 Scale { get; set; }
        abstract public string Tag { get; set; }
        abstract public List<GameObject> Children { get; set; }

        public GameObject()
        {
            this.Position = new Vector2();
            this.Origin = this.Position;
            this.Scale = new Vector2();
            this.Tag = "EmptyGameObject";
            this.Children = new List<GameObject>();

            Engine.RegisterGameObject(this);
        }

        public virtual void AddChild(GameObject child)
        {
            this.Children.Add(child);
        }

        public virtual void UpdateChildren()
        {
            foreach (GameObject child in Children)
                child.Position = this.Position + child.Origin;
        }

       public virtual void DestroySelf()
        {
            Engine.UnregisterGameObject(this);

            if (Children == null)
                return;
            foreach(GameObject child in Children)
            {
                child.DestroySelf();
            }
        }

        public virtual void DestroyChild(GameObject child)
        {
            if (Children.Contains(child))
                Children.Remove(child);
            child.DestroySelf();
        }

        public virtual GameObject GetChild(string tag)
        {
            foreach(GameObject child in Children)
            {
                if (child.Tag == tag)
                    return child;
            }
            Log.Info($"GameObject {tag} doesn't exist...");
            return null;
        }

        abstract public void OnDestroy();
        abstract public void OnLoad();
        abstract public void OnUpdate();

    }
}
