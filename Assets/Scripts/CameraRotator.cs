using System;
using Core;
using UnityEngine;
using DG.Tweening;
using MyBox;

public class CameraRotator : MonoBehaviour
{
    #region Type Definitions
    
    #endregion

    #region Events

    #endregion

    #region Constants

    #endregion

    #region Serialized Fields
    
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _duration;

    #endregion

    #region Standard Attributes

    private RotationState _rotationState = RotationState.Down;
    private Tween _tween;

    #endregion

    #region Properties

    #endregion

    #region API Methods

    #endregion

    #region Unity Lifecycle

    private void OnEnable()
    {
        EventManager.OnRotateLeft += RotateLeft;
        EventManager.OnRotateRight += RotateRight;
    }

    private void OnDisable()
    {
        EventManager.OnRotateLeft -= RotateLeft;
        EventManager.OnRotateRight -= RotateRight;
    }

    #endregion

    #region Unity Callback

    [ButtonMethod]
    public void RotateLeft()
    {
        if (_tween.IsActive())
        {
            return;
        }

        _rotationState = (RotationState)Mathf.Abs(((int) _rotationState - 1).mod(4));
        Rotate(_rotation, _duration);
    }

    [ButtonMethod]
    public void RotateRight()
    {
        if (_tween.IsActive())
        {
            return;
        }
        _rotationState = (RotationState)((int)_rotationState + 1).mod(4);
        Rotate(-_rotation, _duration);
    }

    #endregion

    #region Other Methods

    private void Rotate(Vector3 rotation, float duration)
    {
        _tween = transform.DORotate(transform.rotation.eulerAngles + rotation, duration)
            .OnComplete(() => EventManager.OnRotationEnded.Invoke((CellDirection)_rotationState));
    }

    #endregion
}
