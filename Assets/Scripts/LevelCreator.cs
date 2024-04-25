using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private LevelData[] allLevelData;
    private LevelData currentLevelData;
    private int currentLevelIndex;

    [SerializeField] private Level level;

    [SerializeField] private GridBuilder gridBuilder;

    [SerializeField] private TMP_Text taskText;

    private void Start()
    {
        currentLevelIndex = 0;
        CreateLevel();
    }

    public void CreateLevel()
    {
        currentLevelData = allLevelData[currentLevelIndex];

        Grid grid = new Grid(currentLevelData.rows, currentLevelData.columns, currentLevelData.cellPrefab, currentLevelData.cellSize, currentLevelData.padding);
        gridBuilder.SpawnGrid(grid);

        // �������� ��������� ��������
        int randomItemSetIndex = Random.Range(0, currentLevelData.itemSets.Count());
        
        List<ItemData> avaliableItems = new List<ItemData>(currentLevelData.itemSets[randomItemSetIndex].items);
        List<ItemData> levelItems = new List<ItemData>();

        // ������� ������
        foreach (Cell cell in grid.Cells)
        {
            // �������� ��������� ������� �� ���������
            int randomItemIndex = Random.Range(0, avaliableItems.Count);
            ItemData selectedItem = avaliableItems[randomItemIndex];
            levelItems.Add(selectedItem);

            // ������� ������� � ������
            cell.SpawnItem(selectedItem);

            // ������� ��������� ������� �� ������ ���������, ����� �� �� ����������
            avaliableItems.RemoveAt(randomItemIndex);
        }
        ItemData itemToFind = levelItems[Random.Range(0, levelItems.Count)];
        level.InitializeLevel(itemToFind);
        taskText.text = "Find " + "<" + itemToFind.name + ">";

        currentLevelIndex++;
    }

}
