using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionShop : MonoBehaviour
{
    // UI ��Ʈ�ѷ� �� ���� �÷��� ��Ʈ�ѷ� ����
    public UIController uIController;
    public GamePlayController gamePlayController;
    // è�Ǿ� Ǯ ��ũ��Ʈ ����
    public ChampionPool championPoolScript;

    private Champion[] availableChampionArray; // ChampionData�� ����

    void Start()
    {
        // ���� �ʱ�ȭ
        RefreshShop(true);
    }

    void Update()
    {
        //if (Roundwait)
        //{
        //    
        //    currentGold += 6;
        //    if (currentGold >= 10 || currentGold < 20)
        //    {
        //        currentGold += 7;
        //    }
        //    else if (currentGold >= 20 || currentGold < 30)
        //    {
        //        currentGold += 8;
        //    }
        //    else if (currentGold >= 30)
        //    {
        //        currentGold += 9;
        //    }
        //}
    }

    public void BuyLvl()
    {
        // ���� �÷��� ��Ʈ�ѷ��� BuyLvl �޼��� ȣ��
        gamePlayController.Buylvl();
        gamePlayController.IncreasePlayerLevel();
    }

    public void RefreshShop(bool isFree)
    {
        // ���� ��尡 2 �̸��̰� ����� ���ΰ�ħ���� �ʴ� ��� ��ȯ
        if (gamePlayController.currentGold < 2 && !isFree)
            return;

        // �÷��̾� ���� �� è�Ǿ� �� ���
        int playerLevel = gamePlayController.GetPlayerLevel();
        int championCount = CalculateChampionCount(playerLevel);

        // ���� ������ è�Ǿ� �迭 �ʱ�ȭ
        availableChampionArray = new Champion[4]; // Champion�� ����

        // è�Ǿ� Ǯ���� �����ϰ� è�Ǿ��� ������ �迭�� �����ϰ� UI�� ǥ��
        for (int i = 0; i < availableChampionArray.Length; i++)
        {
            // è�Ǿ� Ǯ���� �����ϰ� è�Ǿ��� ������
            Champion champion = GetRandomChampionWithProbability();
            availableChampionArray[i] = champion;
            uIController.LoadShopItem(champion, i);
            uIController.ShowShopItems();
        }

        // ����� ���ΰ�ħ���� �ʴ� ��� ��� ����
        if (!isFree)
            gamePlayController.currentGold -= 2;

        // UI ������Ʈ
        uIController.UpdateUI();

        //Debug.Log("Champion: ", )
    }

    // è�Ǿ� Ǯ���� �����ϰ� è�Ǿ��� �������� �޼���
    private Champion GetRandomChampionWithProbability()
    {
        // è�Ǿ� Ǯ���� ��� ������ è�Ǿ���� ������
        List<Champion> availableChampions = new List<Champion>();

        foreach (Champion champion in championPoolScript.championPool)
        {
            if (!IsChampionMaxedOut(champion)) // �ش� è�Ǿ��� �ִ� ���� �������� �ʾ��� ���� �߰�
            {
                availableChampions.Add(champion);
            }
        }

        // è�Ǿ� Ǯ�� ����ִٸ� null ��ȯ
        if (availableChampions.Count == 0)
        {
            Debug.LogWarning("No available champions in the pool!");
            return null;
        }

        // è�Ǿ���� ������ �ε����� ����Ͽ� ��ȯ
        int randomIndex = Random.Range(0, availableChampions.Count);
        return availableChampions[randomIndex];
    }

    // �ش� è�Ǿ��� �ִ� ���� �����ߴ��� Ȯ���ϴ� �޼���
    private bool IsChampionMaxedOut(Champion champion)
    {
        // �� è�Ǿ�� �ִ� �������� ��Ÿ���� ��ųʸ�
        Dictionary<string, int> maxChampionCounts = new Dictionary<string, int>()
        {
            {"��ϸ�", 7},
            {"�ƷϽ�", 7},
            {"�ٹٸ���", 7},
            {"�ٸ���", 7},
            {"�ֽ�", 7},
            {"�θ�", 7},
            {"�ǿ���", 7},
            {"�̸��ñ�", 7},
            {"�Ƽ���", 7},
            {"�Ƹ���", 7},
            {"ī��", 7},
            {"���θ�", 7},
            {"�Ϸ���", 7},
            {"��ũ", 7}
        };

        // è�Ǿ� �̸��� Ű�� ����Ͽ� �ִ� �������� ������
        int maxCount = maxChampionCounts[champion.championName];

        // ���� è�Ǿ� Ǯ���� �ش� è�Ǿ��� ���� ����Ͽ� �ִ� ���� �����ߴ��� Ȯ��
        int currentCount = championPoolScript.championPool.FindAll(c => c.championName == champion.championName).Count;
        return currentCount >= maxCount;
    }

    public void OnChampionFrameClicked(int index)
    {
        // �������� è�Ǿ��� �����ϰ� �����ϸ� �ش� è�Ǿ� ������ ����
        bool isSuccess = gamePlayController.BuyChampionFromShop(availableChampionArray[index]);
        if (isSuccess)
            uIController.HideChampionFrame(index);
    }

    // �÷��̾� ������ ���� è�Ǿ� ���� ����ϴ� �޼���
    private int CalculateChampionCount(int playerLevel)
    {
        // �÷��̾� ���� * 5�� ��ȯ
        return playerLevel * 5;
    }
}