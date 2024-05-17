using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUnitInfo : MonoBehaviour, IUnit
{
    [SerializeField]
    UnitInfo unitInfo1; //UnitInfo스크립터블 오브젝트를 받아오기 위한 변수,1성
    [SerializeField]
    UnitInfo unitInfo2; //2성
    [SerializeField]
    UnitInfo unitInfo3; //3성

    [SerializeField]
    GameObject unitBorder1; //1성 유닛 테두리
    [SerializeField]
    GameObject unitBorder2; //2성 유닛 테두리
    [SerializeField]
    GameObject unitBorder3; //3성 유닛 테두리

    public string unitName; //유닛 이름
    public float attackSpeed; //공격 속도
    public float attackRange; //공격 범위
    public float ad; //유닛 ad
    public float ap;  //유닛 ap
    public float cost; //유닛 구매 가격
    public float sellCost; //유닛 판매 가격
    public GameObject attackProjectile; //유닛 공격 프로젝타일

    public UnitType[] unitType;

    public float originAD; //유닛의 원래 공격력 저장하는 변수
    public float originAP; //유닛의 원래 주문력 저장하는 변수
    public float originAS; //유닛의 원래 공격속도 저장하는 변수

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
    //Interface로 선언한 변수들을 정의하는 부분

    void Start()
    {
        if (gameObject.name.Substring(0, 2) == "1성")
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

        if (gameObject.name.Substring(0, 2) == "2성")
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

        if (gameObject.name.Substring(0, 2) == "3성")
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
