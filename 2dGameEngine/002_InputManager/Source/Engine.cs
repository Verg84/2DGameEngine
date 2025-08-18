using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameEngine.Source
{
    abstract class Engine
    {
        public uint width;
        public uint height;
        public string title = "Game Engine";
        public Color windowColor;
        public static RenderWindow app;

        public Engine(uint WIDTH,uint HEIGHT,string TITLE,Color COLOR)
        {
            this.width = WIDTH;
            this.height = HEIGHT;
            this.title = TITLE;
            this.windowColor = COLOR;

            app = new RenderWindow(
                new VideoMode(width, height),
                title,
                style: Styles.Resize | Styles.Close
                );

            app.SetFramerateLimit(114);

            app.KeyPressed += App_KeyPressed;
            app.KeyReleased += App_KeyReleased;
            app.Closed += App_Closed;
            app.Resized += App_Resized;
            
            GameLoop();

        }

        private void App_Resized(object? sender, SizeEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            FloatRect visibleArea = new FloatRect(0, 0, width, height);
            window.SetView(new View(visibleArea));
        }

        private void App_Closed(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        private void App_KeyReleased(object? sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void App_KeyPressed(object? sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        void GameLoop()
        {
            OnLoad();
            while (app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(windowColor);

               

                OnUpdate();

                app.Display();
            }
        }

        public virtual void OnUpdate()
        {
            RectangleShape shape = new RectangleShape(new Vector2f(500, 500));
            shape.FillColor = Color.Green;
            shape.Position = new Vector2f(40, 40);
            app.Draw(shape);
        }

        public abstract void OnLoad();
    }
}
