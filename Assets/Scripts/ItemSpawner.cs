using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject SpawnItem(ItemData itemData, Vector3 position)
    {
        GameObject item = new GameObject(itemData.itemId);
        SpriteRenderer renderer = item.AddComponent<SpriteRenderer>();
        renderer.sprite = itemData.itemSprite;
        item.transform.position = position;
        // Добавление других необходимых компонентов и настройка объекта
        return item;
    }
}
