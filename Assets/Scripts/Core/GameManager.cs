using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<ActionButton> _buttons;
        [SerializeField] private Player _player;

        private void Awake()
        {
            //DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            EventManager.OnPlayerMovementEnded += CheckEndGame;
        }

        private void OnDisable()
        {
            EventManager.OnPlayerMovementEnded -= CheckEndGame;
        }

        private void CheckEndGame()
        {
            if (_player.CurrentCell.IsEndCell)
            {
                EventManager.OnLevelCompleted.Invoke();
                return;
            }
            
            foreach (ActionButton actionButton in _buttons)
            {
                if (actionButton.HasActionsLeft)
                {
                    return;
                }
            }

            EventManager.OnLevelFailed.Invoke();
        }
    }
}