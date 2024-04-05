using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionPool : MonoBehaviour
{
    // 챔피언 풀
    public List<ChampionShop.Champion> championPool; // ChampionShop.Champion로 변경

    void Start()
    {
        // 챔피언 풀 초기화
        InitializeChampionPool();
    }

    // 챔피언 풀 초기화 메서드
    private void InitializeChampionPool()
    {
        championPool = new List<ChampionShop.Champion>(); // ChampionShop.Champion로 변경

        // 예시로 주어진 챔피언들을 추가합니다.
        championPool.Add(new ChampionShop.Champion("토니르", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("아록스", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("바바리안", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("다르밤", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("애쉬", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("부르", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("피오나", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("이르시그", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("아서스", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("아르테", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("카뮴", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("르로르", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("일렉토", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("링크", ChampionShop.ChampionRarity.Common));
    }

    // 챔피언 풀에서 랜덤하게 챔피언 가져오는 메서드
    //public ChampionShop.Champion GetRandomChampion()
    //{
    //    if (championPool.Count == 0)
    //    {
    //        Debug.LogWarning("Champion pool is empty!");
    //        return null;
    //    }

    //    int randomIndex = Random.Range(0, championPool.Count);
    //    ChampionShop.Champion randomChampion = championPool[randomIndex];
    //    championPool.RemoveAt(randomIndex);
    //    return randomChampion;
    //}
}
