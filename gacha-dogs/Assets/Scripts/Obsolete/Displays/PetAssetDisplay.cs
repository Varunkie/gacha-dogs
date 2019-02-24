using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetAssetDisplay : MonoBehaviour
{
    public TextMeshProUGUI description;

    public Image texture;
    public Image background;
    public Text buttonText;

    [SerializeField] private PetAsset _asset;
    private Color _prevColor;
    private int _index;

    private PetControllerDisplay _display;

    private void Awake()
    {
        _display = FindObjectOfType<PetControllerDisplay>();
    }

    private void Populate()
    {
        if (_asset != null)
            Display();
        else
            gameObject.SetActive(false);
    }

    private void Display()
    {
        if (!gameObject.activeInHierarchy)
            gameObject.SetActive(true);

        texture.sprite = _asset.sprite;
        description.text = _asset.description;

        if (PlayerManager.Instance.Pets.Contains(_index))
        {
            if (background.color != Color.red)
                _prevColor = background.color;
            background.color = Color.red;
            buttonText.text = "Unselect";
        }
        else
        {
            if (background.color == Color.red)
                background.color = _prevColor;
            buttonText.text = "Select";
        }
    }

    public void SetPetAsset(PetAsset asset, int index)
    {
        _asset = asset;
        _index = index;

        Populate();
    }

    public void ButtonSelected()
    {
        if (PlayerManager.Instance.Pets.Contains(_index))
        {
            PlayerManager.Instance.Pets.Remove(_index);
            Populate(); _display.Populate();
        }
        else if (PlayerManager.Instance.Pets.Count < 4)
        {
            PlayerManager.Instance.Pets.Add(_index);
            Populate(); _display.Populate();
        }
    }
}
