using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionPool : MonoBehaviour
{
    // è�Ǿ� Ǯ
    public  List<Champion> championPool;

    void Start()
    {
        // è�Ǿ� Ǯ �ʱ�ȭ
        InitializeChampionPool();
    }

    // è�Ǿ� Ǯ �ʱ�ȭ �޼���
    private void InitializeChampionPool()
    {
        championPool = new List<Champion>();

        // ���÷� �־��� è�Ǿ���� �߰��մϴ�.
        championPool.Add(new Champion("��ϸ�"));
        championPool.Add(new Champion("�ƷϽ�"));
        championPool.Add(new Champion("�ٹٸ���"));
        championPool.Add(new Champion("�ٸ���"));
        championPool.Add(new Champion("�ֽ�"));
        championPool.Add(new Champion("�θ�"));
        championPool.Add(new Champion("�ǿ���"));
        championPool.Add(new Champion("�̸��ñ�"));
        championPool.Add(new Champion("�Ƽ���"));
        championPool.Add(new Champion("�Ƹ���"));
        championPool.Add(new Champion("ī��"));
        championPool.Add(new Champion("���θ�"));
        championPool.Add(new Champion("�Ϸ���"));
        championPool.Add(new Champion("��ũ"));
    }

    // è�Ǿ� Ǯ���� �����ϰ� è�Ǿ� �������� �޼���
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
