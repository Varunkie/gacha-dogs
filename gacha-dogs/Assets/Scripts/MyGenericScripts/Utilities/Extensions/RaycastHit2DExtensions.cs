using UnityEngine;

public static class RaycastHit2DExtensions
{
    /// <summary>
    /// Returns the unsinged angle in degrees between the normal and the vertical axis.
    /// </summary>
    public static float Angle(this RaycastHit2D raycast)
    {
        return Vector2.Angle(raycast.normal, Vector2.up);
    }

    /// <summary>
    /// Returns the angle in degrees between the normal and the vertical axis.
    /// </summary>
    public static float SignedAngle(this RaycastHit2D raycast)
    {
        return Vector2.SignedAngle(raycast.normal, Vector2.up);
    }
}
