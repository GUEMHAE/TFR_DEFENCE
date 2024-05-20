
using UnityEngine;

public class Sell : MonoBehaviour
{
    public GameObject sell;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Unit")
        {
            GetUnitInfo unitInfo = collision.GetComponent<GetUnitInfo>();
            if (unitInfo != null)
            {
                GameManager.instance.gold += (int)unitInfo.sellCost;
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.LogError("�浹�� ��ü���� GetUnitInfo ������Ʈ�� ã�� �� �����ϴ�!");
            }
        }
    }
}
