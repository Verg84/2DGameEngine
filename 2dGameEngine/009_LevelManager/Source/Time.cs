using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    internal class Time
    {
        public static Clock TimeClock = new Clock();
        public static float deltaTime;

        public static void UpdateTime()
        {
            deltaTime = TimeClock.Restart().AsSeconds();
        }
    }
}
