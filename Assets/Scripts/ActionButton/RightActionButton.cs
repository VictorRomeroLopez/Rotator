using Core;
using UnityEngine;

public class RightActionButton : ActionButton
{
    protected override string Direction => "Right";

    protected override void ExecuteAction()
    {
        NumActions--;
        UpdateNumActionsText();
        EventManager.OnRotateRight.Invoke();
        
        if (NumActions <= 0)
        {
            _button.interactable = false;
        }

        Debug.Log(Direction);
    }
}