using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class Tonir : MonoBehaviour,IUnit
{
    public UnitInfo unitInfo; //UnitInfo��ũ���ͺ� ������Ʈ�� �޾ƿ��� ���� ����

    public GameObject enemy; //���� ����� �� ������ ��� ������Ʈ

    public List<GameObject> foundEnemy = new List<GameObject>(); //�ݶ��̴��� ���� �� ������ ��� ����Ʈ
    public float shortDis; //���� ����� ������ �Ÿ��� �����ϴ� ����
    public string tagName="Enemy"; //���� �±� �̸� �ʱ�ȭ
    public Transform attackTarget;

    public string unitName; //���� �̸�
    public float attackSpeed; //���� �ӵ�
    public float attackRange; //���� ����
    public float ad; //���� ad
    public float ap;  //���� ap
    public float cost; //���� ���� ����
    public float sellCost; //���� �Ǹ� ����
    public GameObject attackProjectile; //���� ���� ������Ÿ��
    public Transform attackSpawn; //���� ���� ���� ��ġ

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
    //Interface�� ������ �������� �����ϴ� �κ�

    void SpawnProjectile()
    {
        GameObject clone = Instantiate(attackProjectile, attackSpawn.position, Quaternion.identity); //������Ÿ���� attackSpawn��ġ�� ����
        clone.GetComponent<AttackProjectile>().Targeting(enemy.transform);//���� ����� ���� Ÿ������
    }

    async UniTask AttackToTarget()
    {
        while (true)
        {
            if(enemy==null) //���� null�̸�
            {
                await UniTask.WaitUntil(() => enemy != null); //���� null�� �ƴҶ����� ��ٸ�
            }
            if (shortDis <= attackRange) //�ּҰŸ��� ���ݻ�Ÿ����� �۰ų� ���ٸ�
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1 / attackSpeedP)); //���ݼӵ��� ����
                SpawnProjectile(); //������Ÿ�� ����
            }
            await UniTask.WaitUntil(() => enemy != null); //���� ���� �ƴҶ����� �ٽ� ���
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
            if (!foundEnemy.Contains(other.gameObject)) //�̹� ����Ʈ�� ����ִ� �� ����Ʈ�� �߰� ����
            {
                foundEnemy.Add(other.gameObject);
            }
         shortDis = Vector3.Distance(gameObject.transform.position, foundEnemy[0].transform.position);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)//ȣ��ɶ����� ���� ����� ������ ã��
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
