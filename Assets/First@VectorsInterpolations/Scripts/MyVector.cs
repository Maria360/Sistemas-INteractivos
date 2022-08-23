using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct MyVector
{
    public float x;
    public float y;
    public float magnitude => Mathf.Sqrt(x * x + y * y);
    //public MyVector normalized => new MyVector(x / magnitude, y/magnitude); 
    public MyVector normalized
    {
        get
        {
            float distance = magnitude;
            if (distance < 0.0001f)
            {
                return new MyVector(0, 0);
            }
            return new MyVector(x / distance, y / distance);
        }
    }
    public MyVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return $"[{x},{y}]";
    }
    public static implicit operator Vector3(MyVector a)
    {
        return new Vector3(a.x, a.y, 0);
    }
    
    public void Draw(Color color)
    {
        Debug.DrawLine(new Vector3(0, 0, 0), this, color,0);

    }
    public void Draw2(MyVector origin,Color color)
    {
        Debug.DrawLine(origin, this + origin, color, 0);

    }
    public MyVector Lerp(MyVector myVector, float t)
    {
        return this + (myVector - this) * t;
    }
    public void Normalize()
    {
        float magnitudeCache = magnitude;
        if (magnitudeCache < 0.001)
        {
            x = 0;
            y = 0;
        }
        else
        {
            x = x / magnitudeCache;
            y = y / magnitudeCache;
        }
    }
    public static MyVector operator+(MyVector v1, MyVector v2)
    {
        return new MyVector(v1.x + v2.x, v1.y + v2.y);

    }
    public static MyVector operator -(MyVector v1, MyVector v2)
    {
        return new MyVector(v1.x - v2.x, v1.y - v2.y);

    }
    public static MyVector operator *(MyVector v1, float n)
    {
        return new MyVector(v1.x * n, v1.y * n);

    }
    public static implicit operator MyVector(Vector3 a)
    {
        return new MyVector(a.x, a.y);
    }


}
