using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultChampion", menuName = "AutoChess/Champion", order = 1)]
public class Champion : ScriptableObject
{
    /// 게임 내에서 생성할 물리적인 챔피언 프리팹
    public GameObject prefab;

    /// 챔피언이 공격할 때 생성할 투사체 프리팹
    public GameObject attackProjectile;

    /// UI 프레임에 표시될 챔피언 이름
    public string uiname;

    /// 상점에서 챔피언을 구입하는 데 필요한 골드 비용
    public int cost;

    /// 챔피언의 유형
    public ChampionType type1;

    /// 챔피언의 유형
    public ChampionType type2;

    /// 챔피언 캐릭터의 공격 시 입히는 데미지
    public float damage = 10;

    /// 챔피언이 공격을 시작할 수 있는 범위
    public float attackRange = 1;


    public string championName;

    // 이름을 매개변수로 받는 생성자
    public Champion(string name)
    {
        championName = name;
    }
}
