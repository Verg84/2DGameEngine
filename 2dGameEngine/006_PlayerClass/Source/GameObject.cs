using GameEngine.Source;
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
            this.Children = new List<GameObject>();
            this.Position = new Vector2();
            this.Origin = Position;
            this.Scale = new Vector2();
            this.Tag = "EmptyGameObject";

            Engine.RegisterGameObject(this);
            
        }

        virtual public void AddChild(GameObject child)
        {
            this.Children.Add(child);
        }

        virtual public void RemoveGameObject(GameObject child)
        {
            if (this.Children.Contains(child))
                Children.Remove(child);
            child.DestroySelf();
        }
        
        virtual public void DestroySelf()
        {
            Engine.UnRegisterGameObject(this);
            foreach (GameObject child in Children)
                child.DestroySelf();
        }

        virtual public GameObject GetChildByTag(string tag)
        {
            foreach (GameObject child in Children)
            {
                if (child.Tag == tag)
                    return child;
            }
            Log.Error($"GameObject {tag} doesn't exists");
            return null;
        }

        virtual public void UpdateChildren()
        {
            foreach (GameObject child in Children)
                child.Position = Position + child.Origin;
        }

        abstract public void OnUpdate();
        abstract public void OnDestroy();
        abstract public void OnLoad();

    }
}
