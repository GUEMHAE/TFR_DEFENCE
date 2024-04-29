using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class Piona : MonoBehaviour,IUnit
{
    public UnitInfo unitInfo; //UnitInfo스크립터블 오브젝트를 받아오기 위한 변수

    public GameObject enemy; //가장 가까운 적 유닛을 담는 오브젝트
    public float shortDis; //가장 가까운 적과의 거리를 저장하는 변수
    public string tagName="Enemy"; //적의 태그 이름 초기화
    public GameObject attackTarget;
    public GameObject dummy; //멀리 떨어뜨린 더미 오브젝트 

    public GameObject skillPrefab;
    Vector3 spawnPosition = new Vector3(0, 1, 0);

    public float maxMana; //유닛의 최대 마나
    public float currentMana; //유닛의 현재 마나
    public float regenManaRate; //마나 회복량

    public string unitName; //유닛 이름
    public float attackSpeed; //공격 속도
    public float attackRange; //공격 범위
    public float ad; //유닛 ad
    public float ap;  //유닛 ap
    public float cost; //유닛 구매 가격
    public float sellCost; //유닛 판매 가격
    public GameObject attackProjectile; //유닛 공격 프로젝타일
    public Transform attackSpawn; //유닛 공격 시작 위치

    public GameObject stunEffect;
    [SerializeField]
    bool isStun;

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
            if (EnemySpawnManager.instance.EnemyPool.childCount == 0)
            {
                enemy = dummy;
            }

            if (enemy==null) //적이 null이면
            {
                await UniTask.WaitUntil(() => enemy != null);
            }
            if (Round.instance.isRound ==true && shortDis <= attackRange) //최소거리가 공격사거리보다 작거나 같다면
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1 / attackSpeed)); //공격속도에 맞춰
                Debug.Log("공격생성직전");
                if (EnemySpawnManager.instance.EnemyPool.childCount == 0)
                {
                    enemy = dummy;//2라운드부터 enemy가 missing으로 변해 공격을 안하는 걸 막기 위한 코드
                }
                if (enemy != dummy)//더미가 아닐 경우만 공격
                {
                    SpawnProjectile(); //프로젝타일 생성
                }
            }
            await UniTask.WaitUntil(() => enemy != null); //적이 null이 아닐때까지 다시 대기
        }
    }

    void CheckEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tagName);

        shortDis = float.MaxValue;
        foreach(GameObject enemyObject in enemies)
        {
            float distance = Vector3.Distance(gameObject.transform.position, enemyObject.transform.position);
            if(distance<shortDis)
            {
                enemy = enemyObject;
                shortDis = distance;
            }
        }
    }

    async UniTask RegenMana()
    {
        while (true)
        {
            await UniTask.Delay(1000);//1초마다 마나 회복
            if (currentMana < maxMana)
            {
                currentMana += regenManaRate;
                currentMana = Mathf.Min(currentMana, maxMana);//현재 마나가 최대 마나를 초과하지 않게 하기 위해
            }
        }
    }

    void Start()
    {
        AttackToTarget();
        RegenMana();
        enabled = false;
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
        regenManaRate = 4f;
    }

    private void Update()
    {
        CheckEnemies();
        if (currentMana == maxMana)
        {
            if (enemy != null && enemy != dummy)
            {
                currentMana = 0;
                GameObject SkillClone = Instantiate(skillPrefab, enemy.transform.position+ spawnPosition, Quaternion.identity);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Grid" && FirstBoss.instance.isUseFirst == false)
        {
            enabled = true;
            isStun = false;
        }
        if (other.tag == "Wait" || FirstBoss.instance.isUseFirst == true)
        {
            if (isStun == false)
            {
                Instantiate(stunEffect, gameObject.transform.position, Quaternion.identity);
            }
            isStun = true;
            enabled = false;
        }
    }
}
