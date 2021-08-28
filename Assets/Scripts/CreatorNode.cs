using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreatorNode : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CellMap _cellMap;

    private Vector2 _initialPosition;
    private Vector2 _endPosition;
    private float _sizeGrid = 1;

    public void OnPointerDown(PointerEventData eventData)
    {
        _initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _initialPosition = (_initialPosition / _sizeGrid).Round() * _sizeGrid;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _endPosition = (_endPosition / _sizeGrid).Round() * _sizeGrid;
        
        CellPosition initial = new CellPosition(_initialPosition);
        CellPosition end = new CellPosition(_endPosition);
        
        if (_initialPosition == _endPosition && !_cellMap.ContainsKey(initial))
        {
            _cellMap.AddCell(initial, _initialPosition);
            return;
        }

        if (_cellMap.ContainsKey(initial) &&
            (Math.Abs(initial.x - end.x) < Mathf.Epsilon || 
             Math.Abs(initial.y - end.y) < Mathf.Epsilon))
        {
            if (!_cellMap.ContainsKey(end))
            {
                _cellMap.AddCell(end, _endPosition);
            }
            
            _cellMap.ConnectCells(initial, end);
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_initialPosition, .1f);
        Gizmos.DrawSphere(_endPosition, .1f);
    }
}
