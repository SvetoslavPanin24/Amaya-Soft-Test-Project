using UnityEngine;

public class Level : MonoBehaviour
{
    public ItemData ItemToFind { private set; get; }

    public void InitializeLevel(ItemData itemToFind)
    {
        this.ItemToFind = itemToFind;
    }
}
