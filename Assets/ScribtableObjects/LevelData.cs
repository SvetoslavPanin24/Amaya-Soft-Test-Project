using UnityEngine;

[CreateAssetMenu(fileName = "currentLevelData", menuName = "Level/currentLevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int rows; // ���������� ����� � �����
    public int columns; // ���������� �������� � �����
    public GameObject cellPrefab; // ������ ������ ��� �����
    public float cellSize; // ������ ������
    public float padding; // ���������� ����� ��������
    public ItemSet[] itemSets;
    public string taskDescription; // �������� ������� ��� ������
}
