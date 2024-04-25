using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Level/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemId; // ���������� ������������� �������
    public Sprite itemSprite; // ������ �������
    public Color backGroundColor; // ���� ���� ��� ������
}
