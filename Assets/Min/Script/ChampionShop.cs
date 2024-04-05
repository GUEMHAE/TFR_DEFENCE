using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionShop : MonoBehaviour
{
    // UI 컨트롤러 및 게임 플레이 컨트롤러 참조
    public UIController uIController;
    public GamePlayController gamePlayController;
    // 챔피언 풀 스크립트 참조
    public ChampionPool championPoolScript;

    private Champion[] availableChampionArray; // ChampionData로 변경

    void Start()
    {
        // 상점 초기화
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
        // 게임 플레이 컨트롤러의 BuyLvl 메서드 호출
        gamePlayController.Buylvl();
        gamePlayController.IncreasePlayerLevel();
    }

    public void RefreshShop(bool isFree)
    {
        // 현재 골드가 2 미만이고 무료로 새로고침하지 않는 경우 반환
        if (gamePlayController.currentGold < 2 && !isFree)
            return;

        // 플레이어 레벨 및 챔피언 수 계산
        int playerLevel = gamePlayController.GetPlayerLevel();
        int championCount = CalculateChampionCount(playerLevel);

        // 구매 가능한 챔피언 배열 초기화
        availableChampionArray = new Champion[4]; // Champion로 변경

        // 챔피언 풀에서 랜덤하게 챔피언을 가져와 배열에 저장하고 UI에 표시
        for (int i = 0; i < availableChampionArray.Length; i++)
        {
            // 챔피언 풀에서 랜덤하게 챔피언을 가져옴
            //ChampionData champion = GetRandomChampionWithProbability(playerLevel);
            //availableChampionArray[i] = champion;
            //uIController.LoadShopItem(champion, i);
            uIController.ShowShopItems();
        }

        // 무료로 새로고침하지 않는 경우 골드 차감
        if (!isFree)
            gamePlayController.currentGold -= 2;

        // UI 업데이트
        uIController.UpdateUI();

        //Debug.Log("Champion: ", )
    }

    //public void OnChampionFrameClicked(int index)
    //{
    //    // 상점에서 챔피언을 구매하고 성공하면 해당 챔피언 프레임 숨김
    //    bool isSuccess = gamePlayController.BuyChampionFromShop(availableChampionArray[index]);
    //    if (isSuccess)
    //        uIController.HideChampionFrame(index);
    //}

    // 플레이어 레벨에 따라 챔피언 수를 계산하는 메서드
    private int CalculateChampionCount(int playerLevel)
    {
        // 플레이어 레벨 * 5를 반환
        return playerLevel;
    }

    // 해당 챔피언이 최대 수에 도달했는지 확인하는 메서드
    private bool IsChampionMaxedOut(Champion champion)
    {
        // 각 챔피언당 최대 마리수를 나타내는 딕셔너리
        Dictionary<string, int> maxChampionCounts = new Dictionary<string, int>()
        {
            {"토니르", 7},
            {"아록스", 7},
            {"바바리안", 7},
            {"다르밤", 7},
            {"애쉬", 7},
            {"부르", 7},
            {"피오나", 7},
            {"이르시그", 7},
            {"아서스", 7},
            {"아르테", 7},
            {"카뮴", 7},
            {"르로르", 7},
            {"일렉토", 7},
            {"링크", 7}
        };

        // 챔피언 이름을 키로 사용하여 최대 마리수를 가져옴
        int maxCount = maxChampionCounts[champion.championName];

        // 현재 챔피언 풀에서 해당 챔피언의 수를 계산하여 최대 수에 도달했는지 확인
        int currentCount = championPoolScript.championPool.FindAll(c => c.championName == champion.championName).Count;
        return currentCount >= maxCount;
    }

    //챔피언 등급 열거형
    public enum ChampionRarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    //챔피언 클래스에 등급속성 추가
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

    // 챔피언 풀에서 랜덤하게 챔피언을 가져오는 메서드
    private Champion GetRandomChampionWithProbability(int playerLevel)
    {
        // 각 등급별 챔피언 리스트 초기화
        List<Champion> commonChampions = new List<Champion>();
        List<Champion> rareChampions = new List<Champion>();
        List<Champion> epicChampions = new List<Champion>();
        List<Champion> legendaryChampions = new List<Champion>();

        // 각 등급별로 챔피언을 그룹화
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

        // 플레이어 레벨에 따른 확률 설정
        float commonChance = CalculateProbability(playerLevel, ChampionRarity.Common);
        float rareChance = CalculateProbability(playerLevel, ChampionRarity.Rare);
        float epicChance = CalculateProbability(playerLevel, ChampionRarity.Epic);
        float legendaryChance = CalculateProbability(playerLevel, ChampionRarity.Legendary);

        // 등급에 따른 확률을 배열에 저장
        float[] chances = { commonChance, rareChance, epicChance, legendaryChance };

        // 랜덤으로 등급 선택
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

        // 선택된 등급에 따라 챔피언 선택
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
                selectedChampions = commonChampions; // 기본적으로 일반 등급 챔피언 그룹 선택
                break;
        }

        // 선택된 등급의 챔피언 리스트에서 랜덤하게 챔피언 선택
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
