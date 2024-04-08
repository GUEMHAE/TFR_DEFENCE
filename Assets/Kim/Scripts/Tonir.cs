using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class Tonir : MonoBehaviour,IUnit
{
    public UnitInfo unitInfo; //UnitInfo스크립터블 오브젝트를 받아오기 위한 변수

    public GameObject enemy; //가장 가까운 적 유닛을 담는 오브젝트

    public List<GameObject> foundEnemy = new List<GameObject>(); //콜라이더에 들어온 적 유닛을 담는 리스트
    public float shortDis; //가장 가까운 적과의 거리를 저장하는 변수
    public string tagName="Enemy"; //적의 태그 이름 초기화
    public Transform attackTarget;

    public string unitName; //유닛 이름
    public float attackSpeed; //공격 속도
    public float attackRange; //공격 범위
    public float ad; //유닛 ad
    public float ap;  //유닛 ap
    public float cost; //유닛 구매 가격
    public float sellCost; //유닛 판매 가격
    public GameObject attackProjectile; //유닛 공격 프로젝타일
    public Transform attackSpawn; //유닛 공격 시작 위치

    public CircleCollider2D circleCollider;

    public string unitNameP
    {
        get => unitName;
        set=>unitName = value;
    }
    public float attackSpeedP
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }    
    public float  attackRangeP
    {
        get => attackRange;
        set => attackRange = value;
    }
    public float adP
    {
        get => ad;
        set => ad= value;
    }
    public float apP
    {
        get => ap;
        set => ap=value;
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
        set => attackProjectile=value;
    }
    //Interface로 선언한 변수들을 정의하는 부분

    void SpawnProjectile()
    {
        GameObject clone = Instantiate(attackProjectile, attackSpawn.position, Quaternion.identity); //프로젝타일은 attackSpawn위치에 생성
        clone.GetComponent<AttackProjectile>().Targeting(enemy.transform);//가장 가까운 적을 타게팅함
    }

    async UniTask AttackToTarget()
    {
        while (true)
        {
            if(enemy==null) //적이 null이면
            {
                await UniTask.WaitUntil(() => enemy != null); //적이 null이 아닐때까지 기다림
            }
            if (shortDis <= attackRange) //최소거리가 공격사거리보다 작거나 같다면
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1 / attackSpeedP)); //공격속도에 맞춰
                SpawnProjectile(); //프로젝타일 생성
            }
            await UniTask.WaitUntil(() => enemy != null); //적이 널이 아닐때까지 다시 대기
        }
    }

    void Start()
    {
        AttackToTarget();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        unitNameP = unitInfo.UnitName;
        attackSpeedP = unitInfo.AttackSpeed;
        attackRangeP = unitInfo.AttackRange;
        adP = unitInfo.Ad;
        apP = unitInfo.Ap;
        costP = unitInfo.Cost;
        sellCostP = unitInfo.SellCost;
        attackProjectileP = unitInfo.attackProjectile;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag==tagName)
        {
            if (!foundEnemy.Contains(other.gameObject)) //이미 리스트에 들어있는 적 리스트에 추가 안함
            {
                foundEnemy.Add(other.gameObject);
            }
         shortDis = Vector3.Distance(gameObject.transform.position, foundEnemy[0].transform.position);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)//호출될때마다 가장 가까운 적만을 찾음
    {
        if (collision = circleCollider)
        {
            if (collision.tag == tagName)
            {
                float shortestDistance = float.MaxValue;
                GameObject nearestEnemy = null;

                foreach (GameObject found in foundEnemy)
                {
                    float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

                    if (Distance < shortestDistance)
                    {
                        nearestEnemy = found;
                        shortestDistance = Distance;
                    }
                }
                enemy = nearestEnemy;
                shortDis = shortestDistance;

                if (enemy == null)
                {
                    shortDis = 0;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foundEnemy.Remove(collision.gameObject);
    }
}
