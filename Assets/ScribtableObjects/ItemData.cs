using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Level/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemId; // Уникальный идентификатор объекта
    public Sprite itemSprite; // Спрайт объекта
    public Color backGroundColor; // Цвет фона для айтема
}
