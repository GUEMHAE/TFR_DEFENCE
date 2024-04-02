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
            Champion champion = GetRandomChampionWithProbability();
            availableChampionArray[i] = champion;
            uIController.LoadShopItem(champion, i);
            uIController.ShowShopItems();
        }

        // 무료로 새로고침하지 않는 경우 골드 차감
        if (!isFree)
            gamePlayController.currentGold -= 2;

        // UI 업데이트
        uIController.UpdateUI();

        //Debug.Log("Champion: ", )
    }

    // 챔피언 풀에서 랜덤하게 챔피언을 가져오는 메서드
    private Champion GetRandomChampionWithProbability()
    {
        // 챔피언 풀에서 사용 가능한 챔피언들을 가져옴
        List<Champion> availableChampions = new List<Champion>();

        foreach (Champion champion in championPoolScript.championPool)
        {
            if (!IsChampionMaxedOut(champion)) // 해당 챔피언이 최대 수에 도달하지 않았을 때만 추가
            {
                availableChampions.Add(champion);
            }
        }

        // 챔피언 풀이 비어있다면 null 반환
        if (availableChampions.Count == 0)
        {
            Debug.LogWarning("No available champions in the pool!");
            return null;
        }

        // 챔피언들의 랜덤한 인덱스를 계산하여 반환
        int randomIndex = Random.Range(0, availableChampions.Count);
        return availableChampions[randomIndex];
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

    public void OnChampionFrameClicked(int index)
    {
        // 상점에서 챔피언을 구매하고 성공하면 해당 챔피언 프레임 숨김
        bool isSuccess = gamePlayController.BuyChampionFromShop(availableChampionArray[index]);
        if (isSuccess)
            uIController.HideChampionFrame(index);
    }

    // 플레이어 레벨에 따라 챔피언 수를 계산하는 메서드
    private int CalculateChampionCount(int playerLevel)
    {
        // 플레이어 레벨 * 5를 반환
        return playerLevel * 5;
    }
}