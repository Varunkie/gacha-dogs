using UnityEngine;

public static class LayerMaskExtensions
{
    /// <summary>
    /// Returns true when this layer mask contains the layer.
    /// </summary>
    /// <param name="layer">Layer to check.</param>
    public static bool Contains(this LayerMask layermask, int layer)
    {
        return layermask == (layermask | (1 << layer));
    }
}
