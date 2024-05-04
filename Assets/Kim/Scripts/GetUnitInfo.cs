using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUnitInfo : MonoBehaviour, IUnit
{
    [SerializeField]
    UnitInfo unitInfo1; //UnitInfo��ũ���ͺ� ������Ʈ�� �޾ƿ��� ���� ����,1��
    [SerializeField]
    UnitInfo unitInfo2; //2��
    [SerializeField]
    UnitInfo unitInfo3; //3��

    [SerializeField]
    GameObject unitBorder1; //1�� ���� �׵θ�
    [SerializeField]
    GameObject unitBorder2; //2�� ���� �׵θ�
    [SerializeField]
    GameObject unitBorder3; //3�� ���� �׵θ�

    public string unitName; //���� �̸�
    public float attackSpeed; //���� �ӵ�
    public float attackRange; //���� ����
    public float ad; //���� ad
    public float ap;  //���� ap
    public float cost; //���� ���� ����
    public float sellCost; //���� �Ǹ� ����
    public GameObject attackProjectile; //���� ���� ������Ÿ��

    public string unitNameP
    {
        get => unitName;
        set => unitName = value;
    }
    public float attackSpeedP
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }
    public float attackRangeP
    {
        get => attackRange;
        set => attackRange = value;
    }
    public float adP
    {
        get => ad;
        set => ad = value;
    }
    public float apP
    {
        get => ap;
        set => ap = value;
    }
    public float costP
    {
        get => cost;
        set => cost = value;
    }
    public float sellCostP
    {
        get => sellCost;
        set => sellCost = value;
    }
    public GameObject attackProjectileP
    {
        get => attackProjectile;
        set => attackProjectile = value;
    }
    //Interface�� ������ �������� �����ϴ� �κ�

    void Start()
    {
        if (gameObject.name.Substring(0, 2) == "1��")
        {
            unitNameP = unitInfo1.UnitName;
            attackSpeedP = unitInfo1.AttackSpeed;
            attackRangeP = unitInfo1.AttackRange;
            adP = unitInfo1.Ad;
            apP = unitInfo1.Ap;
            costP = unitInfo1.Cost;
            sellCostP = unitInfo1.SellCost;
            attackProjectileP = unitInfo1.attackProjectile;
        }
        if (gameObject.name.Substring(0, 2) == "2��")
        {
            unitBorder1.SetActive(false);
            unitBorder2.SetActive(true);
            unitNameP = unitInfo2.UnitName;
            attackSpeedP = unitInfo2.AttackSpeed;
            attackRangeP = unitInfo2.AttackRange;
            adP = unitInfo2.Ad;
            apP = unitInfo2.Ap;
            costP = unitInfo2.Cost;
            sellCostP = unitInfo2.SellCost;
            attackProjectileP = unitInfo2.attackProjectile;
        }
        if (gameObject.name.Substring(0, 2) == "3��")
        {
            unitBorder1.SetActive(false);
            unitBorder2.SetActive(false);
            unitBorder3.SetActive(true);
            unitNameP = unitInfo2.UnitName;
            attackSpeedP = unitInfo2.AttackSpeed;
            attackRangeP = unitInfo2.AttackRange;
            adP = unitInfo2.Ad;
            apP = unitInfo2.Ap;
            costP = unitInfo2.Cost;
            sellCostP = unitInfo2.SellCost;
            attackProjectileP = unitInfo3.attackProjectile;
        }
    }
}
