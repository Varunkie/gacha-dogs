using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour 
{
    public int loveUp = 1;

    private void OnMouseUp()
    {
        if (PlayerManager.Instance.MenuState == PlayerMenuState.Home)
            PlayerManager.Instance.AddLove(loveUp);
    }
}
