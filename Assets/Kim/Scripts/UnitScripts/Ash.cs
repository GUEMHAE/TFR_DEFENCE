using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using DG.Tweening;

public class Ash : MonoBehaviour
{
    public GameObject enemy; //���� ����� �� ������ ��� ������Ʈ
    public float shortDis; //���� ����� ������ �Ÿ��� �����ϴ� ����
    public string tagName="Enemy"; //���� �±� �̸� �ʱ�ȭ
    public GameObject attackTarget;
    public GameObject dummy; //�ָ� ����߸� ���� ������Ʈ 
    public GameObject usuallyProjectile; //��ų ���� �� ��Ÿ
    public GameObject skillProjectile; //��ų �� �� ��Ÿ
    private bool isSkillActive = false; // ��ų Ȱ��ȭ ����
    private float skillTimer = 0f; // ��ų ���� �ð� ī����

    GetUnitInfo getUnitInfo;

    public float maxMana; //������ �ִ� ����
    public float currentMana; //������ ���� ����
    public float regenManaRate; //���� ȸ����
    public Transform attackSpawn; //���� ���� ���� ��ġ

    public GameObject stunEffect;
    [SerializeField]
    bool isStun;

    private CancellationTokenSource cancellationTokenSource; //�۾� ��� ��û�� �����ϱ� ���� ��ū

  

    void SpawnProjectile()
    {
        GameObject clone = Instantiate(getUnitInfo.attackProjectile, attackSpawn.position, Quaternion.identity); //������Ÿ���� attackSpawn��ġ�� ����
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
            if (Round.instance.isRound ==true && shortDis <= getUnitInfo.attackRange) //�ּҰŸ��� ���ݻ�Ÿ����� �۰ų� ���ٸ�
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1 / getUnitInfo.attackSpeed)); //���ݼӵ��� ����
                Debug.Log("���ݻ�������");
                if (EnemySpawnManager.instance.EnemyPool.childCount == 0)
                {
                    enemy = dummy;//2������� enemy�� missing���� ���� ������ ���ϴ� �� ���� ���� �ڵ�
                }
                if (enemy != dummy)//���̰� �ƴ� ��츸 ����
                {
                    Attack(); //������Ÿ�� ����
                    var sequence = DOTween.Sequence();
                    sequence.Append(transform.DOScale(new Vector3(0.85f, 0.85f, 0.85f), 0.15f).SetEase(Ease.OutBounce));
                    sequence.Append(transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.15f).SetEase(Ease.InBounce));
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
            if (Round.instance.isRound == false)
            {
                currentMana = 0;
            }
            await UniTask.WaitUntil(() => Round.instance.isRound);
            await UniTask.Delay(1000);//1�ʸ��� ���� ȸ��
            if (currentMana < maxMana)
            {
                currentMana += regenManaRate;
                currentMana = Mathf.Min(currentMana, maxMana);//���� ������ �ִ� ������ �ʰ����� �ʰ� �ϱ� ����
            }

            if(currentMana==maxMana)
            {
                await UniTask.Delay(6000);
            }
        }
    }


    public void CheckManaAndActivateSkill()
    {
        
        if (currentMana == maxMana) // ������ 100 �̻��� �� ��ų Ȱ��ȭ
        {
            isSkillActive = true;
            SoundManager.instance.UnitEffectSound(6);
            getUnitInfo.attackSpeedP *= 1.4f; // ���� �ӵ� 1.4�� ����
            currentMana = 0;
        }
    }

    void Attack()
    {
        GameObject projectile = isSkillActive ? skillProjectile : getUnitInfo.attackProjectile;
        Instantiate(projectile, transform.position, Quaternion.identity);
        projectile.GetComponent<AttackProjectile>().Targeting(enemy.transform);
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

        CheckManaAndActivateSkill();

        if (isSkillActive)
        {
            skillTimer += Time.deltaTime;
            if (skillTimer > 6f) // 6�� �� ��ų ��Ȱ��ȭ
            {
                isSkillActive = false;
                getUnitInfo.attackSpeedP /= 1.4f; // ���� �ӵ� �������
                skillTimer = 0;
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
