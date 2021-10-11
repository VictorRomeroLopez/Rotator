using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ActionButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberActionsText;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] protected Button _button;

    public bool HasActionsLeft => NumActions > 0;
    protected int NumActions { get; set; }
    
    protected abstract string Direction { get; }

    public void Configure(int numActions)
    {
        NumActions = numActions;
        UpdateNumActionsText();
        _buttonText.text = Direction;
    }

    private void Awake()
    {
        Configure(3);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ExecuteAction);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ExecuteAction);
    }

    protected abstract void ExecuteAction();

    protected void UpdateNumActionsText()
    {
        _numberActionsText.text = $"x{NumActions}";
    }
}