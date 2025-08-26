using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    internal class Camera : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        View CameraView = Engine.Camera;
        bool CurrentCamera = false;
        
        public Camera(string tag)
        {
            this.Position = new Vector2(Engine.Camera.Center.X, Engine.Camera.Center.Y);
            this.Scale = new Vector2(Engine.Camera.Size.X, Engine.Camera.Size.Y);
            this.Tag = tag;

            Engine.AllCameras.Add(this);

            Log.Info($"Camera {tag} created");
        }

        public Camera(bool current,string tag)
        {
            this.Position = new Vector2(Engine.Camera.Center.X, Engine.Camera.Center.Y);
            this.Scale = new Vector2(Engine.Camera.Size.X, Engine.Camera.Size.Y);
            this.Tag = tag;
            this.CurrentCamera = current;

            if(CurrentCamera)
            {
                foreach(Camera camera in Engine.AllCameras)
                {
                    if (camera.CurrentCamera)
                    {
                        camera.CurrentCamera = false;
                    }
                }
                Engine.AllCameras.Add(this);

                Log.Info($"Camera {tag} created");
            }    
        }

        public void MakeCurrent()
        {
            foreach (Camera camera in Engine.AllCameras)
            {
                if(camera.CurrentCamera)
                {
                    camera.CurrentCamera = false;
                }
            }
            this.CurrentCamera = true;

        }

        public override void OnDestroy()
        {
            Engine.AllCameras.Remove(this);
        }

        public override void OnLoad()
        {
            
        }

        public override void OnUpdate()
        {
            if(CurrentCamera)
            {
                CameraView.Center = Position;
                CameraView.Size = Scale;
                Engine.APP.SetView(CameraView);
            }
        }
    }
}
