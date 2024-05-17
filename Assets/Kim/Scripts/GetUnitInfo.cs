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

    public UnitType[] unitType;

    public float originAD; //������ ���� ���ݷ� �����ϴ� ����
    public float originAP; //������ ���� �ֹ��� �����ϴ� ����
    public float originAS; //������ ���� ���ݼӵ� �����ϴ� ����

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
            unitType = unitInfo1.type;
            originAD = unitInfo1.Ad;
            originAP = unitInfo1.Ap;
            originAS = unitInfo1.AttackSpeed;
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
            unitType = unitInfo2.type;
            originAD = unitInfo2.Ad;
            originAP = unitInfo2.Ap;
            originAS = unitInfo2.AttackSpeed;
        }

        if (gameObject.name.Substring(0, 2) == "3��")
        {
            unitBorder1.SetActive(false);
            unitBorder2.SetActive(false);
            unitBorder3.SetActive(true);
            unitNameP = unitInfo3.UnitName;
            attackSpeedP = unitInfo3.AttackSpeed;
            attackRangeP = unitInfo3.AttackRange;
            adP = unitInfo3.Ad;
            apP = unitInfo3.Ap;
            costP = unitInfo3.Cost;
            sellCostP = unitInfo3.SellCost;
            attackProjectileP = unitInfo3.attackProjectile;
            unitType = unitInfo3.type;
            originAD = unitInfo3.Ad;
            originAP = unitInfo3.Ap;
            originAS = unitInfo3.AttackSpeed;
        }
    }
}
