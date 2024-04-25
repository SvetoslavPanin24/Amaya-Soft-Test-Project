using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public List<Cell> Cells { private set; get; }
    public int Rows { private set; get; } // Количество строк
    public int Columns { private set; get; } // Количество столбцов
    public GameObject CellPrefab { private set; get; } // Префаб ячейки
    public float CellSize { private set; get; } // Размер ячейки
    public float Padding { private set; get; } // Расстояние между ячейками

    public Grid(int rows, int columns, GameObject cellPrefab, float cellSize, float padding)
    {
        Rows = rows;
        Columns = columns;
        CellPrefab = cellPrefab;
        CellSize = cellSize;
        Padding = padding;
    }

    public void SetCells(List<Cell> cells)
    {
        this.Cells = cells;
    }
}
