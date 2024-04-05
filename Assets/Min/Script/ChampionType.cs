using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefauultChampionType", menuName = "AutoChess/ChampionType", order = 2)]
public class ChampionType : ScriptableObject
{
    /// UI�� ǥ�õǴ� �̸�
    public string displayName = "name";

    /// UI�� ǥ�õǴ� ��������Ʈ
    public Sprite icon;

    /// �� ChampionType�� ������ �ִ� ���ʽ�
    public SynergyManager championBonus;

}
