using Core;
using UnityEngine;

public class LeftActionButton : ActionButton
{
    protected override string Direction => "Left";

    protected override void ExecuteAction()
    {
        NumActions--;
        UpdateNumActionsText();
        EventManager.OnRotateLeft.Invoke();
        
        if (NumActions <= 0)
        {
            _button.interactable = false;
        }
        
        Debug.Log(Direction);
    }
}