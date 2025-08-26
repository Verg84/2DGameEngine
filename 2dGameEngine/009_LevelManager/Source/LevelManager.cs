using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    internal class LevelManager
    {
        public static List<Level> AllLevels = new List<Level>();
        public static Level CurrentLevel = null;

        public static void SwitchLevel(string levelName)
        {
            foreach(Level level in AllLevels)
            {
                if (level.LevelName == levelName)
                {
                    if(CurrentLevel!=null)
                    {
                        CurrentLevel.OnDestroy();
                    }
                    CurrentLevel = level;
                    InitLevel();
                    return;
                }
            }
            Log.Error($"Level {levelName} Does not exist...");
        }

        public static void InitLevel()
        {
            Log.Info("Loading Level :" + CurrentLevel.LevelName);
            if(CurrentLevel.LevelInit)
            {
                CurrentLevel.OnDestroy();
            }
            CurrentLevel.OnLoad();
        }

        public static void UpdateLevel()
        {
            if (CurrentLevel == null)
                return;
            CurrentLevel.OnUpdate();
        }
    }
}
