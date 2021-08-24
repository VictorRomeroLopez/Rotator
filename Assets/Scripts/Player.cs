using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;
    private Cell _currentCell;

    private void Awake()
    {
        _transform = transform;
        EventManager.OnRotationEnded += CheckFall;
    }

    private void CheckFall(CellDirection direction)
    {
        if (!_currentCell.HasCellOnDirection(direction))
        {
            return;
        }
        
        Cell newCell = _currentCell.GetCellOnDirection(direction);
        TweenPlayerToPosition(newCell.Position);
        _currentCell = newCell;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawRay(_transform.position, _transform.up);
    }
#endif

    public void SetCell(Cell newCurrentCell)
    {
        _currentCell = newCurrentCell;
    }

    private void TweenPlayerToPosition(Vector3 newPosition)
    {
        transform.DOMove(newPosition, .5f);
    }
}
