using Core;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private Cell _currentCell;

    public Cell CurrentCell => _currentCell;
    
    private void Awake()
    {
        _transform = transform;
        _transform.position = _currentCell.Position;
        EventManager.OnRotationEnded += CheckFall;
    }

    private void CheckFall(CellDirection direction)
    {
        if (!_currentCell.HasCellOnDirection(direction))
        {
            EventManager.OnPlayerMovementEnded.Invoke();
            return;
        }
        
        Cell newCell = _currentCell.GetCellOnDirection(direction);
        TweenPlayerToPosition(newCell.Position);
        _currentCell = newCell;
    }

    public void SetCell(Cell newCurrentCell)
    {
        _transform.position = newCurrentCell.Position;
        _currentCell = newCurrentCell;
    }

    private void TweenPlayerToPosition(Vector3 newPosition)
    {
        transform.DOMove(newPosition, .5f).OnComplete(() => { EventManager.OnPlayerMovementEnded.Invoke();});
    }
}
