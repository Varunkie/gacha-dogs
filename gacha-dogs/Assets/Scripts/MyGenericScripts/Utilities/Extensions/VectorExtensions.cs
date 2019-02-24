using UnityEngine;

public static class VectorExtensions
{
    /// <summary>
    /// Returns this Vector3 as Vector2.
    /// </summary>
    public static Vector2 Vector2(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.y);
    }

    /// <summary>
    /// Returns this Vector2 as Vector3.
    /// </summary>
    public static Vector3 Vector3(this Vector2 vector)
    {
        return Vector3(vector, 0f);
    }

    /// <summary>
    /// Returns this Vector2 as Vector3.
    /// </summary>
    public static Vector3 Vector3(this Vector2 vector, float z)
    {
        return new Vector3(vector.x, vector.y, z);
    }

    /// <summary>
    /// Returns true when the other position is too far from this vector.
    /// </summary>
    public static bool FarAway(this Vector3 position, Vector3 otherPosition, Vector2 distance)
    {
        return (distance.x - Mathf.Abs(position.x - otherPosition.x) <= 0
                || distance.y - Mathf.Abs(position.y - otherPosition.y) <= 0);
    }

    /// <summary>
    /// Returns the direction of the vector as unit signed vector.
    /// </summary>
    public static Vector2 GetSigned(this Vector2 vector)
    {
        Vector2 direction = UnityEngine.Vector2.zero;
        if (vector.x > 0)
            direction.x = 1;
        else if (vector.x < 0)
            direction.x = -1;
        if (vector.y > 0)
            direction.y = 1;
        else if (vector.y < 0)
            direction.y = -1;
        return direction;
    }

    /// <summary>
    /// Returns the negative direction of the vector.
    /// </summary>
    public static Vector2 GetNegative(this Vector2 vector)
    {
        float x = -vector.x; float y = -vector.y;
        return new Vector2(x, y);
    }
}