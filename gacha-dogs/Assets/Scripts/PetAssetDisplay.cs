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
    private PetInventoryDisplay _inventory;
    private Color _originalColor;
    private int _index;

    private void Awake()
    {
        _inventory = GetComponentInParent<PetInventoryDisplay>();
        _index = -1; 
    }

    private void Start()
    {
        _originalColor = background.color;

        Populate();
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
            background.color = Color.red;
            buttonText.text = "Unselect";
        }
        else
        {
            background.color = _originalColor;
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
        }
        else
        {
            PlayerManager.Instance.Pets.Add(_index);
        }

        Populate();
    }
}
