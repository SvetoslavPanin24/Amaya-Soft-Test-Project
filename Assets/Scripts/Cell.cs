using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public ItemData Item { private set; get; } // ������� ������ ������

    // ����� ��� ������ �������� � ������
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

        // �������� ������� ��������
        Vector2 cellSpriteSize = cellSpriteRenderer.sprite.rect.size / cellSpriteRenderer.sprite.pixelsPerUnit;
        Vector2 cellItemSpriteSize = cellItemRenderer.sprite.rect.size / cellItemRenderer.sprite.pixelsPerUnit;

        // ��������� �������, ����������� ��� ���������� ��������
        Vector2 scale = new Vector2(cellSpriteSize.x / cellItemSpriteSize.x, cellSpriteSize.y / cellItemSpriteSize.y);

        cellSpriteRenderer.color = item.backGroundColor;

        // ��������� ������� � cellItemSprite
        cellItemRenderer.transform.localScale = scale * 0.7f;
    }
 
}
