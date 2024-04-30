using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using DG.Tweening;

public class Rlror : MonoBehaviour,IUnit
{
    public UnitInfo unitInfo; //UnitInfo��ũ���ͺ� ������Ʈ�� �޾ƿ��� ���� ����

    public GameObject enemy; //���� ����� �� ������ ��� ������Ʈ
    public float shortDis; //���� ����� ������ �Ÿ��� �����ϴ� ����
    public string tagName="Enemy"; //���� �±� �̸� �ʱ�ȭ
    public GameObject attackTarget;
    public GameObject dummy; //�ָ� ����߸� ���� ������Ʈ 

    public GameObject skillPrefab;
    Quaternion skillRotation; //��ų ������ �� ȸ����

    public float maxMana; //������ �ִ� ����
    public float currentMana; //������ ���� ����
    public float regenManaRate; //���� ȸ����

    public string unitName; //���� �̸�
    public float attackSpeed; //���� �ӵ�
    public float attackRange; //���� ����
    public float ad; //���� ad
    public float ap;  //���� ap
    public float cost; //���� ���� ����
    public float sellCost; //���� �Ǹ� ����
    public GameObject attackProjectile; //���� ���� ������Ÿ��
    public Transform attackSpawn; //���� ���� ���� ��ġ

    public GameObject stunEffect;
    [SerializeField]
    bool isStun;

    private CancellationTokenSource cancellationTokenSource; //�۾� ��� ��û�� �����ϱ� ���� ��ū

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
    //Interface�� ������ �������� �����ϴ� �κ�

    void SpawnProjectile()
    {
        GameObject clone = Instantiate(attackProjectile, attackSpawn.position, Quaternion.identity); //������Ÿ���� attackSpawn��ġ�� ����
        clone.GetComponent<AttackProjectile>().Targeting(enemy.transform);//���� ����� ���� Ÿ������
    }

    async UniTask AttackToTarget(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            if (EnemySpawnManager.instance.EnemyPool.childCount == 0)
            {
                enemy = dummy;
            }

            if (enemy==null) //���� null�̸�
            {
                await UniTask.WaitUntil(() => enemy != null);
            }
            if (Round.instance.isRound ==true && shortDis <= attackRange) //�ּҰŸ��� ���ݻ�Ÿ����� �۰ų� ���ٸ�
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1 / attackSpeed)); //���ݼӵ��� ����
                Debug.Log("���ݻ�������");
                if (EnemySpawnManager.instance.EnemyPool.childCount == 0)
                {
                    enemy = dummy;//2������� enemy�� missing���� ���� ������ ���ϴ� �� ���� ���� �ڵ�
                }
                if (enemy != dummy)//���̰� �ƴ� ��츸 ����
                {
                    var sequence = DOTween.Sequence();
                    sequence.Append(transform.DOScale(new Vector3(0.85f, 0.85f, 0.85f), 0.15f).SetEase(Ease.OutBounce));
                    sequence.Append(transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.15f).SetEase(Ease.InBounce));
                    SpawnProjectile(); //������Ÿ�� ����
                }
            }
            await UniTask.WaitUntil(() => enemy != null); //���� null�� �ƴҶ����� �ٽ� ���
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
            await UniTask.Delay(1000);//1�ʸ��� ���� ȸ��
            if (currentMana < maxMana)
            {
                currentMana += regenManaRate;
                currentMana = Mathf.Min(currentMana, maxMana);//���� ������ �ִ� ������ �ʰ����� �ʰ� �ϱ� ����
            }
        }
    }

    async UniTask bossSkillHit()
    {
        while (FirstBoss.instance != null)
        {
            if (FirstBoss.instance.isUseFirst == true)
            {
                HitFirstBossSkill();
                this.enabled = false;
                await UniTask.WaitUntil(() => !FirstBoss.instance.isUseFirst);
                isStun = false;
                this.enabled = true;
            }
            await UniTask.WaitUntil(() => FirstBoss.instance.isUseFirst);
        }
    }

    void HitFirstBossSkill()
    {
        isStun = true;
        if (isStun == true)
        {
            Instantiate(stunEffect, gameObject.transform.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        skillRotation = Quaternion.Euler(90f, 0f, 0f);
        bossSkillHit();
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
                GameObject SkillClone = Instantiate(skillPrefab, enemy.transform.position, skillRotation);
                SkillClone.GetComponent<RlrorSkill>().SkillTargeting(enemy.transform);//���� Ÿ������
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
