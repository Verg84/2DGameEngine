using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    abstract class Level
    {
        abstract public string LevelName { get; set; }
        abstract public bool LevelInit { get; set; }
        
        public Level(string levelName)
        {
            this.LevelName = levelName;
            this.LevelInit = false;

            LevelManager.AllLevels.Add(this);
        }

        public virtual void OnDestroy()
        {
            foreach (GameObject obj in Engine.GameObjects)
                obj.DestroySelf();
        }

        abstract public void OnLoad();
        abstract public void OnUpdate();

    }
}
