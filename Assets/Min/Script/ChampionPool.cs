using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionPool : MonoBehaviour
{
    // è�Ǿ� Ǯ
    public List<ChampionShop.Champion> championPool; // ChampionShop.Champion�� ����

    void Start()
    {
        // è�Ǿ� Ǯ �ʱ�ȭ
        InitializeChampionPool();
    }

    // è�Ǿ� Ǯ �ʱ�ȭ �޼���
    private void InitializeChampionPool()
    {
        championPool = new List<ChampionShop.Champion>(); // ChampionShop.Champion�� ����

        // ���÷� �־��� è�Ǿ���� �߰��մϴ�.
        championPool.Add(new ChampionShop.Champion("��ϸ�", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("�ƷϽ�", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("�ٹٸ���", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("�ٸ���", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("�ֽ�", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("�θ�", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("�ǿ���", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("�̸��ñ�", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("�Ƽ���", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("�Ƹ���", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("ī��", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("���θ�", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("�Ϸ���", ChampionShop.ChampionRarity.Common));
        championPool.Add(new ChampionShop.Champion("��ũ", ChampionShop.ChampionRarity.Common));
    }

    // è�Ǿ� Ǯ���� �����ϰ� è�Ǿ� �������� �޼���
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
