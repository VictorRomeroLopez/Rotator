using System.Collections.Generic;
using UnityEngine;

public class CellMap : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    
    private Dictionary<CellPosition, Cell> _cellPositionToCell = new Dictionary<CellPosition, Cell>();
    
    public void AddCell(CellPosition cellPosition, Vector3 position)
    {
        _cellPositionToCell[cellPosition] = Instantiate(_cellPrefab, position, Quaternion.identity, transform);
    }

    public bool ContainsKey(CellPosition cellPosition)
    {
        return _cellPositionToCell.ContainsKey(cellPosition);
    }

    public void ConnectCells(CellPosition firstPosition, CellPosition secondPosition)
    {
        _cellPositionToCell[firstPosition].AddCell(_cellPositionToCell[secondPosition]);
        _cellPositionToCell[secondPosition].AddCell(_cellPositionToCell[firstPosition]);
    }
}