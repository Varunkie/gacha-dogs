using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour 
{
    public int loveUp = 1;
    public int coinUp = 0;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetPetAsset(PetAsset pet)
    {
        if (pet != null)
        {
            loveUp = pet.loveUp;
            coinUp = pet.coinUp;

            _renderer.sprite = pet.sprite;
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnMouseUp()
    {
        if (PlayerManager.Instance.MenuState == PlayerMenuState.Home)
        {
            PlayerManager.Instance.AddCoins(coinUp);
            PlayerManager.Instance.AddLove(loveUp);
        }
    }
}
