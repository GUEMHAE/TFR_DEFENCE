using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PlayerManager playerManager; // �÷��̾� �Ŵ��� ����
    public Text goldText; // UI Text ���
    public RandomUnitSelector randomUnitSelector; // ���� ���� ���ñ� ��ũ��Ʈ ����

    // �������� ������ �����ϴ� �Լ�
    public void BuyUnit()
    {
        // ���ſ� �ʿ��� ���
        int unitCost = 1; // ���÷� 1���� ����

        // �÷��̾��� ��尡 ������ �ڽ�Ʈ���� ���� ��쿡�� ������ ����
        if (playerManager.gold >= unitCost)
        {
            // �÷��̾� ��� ����
            playerManager.DecreaseGold(unitCost);

            // ��� �ؽ�Ʈ ������Ʈ
            UpdateGoldText();

            // �����ϰ� ���� ���� �� �̹��� ǥ��
            randomUnitSelector.SelectRandomUnitAndDisplayImage();
        }
        else
        {
            Debug.Log("��尡 �����մϴ�.");
        }
    }

    // ��� �ؽ�Ʈ ������Ʈ �Լ�
    void UpdateGoldText()
    {
        goldText.text = "Gold: " + playerManager.gold.ToString();
    }
}
