using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FacilityUpgradeDisplay : MonoBehaviour
{
    public TextMeshProUGUI description;
    public Image loveImage;
    public Text loveCost;
    public Text coinCost;
    public Image texture;

    [SerializeField] private FacilityUpgrade _upgrade;
    private ShowDisplay _show;
    private int _index;

    private void Awake()
    {
        _show = GetComponentInParent<ShowDisplay>();
        _index = -1;
    }

    private void Start()
    {
        Populate();
    }

    private void Populate()
    {
        if (_upgrade != null)
            Display();
        else
            gameObject.SetActive(false);
    }

    private void Display()
    {
        if (!gameObject.activeInHierarchy)
            gameObject.SetActive(true);

        texture.sprite = _upgrade.sprite;
        description.text = _upgrade.description;

        if (_upgrade.loveCost <= 0)
        {
            loveCost.gameObject.SetActive(false);
            loveImage.gameObject.SetActive(false);
        }
        else
        {
            loveCost.gameObject.SetActive(true);
            loveImage.gameObject.SetActive(true);
        }

        loveCost.text = _upgrade.loveCost.ToString();
        coinCost.text = _upgrade.coinCost.ToString(); 
    }

    public void SetFacilityUpgrade(FacilityUpgrade upgrade, int index)
    {
        _upgrade = upgrade;
        _index = index;

        Populate();
    }

    public void BuyFacilityUpgrade()
    {
        _show.Buy(_upgrade, _index);
    }
}
