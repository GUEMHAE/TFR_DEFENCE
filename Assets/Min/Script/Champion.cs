using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultChampion", menuName = "AutoChess/Champion", order = 1)]
public class Champion : ScriptableObject
{
    /// ���� ������ ������ �������� è�Ǿ� ������
    public GameObject prefab;

    /// è�Ǿ��� ������ �� ������ ����ü ������
    public GameObject attackProjectile;

    /// UI �����ӿ� ǥ�õ� è�Ǿ� �̸�
    public string uiname;

    /// �������� è�Ǿ��� �����ϴ� �� �ʿ��� ��� ���
    public int cost;

    /// è�Ǿ��� ����
    public ChampionType type1;

    /// è�Ǿ��� ����
    public ChampionType type2;

    /// è�Ǿ� ĳ������ ���� �� ������ ������
    public float damage = 10;

    /// è�Ǿ��� ������ ������ �� �ִ� ����
    public float attackRange = 1;


    public string championName;

    // �̸��� �Ű������� �޴� ������
    public Champion(string name)
    {
        championName = name;
    }
}
