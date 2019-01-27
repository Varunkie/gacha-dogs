using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLoveGUI : MonoBehaviour
{
    public Text component;

    private void Start()
    {
        PlayerManager.Instance.LoveChanged += Player_ValueChanged;
        Initialize();
    }

    private void Initialize()
    {
        Format(PlayerManager.Instance.Love);
    }

    private void Format(int value)
    {
        component.text = value.ToString();
    }

    private void Player_ValueChanged(object sender)
    {
        Format(PlayerManager.Instance.Love);
    }
}

