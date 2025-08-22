using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;

namespace GameEngine.Source
{
    internal class Input
    {
        public static Dictionary<string, InputAction> AllInputActions = new Dictionary<string, InputAction>();

        public static InputAction Left = new InputAction("Left", Keyboard.Key.A, Keyboard.Key.Left);
        public static InputAction Right = new InputAction("Right", Keyboard.Key.D, Keyboard.Key.Right);
        public static InputAction Up = new InputAction("Up", Keyboard.Key.W, Keyboard.Key.Up);
        public static InputAction Down = new InputAction("Down", Keyboard.Key.S, Keyboard.Key.Down);

        public static bool ActionPressing(string actionName)
        {
            if (AllInputActions.ContainsKey(actionName))
                return AllInputActions[actionName].Pressing;
            else
                Log.Error($"InputAction {actionName} doesn't exist");
            return false;

        }

        public static bool ActionPressed(string actionName)
        {
            if (AllInputActions.ContainsKey(actionName))
            {
                if (!AllInputActions[actionName].Pressed && AllInputActions[actionName].Pressing)
                {
                    AllInputActions[actionName].Pressed = true;
                    return AllInputActions[actionName].Pressed;
                }
            }
            else
                Log.Error($"InputAction {actionName} doesn't exist");
            return false;
        }

        public static void GetKeyUp(KeyEventArgs e)
        {
            foreach(InputAction action in AllInputActions.Values)
            {
                if(action.PrimKey==e.Code || (action.SecKey!=Keyboard.Key.Unknown) && action.SecKey==e.Code)
                {
                    action.Pressing = false;
                    action.Pressed = false;
                }
            }
        }

        public static void GetKeyDown(KeyEventArgs e)
        {
            foreach(InputAction action in AllInputActions.Values)
            {
                if(action.PrimKey==e.Code || (action.SecKey!=Keyboard.Key.Unknown && action.SecKey==e.Code))
                {
                    action.Pressing = true;
                }
            }
        }

    }
}
