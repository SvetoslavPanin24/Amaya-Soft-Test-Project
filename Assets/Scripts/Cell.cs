using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public ItemData Item { private set; get; } // Предмет внутри ячейки

    // Метод для спавна предмета в ячейке
    public void SpawnItem(ItemData item)
    {
        this.Item = item;

        GameObject cellItem = new GameObject();
        cellItem.transform.SetParent(transform);

        cellItem.transform.localPosition = Vector3.zero;

        SpriteRenderer cellItemRenderer = cellItem.AddComponent<SpriteRenderer>();
        cellItemRenderer.sprite = item.itemSprite;
        cellItemRenderer.sortingOrder = 1;

        SpriteRenderer cellSpriteRenderer = GetComponent<SpriteRenderer>();

        // Получаем размеры спрайтов
        Vector2 cellSpriteSize = cellSpriteRenderer.sprite.rect.size / cellSpriteRenderer.sprite.pixelsPerUnit;
        Vector2 cellItemSpriteSize = cellItemRenderer.sprite.rect.size / cellItemRenderer.sprite.pixelsPerUnit;

        // Вычисляем масштаб, необходимый для совпадения размеров
        Vector2 scale = new Vector2(cellSpriteSize.x / cellItemSpriteSize.x, cellSpriteSize.y / cellItemSpriteSize.y);

        cellSpriteRenderer.color = item.backGroundColor;

        // Применяем масштаб к cellItemSprite
        cellItemRenderer.transform.localScale = scale * 0.7f;
    }
 
}
