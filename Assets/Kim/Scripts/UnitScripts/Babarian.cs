using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using DG.Tweening;

public class Babarian : MonoBehaviour
{

    public GameObject enemy; //가장 가까운 적 유닛을 담는 오브젝트
    public float shortDis; //가장 가까운 적과의 거리를 저장하는 변수
    public string tagName="Enemy"; //적의 태그 이름 초기화
    public GameObject attackTarget;
    public GameObject dummy; //멀리 떨어뜨린 더미 오브젝트 

    public GameObject skillPrefab;

    GetUnitInfo getUnitInfo;

    public float maxMana; //유닛의 최대 마나
    public float currentMana; //유닛의 현재 마나
    public float regenManaRate; //마나 회복량

    public Transform attackSpawn; //유닛 공격 시작 위치

    public GameObject stunEffect;
    [SerializeField]
    bool isStun;

    private CancellationTokenSource cancellationTokenSource; //작업 취소 요청을 감지하기 위한 토큰

    void SpawnProjectile()
    {
        GameObject clone = Instantiate(getUnitInfo.attackProjectile, attackSpawn.position, Quaternion.identity); //프로젝타일은 attackSpawn위치에 생성
        clone.GetComponent<AttackProjectile>().Targeting(enemy.transform);//가장 가까운 적을 타게팅함
        var projectileScript = clone.GetComponent<AttackProjectile>();

        float damage = getUnitInfo.ad > 0 ? getUnitInfo.ad : getUnitInfo.ap; // ad 또는 ap 값을 사용
        projectileScript.SetDamage(damage);
    }

    async UniTask AttackToTarget(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            if (EnemySpawnManager.instance.EnemyPool.childCount == 0)
            {
                enemy = dummy;
            }

            if (enemy==null) //적이 null이면
            {
                await UniTask.WaitUntil(() => enemy != null);
            }
            if (Round.instance.isRound ==true && shortDis <= getUnitInfo.attackRange) //최소거리가 공격사거리보다 작거나 같다면
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1 / getUnitInfo.attackSpeed)); //공격속도에 맞춰
                Debug.Log("공격생성직전");
                if (EnemySpawnManager.instance.EnemyPool.childCount == 0)
                {
                    enemy = dummy;//2라운드부터 enemy가 missing으로 변해 공격을 안하는 걸 막기 위한 코드
                }
                if (enemy != dummy)//더미가 아닐 경우만 공격
                {
                    var sequence = DOTween.Sequence();
                    sequence.Append(transform.DOScale(new Vector3(0.85f, 0.85f, 0.85f), 0.15f).SetEase(Ease.OutBounce));
                    sequence.Append(transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.15f).SetEase(Ease.InBounce));
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

    async UniTask RegenMana(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            if (Round.instance.isRound == false)
            {
                currentMana = 0;
            }
            await UniTask.WaitUntil(() => Round.instance.isRound);
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
        getUnitInfo = GetComponent<GetUnitInfo>();
        enabled = false;
    }

    private void OnEnable()
    {
        regenManaRate = 4f;
        cancellationTokenSource = new CancellationTokenSource();
        AttackToTarget(cancellationTokenSource.Token);
        RegenMana(cancellationTokenSource.Token);
    }

    private void OnDisable()
    {
        cancellationTokenSource.Cancel();
    }

    private void Update()
    {
        CheckEnemies();
        if (currentMana == maxMana)
        {
            if (enemy != null && enemy != dummy)
            {
                currentMana = 0;
                GameObject SkillClone = Instantiate(skillPrefab, attackSpawn.transform.position, Quaternion.identity);
                SkillClone.GetComponent<BabarianSkill>().SkillTargeting(enemy.transform);//적을 타게팅함
                currentMana = 0;
                var projectileScript = SkillClone.GetComponent<BabarianSkill>();

                float damage = getUnitInfo.ad > 0 ? getUnitInfo.ad : getUnitInfo.ap; // ad 또는 ap 값을 사용
                projectileScript.SetDamage(damage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isStun == true || other.tag == "Wait")
        {
            enabled = false;
        }
        else if (other.tag == "Grid" && isStun == false)
        {
            enabled = true;
        }
    }
}
