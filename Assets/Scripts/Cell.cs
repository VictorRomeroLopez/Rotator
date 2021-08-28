using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField, HideInInspector] private List<Cell> _cells;
    
    private Dictionary<CellDirection, Cell> _surroundingCells = new Dictionary<CellDirection, Cell>();

    public Vector3 Position => transform.position;
    
    public void AddCell(Cell cell)
    {
        if (!cell || _cells.Contains(cell) || cell == this)
        {
            return;
        }
        
        _cells.Add(cell);
        
        if(!Application.isPlaying)
            EditorUtility.SetDirty(this);
    }
    
    public bool HasCellOnDirection(CellDirection direction)
    {
        return _surroundingCells.ContainsKey(direction);
    }

    public Cell GetCellOnDirection(CellDirection direction)
    {
        return _surroundingCells[direction];
    }

    public void AddSelectedCells()
    {
        foreach (GameObject gameObject in Selection.gameObjects)
        {
            Cell cell = gameObject.GetComponent<Cell>();
            AddCell(cell);
            cell?.AddCell(this);
        }
    }

    private void Awake()
    {
        SetCells();
    }

    private void OnDrawGizmos()
    {
        foreach (Cell cell in _cells)
        {
            switch (GetDirectionToCell(cell))
            {
                case CellDirection.Up:
                    Gizmos.color = Color.red;
                    break;
                case CellDirection.Right:
                    Gizmos.color = Color.blue;
                    break;
                case CellDirection.Down:
                    Gizmos.color = Color.yellow;
                    break;
                case CellDirection.Left:
                    Gizmos.color = Color.green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            Vector2 direction = cell.Position - transform.position;
            Vector2 cross = new Vector2(direction.y, direction.x);
            Gizmos.DrawRay(transform.position + (Vector3)(cross.normalized * .1f), direction);
        }
    }

    private void SetCells()
    {
        _surroundingCells.Clear();

        foreach (Cell cell in _cells)
        {
            _surroundingCells.Add(GetDirectionToCell(cell), cell);
        }
    }

    private CellDirection GetDirectionToCell(Cell cell)
    {
        Vector2 direction = cell.transform.position - transform.position;
        
        if (Vector2.Angle(direction, Vector2.up) <= 45)
        {
            return CellDirection.Up;
        }
        if (Vector2.Angle(direction, Vector2.left) <= 45)
        {
            return CellDirection.Left;
        }
        if (Vector2.Angle(direction, Vector2.down) <= 45)
        {
            return CellDirection.Down;
        }

        return CellDirection.Right;
    }
}