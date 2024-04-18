using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefauultChampionType", menuName = "AutoChess/ChampionType", order = 2)]
public class ChampionType : ScriptableObject
{
    /// UI에 표시되는 이름
    public string displayName = "name";

    /// UI에 표시되는 스프라이트
    public Sprite icon;

    /// 이 ChampionType이 가지고 있는 보너스
    public SynergyManager championBonus;

}
