using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public static class GameObjectExtensions
{
    /// <summary>
    /// Returns the colliders attached to this GameObject.
    /// </summary>
    public static Collider2D[] GetAttachedColliders2D(this GameObject gameObject)
    {
        // Initialize
        List<Collider2D> colliders = new List<Collider2D>();
        Collider2D[] components = null;

        // Get Components in Root
        components = gameObject.GetComponents<Collider2D>();
        foreach (Collider2D item in components)
            colliders.Add(item);

        // Get Components in Children
        components = gameObject.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D item in components)
            colliders.Add(item);

        // Return
        return colliders.ToArray();
    }
}