using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class MenuButtonHandler : MonoBehaviour
    {
        private static GameObject _currentGameObject;

        public GameObject _gameObject;
        public PlayerMenuState _state;

        public void ChangeMenu()
        {
            if (PlayerManager.Instance.MenuState != PlayerMenuState.Pulling)
            {
                if (PlayerManager.Instance.MenuState != _state)
                {
                    if (_currentGameObject != null)
                        _currentGameObject.SetActive(false);
                    if (_gameObject != null)
                        _gameObject.SetActive(true);
                    _currentGameObject = _gameObject;
                    PlayerManager.Instance.MenuState = _state;
                }
                else
                {
                    if (_currentGameObject != null)
                        _currentGameObject.SetActive(false);
                    _currentGameObject = null;
                    PlayerManager.Instance.MenuState = PlayerMenuState.Home;
                }
            }
        }
    }
}
