using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionPool : MonoBehaviour
{
    // 챔피언 풀
    public  List<Champion> championPool;

    void Start()
    {
        // 챔피언 풀 초기화
        InitializeChampionPool();
    }

    // 챔피언 풀 초기화 메서드
    private void InitializeChampionPool()
    {
        championPool = new List<Champion>();

        // 예시로 주어진 챔피언들을 추가합니다.
        championPool.Add(new Champion("토니르"));
        championPool.Add(new Champion("아록스"));
        championPool.Add(new Champion("바바리안"));
        championPool.Add(new Champion("다르밤"));
        championPool.Add(new Champion("애쉬"));
        championPool.Add(new Champion("부르"));
        championPool.Add(new Champion("피오나"));
        championPool.Add(new Champion("이르시그"));
        championPool.Add(new Champion("아서스"));
        championPool.Add(new Champion("아르테"));
        championPool.Add(new Champion("카뮴"));
        championPool.Add(new Champion("르로르"));
        championPool.Add(new Champion("일렉토"));
        championPool.Add(new Champion("링크"));
    }

    // 챔피언 풀에서 랜덤하게 챔피언 가져오는 메서드
    public Champion GetRandomChampion()
    {
        if (championPool.Count == 0)
        {
            Debug.LogWarning("Champion pool is empty!");
            return null;
        }

        int randomIndex = Random.Range(0, championPool.Count);
        Champion randomChampion = championPool[randomIndex];
        championPool.RemoveAt(randomIndex);
        return randomChampion;
    }
}
