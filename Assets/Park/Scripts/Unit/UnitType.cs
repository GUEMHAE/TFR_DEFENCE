using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitType", menuName = "Unit/UnitType", order = int.MaxValue)]

public class UnitType : ScriptableObject
{
    public string displayName = "name";
    public Sprite Synergyicon;
}
