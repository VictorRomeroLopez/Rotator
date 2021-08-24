using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlacer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Cell _initialCell;

    private void Start()
    {
        Cell newCell = _initialCell;
        _player.transform.position = newCell.Position;
        _player.SetCell(newCell);
        Destroy(this);
    }
}
