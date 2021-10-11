using UnityEngine;

public static class Extensions
{
    public static int mod(this int a,int b)
    {
        return (a%b + b)%b;
    }
    public static float mod(this float a,float b)
    {
        return (a%b + b)%b;
    }

    public static Vector2 Round(this Vector2 vector)
    {
        vector.x = Mathf.Round(vector.x);
        vector.y = Mathf.Round(vector.y);
        return vector;
    }
}