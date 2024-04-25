using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    [SerializeField] private Sprite backgroundSprite; // Спрайт для фона
    private List<Cell> cells = new List<Cell>();
    private GameObject backgroundObject;

    private Vector3 backgroundScale;
    [SerializeField] private GameObject cellPrefab;
    private SpriteRenderer cellRenderer;

    public void SpawnGrid(Grid gridToSpawn)
    {
        ConfigureCamera();
        Vector2 gridCenter = CalculateGridCenter();
        float cellSize = CalculateCellSize(gridToSpawn.Columns, gridToSpawn.Rows, gridToSpawn.Padding);
        CalculateBackgroundScale(gridToSpawn.Columns, gridToSpawn.Rows, gridToSpawn.Padding, cellSize);
        CreateBackground(cellSize);
        CreateCells(gridToSpawn.Columns, gridToSpawn.Rows, gridToSpawn.Padding, gridCenter, cellSize);
        ParentCellsToGrid();
        CenterBackground();
        gridToSpawn.SetCells(cells);
    }

    // Настройка камеры для корректного отображения
    private void ConfigureCamera()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        Camera.main.orthographicSize = screenHeight / 2;
        Camera.main.transform.position = new Vector3(screenWidth / 2, screenHeight / 2, -10);
    }

    // Расчет центральной точки сетки
    private Vector2 CalculateGridCenter()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        return new Vector2(screenWidth / 2, screenHeight / 2);
    }

    // Расчет размера ячейки
    private float CalculateCellSize(int columns, int rows, float padding)
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float areaWidth = screenWidth * 0.6f;
        float areaHeight = screenHeight * 0.6f;
        return Mathf.Min((areaWidth - columns * padding) / columns, (areaHeight - rows * padding) / rows);
    }

    // Создание фона
    private void CreateBackground(float cellSize)
    {
        backgroundObject = new GameObject("Background");
        SpriteRenderer backgroundRenderer = backgroundObject.AddComponent<SpriteRenderer>();
        backgroundRenderer.sprite = backgroundSprite;
        backgroundRenderer.sortingOrder = -1;

        backgroundObject.transform.localScale = backgroundScale;
    }

    // Расчет масштаба фона
    private void CalculateBackgroundScale(int columns, int rows, float padding, float cellSize)
    {
        backgroundScale = new Vector3(
            (cellSize * columns) / backgroundSprite.bounds.size.x + padding * columns / backgroundSprite.bounds.size.x,
            (cellSize * rows) / backgroundSprite.bounds.size.y + padding * rows / backgroundSprite.bounds.size.y,
            1);
    }

    // Создание ячеек
    private void CreateCells(int columns, int rows, float padding, Vector2 gridCenter, float cellSize)
    {
        Vector2 firstCellPosition = Vector2.zero;
        Vector2 lastCellPosition = Vector2.zero;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject cellObject = Instantiate(cellPrefab);

                cellObject.name = ($"Cell_{x}_{y}");
                cellObject.AddComponent<Cell>();
                cellObject.AddComponent<BoxCollider2D>();

                cellRenderer = cellPrefab.GetComponent<SpriteRenderer>();

                Vector3 cellPosition = CalculateCellPosition(columns, rows, padding, gridCenter, cellSize, x, y);
                cellObject.transform.position = cellPosition;         

                cells.Add(cellObject.GetComponent<Cell>()); 

                Vector3 parentScale = backgroundObject.transform.localScale;

                // Рассчитываем обратный масштаб, чтобы компенсировать масштаб родителя
                Vector3 inverseParentScale = new Vector3(CalculateCellScale(cellSize).x / parentScale.x, CalculateCellScale(cellSize).y / parentScale.y, 1 / parentScale.z);

                // Применяем обратный масштаб к ячейке перед анимацией
                cellObject.transform.localScale = inverseParentScale;

                // Теперь можно использовать DOScale для анимации масштаба ячейки
                // Умножаем целевой масштаб на обратный масштаб родителя
                Vector3 targetScale = Vector3.Scale(new Vector3(1, 1, 1), inverseParentScale);

                // Применяем анимацию с использованием DOTween
                cellObject.transform.DOScale(targetScale, 2).SetEase(Ease.OutBounce);

                if (y == 0 && x == 0)
                {
                    firstCellPosition = cellPosition;
                }
                if (y == rows - 1 && x == columns - 1)
                {
                    lastCellPosition = cellPosition;
                }
            }
        }

        // Установка позиции фона в центр сетки
        backgroundObject.transform.position = (firstCellPosition + lastCellPosition) / 2;
    }

    // Расчет позиции ячейки
    private Vector3 CalculateCellPosition(int columns, int rows, float padding, Vector2 gridCenter, float cellSize, int x, int y)
    {
        float positionX = gridCenter.x - (columns * cellSize + (columns - 1) * padding) / 2 + (cellSize + padding) * x;
        float positionY = gridCenter.y - (rows * cellSize + (rows - 1) * padding) / 2 + (cellSize + padding) * y;
        return new Vector3(positionX, positionY, 0);
    }

    // Расчет масштаба ячейки
    private Vector3 CalculateCellScale(float cellSize)
    {
        return new Vector3(
            cellSize / cellPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x,
            cellSize / cellPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y,
            1);
    }

    // Центрирование фона
    private void CenterBackground()
    {
        backgroundObject.transform.SetParent(transform);
        backgroundObject.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }
    private void ParentCellsToGrid()
    {
        foreach (Cell cell in cells)
        {
            cell.gameObject.transform.SetParent(backgroundObject.transform);
        }
    }
}