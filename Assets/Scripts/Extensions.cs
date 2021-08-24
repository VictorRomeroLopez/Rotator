using UnityEngine;

public static class Extensions
{
    public static int mod(this int a,int b)
    {
        return (a%b + b)%b;
    }
}