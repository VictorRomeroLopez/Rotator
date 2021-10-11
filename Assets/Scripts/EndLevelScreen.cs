using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Rotator
{
    public class EndLevelScreen : MonoBehaviour
    {
        #region Type Definitions

        #endregion

        #region Events

        #endregion

        #region Constants

        #endregion

        #region Serialized Fields

        [SerializeField] private TextMeshProUGUI _tittle;
        
        [SerializeField] private Button _button;

        [SerializeField] private CanvasGroup _canvasGroup;

        #endregion

        #region Standard Attributes

        #endregion

        #region Properties

        #endregion

        #region API Methods

        #endregion

        #region Unity Lifecycle

        private void OnEnable()
        {
            EventManager.OnLevelCompleted += ShowCompleteScreen;
            EventManager.OnLevelFailed += ShowFailedScreen;
        }

        private void OnDisable()
        {
            EventManager.OnLevelCompleted -= ShowCompleteScreen;
            EventManager.OnLevelFailed -= ShowFailedScreen;
        }

        #endregion

        #region Unity Callback

        #endregion

        #region Other Methods

        private void ShowCompleteScreen()
        {
            ShowCanvas();
            _tittle.text = "Level complete";
            _button.GetComponentInChildren<TextMeshProUGUI>().text = "Next";
            _button.onClick.AddListener(NextLevel);
        }

        private void ShowFailedScreen()
        {
            ShowCanvas();
            _tittle.text = "Level failed";
            _button.GetComponentInChildren<TextMeshProUGUI>().text = "Restart";
            _button.onClick.AddListener(RestartLevel);
        }

        private void HideCanvas()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
        
        private void ShowCanvas()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        private void NextLevel()
        {
            Debug.Log("Next level!");
        }

        private void RestartLevel()
        {
            Debug.Log("Restart level!");
            SceneManager.LoadScene("SampleScene");
        }
        
        #endregion

    }
}
