using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invaders;

public static class Vector2Extensions
{
    public static Vector2f Normalize(this Vector2f vector)
    {
        var length = (float)Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        if (length != 0)
        {
            vector /= length; // Данная запись равна - vector = new Vector2f(vector.X / length, vector.Y / length);
        }

        return vector;
    }
}