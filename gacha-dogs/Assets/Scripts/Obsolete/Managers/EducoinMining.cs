using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducoinMining : MonoBehaviour 
{
    public int coinsUp = 1;

    private float _timer;

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        _timer += Time.deltaTime;
        while (_timer >= PlayerManager.Instance.CoinRate)
        {
            _timer -= PlayerManager.Instance.CoinRate; Gain();
        }
    }

    private void Gain()
    {
        PlayerManager.Instance.AddCoins(coinsUp);
    }
}
