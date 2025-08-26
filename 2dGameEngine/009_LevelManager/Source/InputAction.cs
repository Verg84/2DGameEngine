using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    internal class InputAction
    {
        public string ActionName { get; set; }
        public Keyboard.Key PrimKey { get; set; }
        public Keyboard.Key SecKey { get; set; }

        public bool Pressing = false;
        public bool Pressed = false;

        public InputAction(string name,Keyboard.Key primKey,Keyboard.Key secKey)
        {
            this.ActionName = name;
            this.PrimKey = primKey;
            this.SecKey = secKey;

            Input.AllInputActions.Add(this.ActionName, this);
        }
    }
}
