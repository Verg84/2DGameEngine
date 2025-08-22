using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

namespace GameEngine.Source
{
    abstract class Engine
    {
        public uint WIDTH;
        public uint HEIGHT;
        public string TITLE;
        public Color COLOR;

        public static RenderWindow APP;

        public Engine(uint width,uint height,string title,Color color)
        {
            this.WIDTH = width;
            this.HEIGHT = height;
            this.TITLE = title;
            this.COLOR = color;

            APP = new RenderWindow(
                new VideoMode(this.WIDTH, this.HEIGHT),
                this.TITLE,
                style: Styles.Close | Styles.Resize);

            APP.Closed += APP_Closed;
            APP.Resized += APP_Resized;

            APP.KeyPressed += APP_KeyPressed;
            APP.KeyReleased += APP_KeyReleased;

            APP.SetFramerateLimit(114);

            GameLoop();
        }

        private void APP_KeyReleased(object? sender, KeyEventArgs e)
        {
            Input.GetKeyUp(e);
        }

        private void APP_KeyPressed(object? sender, KeyEventArgs e)
        {
            Input.GetKeyDown(e);
        }

        private void APP_Resized(object? sender, SizeEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            FloatRect visibleArea = new FloatRect(0, 0, e.Width, e.Height);
            window.SetView(new View(visibleArea));
        }

        private void APP_Closed(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        void GameLoop()
        {
            while(APP.IsOpen)
            {
                APP.DispatchEvents();
                APP.Clear(this.COLOR);

                OnUpdate();

                APP.Display();
            }
        }

        public virtual void OnUpdate()
        {
            if (Input.ActionPressed("Down"))
                Log.Info("Key just pressed");
            if (Input.ActionPressing("Up"))
                Log.Info("Key Pressing");
        }
    }
}
