using System;
using UnityEngine;
using DG.Tweening;
using MyBox;

public static class EventManager
{
    public delegate void Event(CellDirection direction);

    public static Event OnRotationEnded;
}

public class CameraRotator : MonoBehaviour
{
    
    
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _duration;
    [SerializeField] private Transform _follow;

    private RotationState _rotationState = RotationState.Down;
    private Tween _tween;

    
    [ButtonMethod]
    public void RotateLeft()
    {
        if (_tween.IsActive())
        {
            return;
        }

        Debug.Log((RotationState)((int)_rotationState - 1).mod(4));
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
    
    private void Rotate(Vector3 rotation, float duration)
    {
        _tween = transform.DORotate(transform.rotation.eulerAngles + rotation, duration)
            .OnComplete(() => EventManager.OnRotationEnded.Invoke((CellDirection)_rotationState));
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        
        Vector3 direction = Vector3.up;
        switch (_rotationState)
        {
            case RotationState.Up:
                direction = Vector3.up;
                break;
            case RotationState.Right:
                direction = Vector3.right;
                break;
            case RotationState.Down:
                direction = Vector3.down;
                break;
            case RotationState.Left:
                direction = Vector3.left;
                break;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(_follow.position,direction);
    }
}
