using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<PetAsset> PetInventory;
    public float defaultCoinRate = 1f;

    [SerializeField, ReadOnly] private float _coinRateUp;
    [SerializeField, ReadOnly] private int _coinBonusUp;
    [SerializeField, ReadOnly] private int _loveBonusUp;

    public event GameEventHandler LoveChanged;
    public event GameEventHandler CoinChanged;

    private int _love;
    private int _coins;

    #region Properties
    public static PlayerManager Instance
    {
        get;
        private set;
    }

    public List<int> Pets
    {
        get;
        private set;
    }

    public PlayerMenuState MenuState
    {
        get;
        set;
    }

    public int Love
    {
        get { return _love; }
        private set
        {
            if (_love != value)
            {
                _love = value; OnLoveChange();
            }
        }
    }

    public int Coins
    {
        get { return _coins; }
        private set
        {
            if (_coins != value)
            {
                _coins = value; OnCoinChange();
            }
        }
    }

    public float CoinRate
    {
        get { return Mathf.Clamp(defaultCoinRate - _coinRateUp, 0.1f, 2f); }
    }
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<PlayerManager>();
            Pets = new List<int>();
            if (PetInventory.Count > 0)
                Pets.Add(0);
            DontDestroyOnLoad(Instance);
        }
        else
            Destroy(this);
    }

    public void AddLove(int value)
    {
        Love += value + _loveBonusUp;
    }

    public void RemoveLove(int value)
    {
        Love -= value;
    }

    public void AddCoins(int value)
    {
        Coins += value + _coinBonusUp;
    }

    public bool BuyFacility(FacilityUpgrade upgrade)
    {
        if (Coins >= upgrade.coinCost && Love >= upgrade.loveCost)
        {
            Coins -= upgrade.coinCost;
            Love -= upgrade.loveCost;

            _coinBonusUp += upgrade.coinBonusUp;
            _loveBonusUp += upgrade.loveBonusUp;
            _coinRateUp += upgrade.coinBonusRateUp;

            return true;
        }
        return false;
    }

    private void OnLoveChange()
    {
        if (LoveChanged != null)
            LoveChanged(this);
    }

    private void OnCoinChange()
    {
        if (CoinChanged != null)
            CoinChanged(this);
    }
}

public delegate void GameEventHandler(object sender);

public enum PlayerMenuState
{
    Home,
    Pull,
    Shop,
    Pets,
    Pulling
}