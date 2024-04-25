using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public List<Cell> Cells { private set; get; }
    public int Rows { private set; get; } // ���������� �����
    public int Columns { private set; get; } // ���������� ��������
    public GameObject CellPrefab { private set; get; } // ������ ������
    public float CellSize { private set; get; } // ������ ������
    public float Padding { private set; get; } // ���������� ����� ��������

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
