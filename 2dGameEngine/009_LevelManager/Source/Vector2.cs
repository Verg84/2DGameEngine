using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    internal class Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }

        public Vector2()
        {
            this.x = Zero().x;
            this.y = Zero().y;
        }

        public Vector2 Normalize()
        {
            float num1 = (float)Math.Sqrt(x * x + y * y);
            float num2 = 1f / num1;
            return new Vector2(x * num2, y * num2);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }
        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static implicit operator SFML.System.Vector2f(Vector2 v)
        {
            return new SFML.System.Vector2f(v.x, v.y);
        }

    }
}
