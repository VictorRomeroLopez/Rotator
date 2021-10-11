using System;
using UnityEngine;

public struct CellPosition
{
    public readonly float x;
    public readonly float y;

    public Vector2 Vector => new Vector2(x, y);
    
    public CellPosition(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    
    public CellPosition(Vector2 initialPosition)
    {
        x = initialPosition.x;
        y = initialPosition.y;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is CellPosition cellPosition))
        {
            return false;
        }

        return Math.Abs(x - cellPosition.x) < Mathf.Epsilon && Math.Abs(y - cellPosition.y) < Mathf.Epsilon;
    }

    public override int GetHashCode()
    {
        return (x.GetHashCode() * 397) ^ y.GetHashCode();
    }
}