using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int gold = 10; // �÷��̾��� ���

    // ��带 ���ҽ�Ű�� �Լ�
    public void DecreaseGold(int amount)
    {
        gold -= amount;
    }

    // ��带 ������Ű�� �Լ�
    public void IncreaseGold(int amount)
    {
        gold += amount;
    }
}
