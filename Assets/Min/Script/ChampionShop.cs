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
        //if (WaitRound)
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
            //ChampionData champion = GetRandomChampionWithProbability(playerLevel);
            //availableChampionArray[i] = champion;
            //uIController.LoadShopItem(champion, i);
            uIController.ShowShopItems();
        }

        // ����� ���ΰ�ħ���� �ʴ� ��� ��� ����
        if (!isFree)
            gamePlayController.currentGold -= 2;

        // UI ������Ʈ
        uIController.UpdateUI();

        //Debug.Log("Champion: ", )
    }

    //public void OnChampionFrameClicked(int index)
    //{
    //    // �������� è�Ǿ��� �����ϰ� �����ϸ� �ش� è�Ǿ� ������ ����
    //    bool isSuccess = gamePlayController.BuyChampionFromShop(availableChampionArray[index]);
    //    if (isSuccess)
    //        uIController.HideChampionFrame(index);
    //}

    // �÷��̾� ������ ���� è�Ǿ� ���� ����ϴ� �޼���
    private int CalculateChampionCount(int playerLevel)
    {
        // �÷��̾� ���� * 5�� ��ȯ
        return playerLevel;
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

    //è�Ǿ� ��� ������
    public enum ChampionRarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    //è�Ǿ� Ŭ������ ��޼Ӽ� �߰�
    public class Champion
    {
        public string championName;
        public ChampionRarity rarity;

        public Champion(string name, ChampionRarity rarity)
        {
            championName = name;
            this.rarity = rarity;
        }
    }

    // è�Ǿ� Ǯ���� �����ϰ� è�Ǿ��� �������� �޼���
    private Champion GetRandomChampionWithProbability(int playerLevel)
    {
        // �� ��޺� è�Ǿ� ����Ʈ �ʱ�ȭ
        List<Champion> commonChampions = new List<Champion>();
        List<Champion> rareChampions = new List<Champion>();
        List<Champion> epicChampions = new List<Champion>();
        List<Champion> legendaryChampions = new List<Champion>();

        // �� ��޺��� è�Ǿ��� �׷�ȭ
        foreach (Champion champion in championPoolScript.championPool)
        {
            switch (champion.rarity)
            {
                case ChampionRarity.Common:
                    commonChampions.Add(champion);
                    break;
                case ChampionRarity.Rare:
                    rareChampions.Add(champion);
                    break;
                case ChampionRarity.Epic:
                    epicChampions.Add(champion);
                    break;
                case ChampionRarity.Legendary:
                    legendaryChampions.Add(champion);
                    break;
                default:
                    Debug.LogError("Unknown Champion Rarity: " + champion.rarity);
                    break;
            }
        }

        // �÷��̾� ������ ���� Ȯ�� ����
        float commonChance = CalculateProbability(playerLevel, ChampionRarity.Common);
        float rareChance = CalculateProbability(playerLevel, ChampionRarity.Rare);
        float epicChance = CalculateProbability(playerLevel, ChampionRarity.Epic);
        float legendaryChance = CalculateProbability(playerLevel, ChampionRarity.Legendary);

        // ��޿� ���� Ȯ���� �迭�� ����
        float[] chances = { commonChance, rareChance, epicChance, legendaryChance };

        // �������� ��� ����
        float randomValue = Random.value;
        float cumulativeChance = 0f;
        ChampionRarity selectedRarity = ChampionRarity.Common;

        for (int i = 0; i < chances.Length; i++)
        {
            cumulativeChance += chances[i];
            if (randomValue < cumulativeChance)
            {
                selectedRarity = (ChampionRarity)i;
                break;
            }
        }

        // ���õ� ��޿� ���� è�Ǿ� ����
        List<Champion> selectedChampions;
        switch (selectedRarity)
        {
            case ChampionRarity.Common:
                selectedChampions = commonChampions;
                break;
            case ChampionRarity.Rare:
                selectedChampions = rareChampions;
                break;
            case ChampionRarity.Epic:
                selectedChampions = epicChampions;
                break;
            case ChampionRarity.Legendary:
                selectedChampions = legendaryChampions;
                break;
            default:
                selectedChampions = commonChampions; // �⺻������ �Ϲ� ��� è�Ǿ� �׷� ����
                break;
        }

        // ���õ� ����� è�Ǿ� ����Ʈ���� �����ϰ� è�Ǿ� ����
        if (selectedChampions.Count == 0)
        {
            Debug.LogWarning("No champions available!");
            return null;
        }

        int randomIndex = Random.Range(0, selectedChampions.Count);
        return selectedChampions[randomIndex];
    }


    private float CalculateProbability(int playerLevel, ChampionRarity rarity)
    {
        float baseChance;

        switch (rarity)
        {
            case ChampionRarity.Common:
                switch (playerLevel)
                {
                    case 1:
                        baseChance = 1.0f;
                        break;
                    case 2:
                        baseChance = 0.9f;
                        break;
                    case 3:
                        baseChance = 0.75f;
                        break;
                    case 4:
                        baseChance = 0.55f;
                        break;
                    case 5:
                        baseChance = 0.45f;
                        break;
                    case 6:
                        baseChance = 0.3f;
                        break;
                    default:
                        baseChance = 0.1f;
                        break;
                }
                break;
            case ChampionRarity.Rare:
                switch (playerLevel)
                {
                    case 1:
                        baseChance = 0.0f;
                        break;
                    case 2:
                        baseChance = 0.1f;
                        break;
                    case 3:
                        baseChance = 0.25f;
                        break;
                    case 4:
                        baseChance = 0.3f;
                        break;
                    case 5:
                        baseChance = 0.33f;
                        break;
                    case 6:
                        baseChance = 0.4f;
                        break;
                    default:
                        baseChance = 0.1f;
                        break;
                }
                break;
            case ChampionRarity.Epic:
                switch (playerLevel)
                {
                    case 1:
                        baseChance = 0.0f;
                        break;
                    case 2:
                        baseChance = 0.0f;
                        break;
                    case 3:
                        baseChance = 0.0f;
                        break;
                    case 4:
                        baseChance = 0.15f;
                        break;
                    case 5:
                        baseChance = 0.2f;
                        break;
                    case 6:
                        baseChance = 0.25f;
                        break;
                    default:
                        baseChance = 0.1f;
                        break;
                }
                break;
            case ChampionRarity.Legendary:
                switch (playerLevel)
                {
                    case 1:
                        baseChance = 0.0f;
                        break;
                    case 2:
                        baseChance = 0.0f;
                        break;
                    case 3:
                        baseChance = 0.0f;
                        break;
                    case 4:
                        baseChance = 0.0f;
                        break;
                    case 5:
                        baseChance = 0.02f;
                        break;
                    case 6:
                        baseChance = 0.05f;
                        break;
                    default:
                        baseChance = 0.1f;
                        break;
                }
                break;
        }

        return playerLevel;
    }
}
