using UnityEngine;

[CreateAssetMenu(fileName = "ItemSet", menuName = "Level/ItemSet")]
public class ItemSet : ScriptableObject
{
    public ItemData[] items; // Массив объектов в наборе
}