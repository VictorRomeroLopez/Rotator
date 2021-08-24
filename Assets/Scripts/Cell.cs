using System;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField, HideInInspector] private List<CellDirection> _directions;
    [SerializeField, HideInInspector] private List<Cell> _cells;
    
    private Dictionary<CellDirection, Cell> _surroundingCells = new Dictionary<CellDirection, Cell>();

    public Vector3 Position => transform.position;
    public Dictionary<CellDirection, Cell> SurroundingCells => _surroundingCells;

    private void Awake()
    {
        SetCells();
    }

    public bool HasCellOnDirection(CellDirection direction)
    {
        return _surroundingCells.ContainsKey(direction);
    }

    public Cell GetCellOnDirection(CellDirection direction)
    {
        return _surroundingCells[direction];
    }

    public void SetCells()
    {
        _surroundingCells.Clear();
        
        for (int i = 0; i < _directions.Count && i < _cells.Count; i++)
        {
            _surroundingCells.Add(_directions[i], _cells[i]);
        }
    }
}