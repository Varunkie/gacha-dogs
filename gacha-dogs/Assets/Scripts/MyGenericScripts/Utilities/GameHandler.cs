using System;
using UnityEngine;

public delegate void GameEventHandler(object sender, GameEventArgs e);
public class GameEventArgs : EventArgs
{
    public GameEventArgs()
    {

    }
}

public delegate void CollisionHandler(object sender, Collider2D collider);