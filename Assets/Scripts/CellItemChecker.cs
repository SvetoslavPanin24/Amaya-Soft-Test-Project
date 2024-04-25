using UnityEngine;

public class CellItemChecker : MonoBehaviour
{
    [SerializeField] private GameObject levelManager;
    void Update()
    {
        // ��������� ������� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
      
            // ���������, ���� �� ���������
            if (hit.collider != null)
            {
                Cell cell = hit.collider.GetComponent<Cell>();
                if (cell != null && cell.Item == levelManager.GetComponent<Level>().ItemToFind)
                {
                    // ������� � ������ ��������� � ������� ���������
                    Debug.Log("Item found!");
                }
                else
                {
                    // ������� �� ������ ��� ������ �����
                    Debug.Log("Item not found or cell is empty.");
                }
            }
        }
    }
}
