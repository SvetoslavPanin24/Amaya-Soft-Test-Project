using UnityEngine;

public class CellItemChecker : MonoBehaviour
{
    [SerializeField] private GameObject levelManager;
    void Update()
    {
        // Проверяем нажатие левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
      
            // Проверяем, есть ли попадание
            if (hit.collider != null)
            {
                Cell cell = hit.collider.GetComponent<Cell>();
                if (cell != null && cell.Item == levelManager.GetComponent<Level>().ItemToFind)
                {
                    // Предмет в ячейке совпадает с искомым предметом
                    Debug.Log("Item found!");
                }
                else
                {
                    // Предмет не найден или ячейка пуста
                    Debug.Log("Item not found or cell is empty.");
                }
            }
        }
    }
}
