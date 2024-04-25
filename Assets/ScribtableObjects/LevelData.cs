using UnityEngine;

[CreateAssetMenu(fileName = "currentLevelData", menuName = "Level/currentLevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int rows; // Количество строк в сетке
    public int columns; // Количество столбцов в сетке
    public GameObject cellPrefab; // Префаб ячейки для сетки
    public float cellSize; // Размер ячейки
    public float padding; // Расстояние между ячейками
    public ItemSet[] itemSets;
    public string taskDescription; // Описание задания для уровня
}
