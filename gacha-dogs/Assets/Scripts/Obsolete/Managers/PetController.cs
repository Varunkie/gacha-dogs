using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour 
{
    public int loveUp = 1;
    public int coinUp = 0;

    public ParticleSystem particle;
    public PlayOneShotAudioSource _audio;

    private SpriteRenderer _renderer;
    private PetAsset _asset;

    private float _idleTimer;
    private bool _isSecondSprite;

    private float _gainTimer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _audio = GetComponentInChildren<PlayOneShotAudioSource>();
    }

    private void Update()
    {
        AnimationTimer();
        GainRateTimer();
    }

    private void AnimationTimer()
    {
        if (_asset.sprite2 != null)
        {
            _idleTimer += Time.deltaTime;
            if (_idleTimer > _asset.idleTime)
            {
                _idleTimer = 0f;
                if (_isSecondSprite)
                    _renderer.sprite = _asset.sprite;
                else
                    _renderer.sprite = _asset.sprite2;
                _isSecondSprite = !_isSecondSprite;
            }
        }
    }

    private void GainRateTimer()
    {
        _gainTimer += Time.deltaTime;
        while (_gainTimer > 1f)
        {
            _gainTimer -= 1f;
            PlayerManager.Instance.AddCoinsWithoutModifiers(_asset.coinBySecond);
            PlayerManager.Instance.AddLoveWithoutModifiers(_asset.loveBySecond);
        }
    }

    public void SetPetAsset(PetAsset pet)
    {
        _asset = pet;
        _idleTimer = 0f;
        _isSecondSprite = false;
        _gainTimer = 0f;

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
            PlayerManager.Instance.AddCoinsWithoutModifiers(coinUp);
            PlayerManager.Instance.AddLove(loveUp);

            particle.Play();

            _audio.Play();
        }
    }
}
