using System;
using System.Collections.Generic;
using UnityEngine;

public class CellMap : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;

    [SerializeField] private List<Cell> _manualCells;

    private Dictionary<CellPosition, Cell> _cellPositionToCell = new Dictionary<CellPosition, Cell>();

    private List<CellPosition> _rowCells = new List<CellPosition>();

    public Dictionary<CellPosition, Cell> CellPositionToCell => _cellPositionToCell;

    public void AddCell(CellPosition cellPosition, Vector3 position)
    {
        _cellPositionToCell[cellPosition] = Instantiate(_cellPrefab, position, Quaternion.identity, transform);
        if (_rowCells.Contains(cellPosition))
        {
            _rowCells.Remove(cellPosition);
        }
    }

    public bool ContainsKey(CellPosition cellPosition)
    {
        return _cellPositionToCell.ContainsKey(cellPosition);
    }

    public void ConnectCells(CellPosition firstPosition, CellPosition secondPosition)
    {
        _cellPositionToCell[firstPosition].AddCell(_cellPositionToCell[secondPosition]);
        _cellPositionToCell[secondPosition].AddCell(_cellPositionToCell[firstPosition]);

        Vector2 firstToSecondVector = firstPosition.Vector - secondPosition.Vector;

        for (int i = 1; i < firstToSecondVector.magnitude/1; i++)
        {
            Vector2 newCellPosition = secondPosition.Vector + firstToSecondVector.normalized * i * 1;
            _rowCells.Add(new CellPosition(newCellPosition));
        }
    }

    private void Awake()
    {
        foreach (Cell cell in _manualCells)
        {
            _cellPositionToCell[new CellPosition(cell.Position.x, cell.Position.y)] = cell;
        }
    }

    private void OnDrawGizmos()
    {
        foreach (CellPosition cellPosition in _rowCells)
        {
            Gizmos.DrawWireSphere( new Vector3(cellPosition.x, cellPosition.y, 0), 1f);
        }
    }
}