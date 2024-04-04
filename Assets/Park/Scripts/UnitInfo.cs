using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "UnitData", menuName = "Unit/UnitData", order = int.MaxValue)]
public class UnitInfo : ScriptableObject
{
    [SerializeField] private string unitName;
    public string UnitName { get { return unitName; } }
    [SerializeField] private int cost;
    public int Cost { get { return cost; } }
    [SerializeField] private int sellCost;
    public int SellCost { get { return sellCost; } }
    [SerializeField] private int grade;
    public int Grade { get { return grade; } }
    [SerializeField] private int ad;
    public int Ad { get { return ad; } }
    [SerializeField] private int ap;
    public int Ap { get { return ap; } }

    [SerializeField] private float attackSpeed;
    public float AttackSpeed { get { return attackSpeed; } }

    public UnitType[] type;


    public GameObject attackProjectile;
    [SerializeField] private float attackRange;
    public float AttackRange { get { return attackRange; } }
}
