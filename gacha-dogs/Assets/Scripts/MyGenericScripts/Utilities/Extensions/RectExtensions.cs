using UnityEngine;

public static class RectExtensions
{
    /// <summary>
    /// Add to the rect an virtual margin.
    /// </summary>
    public static Rect Margin(this Rect rect, float x, float y)
    {
        rect.x += x; rect.width -= x;
        rect.y += y; rect.height -= y;
        return rect;
    }

    /// <summary>
    /// Translate the origin of the rectangle.
    /// </summary>
    /// <param name="rect">Rectangle to translate.</param>
    /// <param name="origin">Position of the origin.</param>
    /// <returns>Returns the translated rectangle.</returns>
    public static Rect Translate(this Rect rect, OriginType origin, Vector2 pivot = default(Vector2))
    {
        switch(origin)
        {
            case OriginType.Bottom:
                return Bottom(rect, pivot);
            case OriginType.Center:
                return Center(rect);
        }
        return rect;
    }

    /// <summary>
    /// Translate the origin of the rectangle to the bot.
    /// </summary>
    /// <param name="rect">Rectangle to translate.</param>
    /// <returns>Returns the translated rectangle.</returns>
    private static Rect Bottom(Rect rect, Vector2 pivot)
    {
        rect.y -= rect.height;
        if (pivot.x == 0f)
            rect.x -= rect.width / 2f;
        else
            rect.x -= pivot.x;
        return rect;
    }

    /// <summary>
    /// Translate the origin of the rectangle to the center.
    /// </summary>
    /// <param name="rect">Rectangle to translate.</param>
    /// <returns>Returns the translated rectangle.</returns>
    private static Rect Center(Rect rect)
    {
        rect.x -= rect.width / 2;
        rect.y -= rect.height / 2;
        return rect;
    }
}

/// <summary>
/// Position of the origin related to the size of the shape.
/// </summary>
public enum OriginType
{
    Bottom,
    Center
}
