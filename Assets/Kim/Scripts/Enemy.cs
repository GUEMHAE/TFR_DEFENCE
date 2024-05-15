using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class Enemy : MonoBehaviour
{
    //��ڻ��� towerDefense#01 ���� ����
    int wayPointCount;          //�̵� ��� ����
    Transform[] wayPoints;     //�̵� ��� ����
    int currentIndex = 0;       //���� ��ǥ���� �ε���
    EnemyMoveMent2D enemyMoveMent2D;  //������Ʈ �̵� ����
    public float hp;
    public float damage;

    [SerializeField]
    GameObject boureSkillEffect;
    [SerializeField]
    GameObject babarianSkillEffect;
    [SerializeField]
    GameObject SnelSkillEffect;
    [SerializeField]
    GameObject AroxAttackEffect;
    [SerializeField]
    GameObject IrsigSkillEffect;
    [SerializeField]
    GameObject RlrorProjectileEffect;

    Animator animator;

    [SerializeField]
    FirstBoss firstBoss;

    public void Setup(Transform[] wayPoints)
    {
        enemyMoveMent2D = GetComponent<EnemyMoveMent2D>();

        //�� �̵� ��� WayPoints ���� ����
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        //���� ��ġ�� ù��° wayPoint��ġ�� ����
        transform.position = wayPoints[currentIndex].position;

        OnMove();
    }

    public void Die()
    {
        if (hp <= 0)
        {
            animator.SetInteger("State", 9);
            gameObject.tag = "Untagged";
            Destroy(gameObject, 1f);
        }
    }

    private async UniTask OnMove() //���� ��ǥ������ �����ϴ� �Լ� ȣ��
    {
        //���� �̵� ���� ����
        NextMoveTo();

        while (true)
        {
            Vector3 direction = wayPoints[currentIndex].position - transform.position;

            if (Vector3.Dot(direction, direction) <= 0.06f * 0.06f * enemyMoveMent2D.MoveSpeed * enemyMoveMent2D.MoveSpeed)
            {
                NextMoveTo();
            }

            var token = this.GetCancellationTokenOnDestroy();//�ı� ���� �� UniTask���
            await UniTask.Delay(0, cancellationToken: token);
        }
    }

    void NextMoveTo()
    {
        //���� �̵��� wayPoints�� �����ִٸ�
        if (currentIndex < wayPointCount - 1)
        {
            //���� ��ġ�� ��Ȯ�ϰ� ��ǥ ��ġ�� ����
            transform.position = wayPoints[currentIndex].position;
            //�̵� ���� ���� => ���� ��ǥ����(wayPoints)
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            enemyMoveMent2D.MoveTo(direction);
        }
        //���� ��ġ�� ������ wayPoints�̸�
        else
        {
            //�� ������Ʈ �ٽ� waypoint0���� ���ϰ�
            currentIndex = 0;
        }

        if (currentIndex == 1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (currentIndex == 2)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (currentIndex == 3)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(180, 0, 180);
        }

        if (currentIndex == 4)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
        }

        if (currentIndex == 5)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            if (gameObject.transform != collision.GetComponent<AttackProjectile>().attackTarget) //���� ������ ���� ������ projectile�� attackTarget�� �浹 ó�� �ǰ� �ϴ� �ڵ�
            {
                return;
            }

            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<AttackProjectile>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }
            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }

            Destroy(collision.gameObject);
        }

        if (collision.tag == "DarbamSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<DarbamSkill>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }

        if (collision.tag == "TonirSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<TonirSkill>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }

            Destroy(collision.gameObject);
        }

        if (collision.tag == "BoureSkill")
        {
            if (gameObject.transform != collision.GetComponent<BoureSkill>().attackTarget) //���� ������ ���� ������ projectile�� attackTarget�� �浹 ó�� �ǰ� �ϴ� �ڵ�
            {
                return;
            }

            Instantiate(boureSkillEffect, this.transform.position, Quaternion.identity);

            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<BoureSkill>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }

            Destroy(collision.gameObject);
        }

        if (collision.tag == "SnelSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<SnelSkill>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }

            Instantiate(SnelSkillEffect, this.transform.position, Quaternion.identity);
            Debug.Log("���� ��ų ����");

            Destroy(collision.gameObject);
        }

        if (collision.tag == "AroxProjectile")
        {

            if (gameObject.transform != collision.GetComponent<AttackProjectile>().attackTarget) //���� ������ ���� ������ projectile�� attackTarget�� �浹 ó�� �ǰ� �ϴ� �ڵ�
            {
                return;
            }

            Instantiate(AroxAttackEffect, this.transform.position, Quaternion.identity);
            Debug.Log("�ƷϽ� ��Ÿ ����");

            if (firstBoss == null || firstBoss.isInvincible==false)
            {
                damage = collision.GetComponent<AttackProjectile>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }

            Destroy(collision.gameObject);
        }

        if (collision.tag == "AroxSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<AroxSkill>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }

        if (collision.tag == "BabarianSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<BabarianSkill>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
            Instantiate(babarianSkillEffect, this.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "PionaSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<PionaSkill>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }

            Destroy(collision.gameObject);
        }

        if (collision.tag == "IrsigSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<IrsigSkill>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }

        if (collision.tag == "AsusSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<AsusSkill>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }

        if (collision.tag == "ArteProjectile") //������ ��Ÿ
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<ArteAttackProjectile>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }

        if (collision.tag == "ArteSkill")
        {
            if (gameObject.transform != collision.GetComponent<ArteSkill>().attackTarget) //���� ������ ���� ������ projectile�� attackTarget�� �浹 ó�� �ǰ� �ϴ� �ڵ�
            {
                return;
            }

            void CallDamage()
            {
                hp -= damage;
            }

            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<ArteSkill>().damage; //projectile�� �������� �޾ƿ�
                Invoke("CallDamage", 1f);
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }

        if (collision.tag == "KamuemSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<ArteAttackProjectile>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }

        if (collision.tag == "RlrorProjectile")
        {
            if (gameObject.transform != collision.GetComponent<AttackProjectile>().attackTarget) //���� ������ ���� ������ projectile�� attackTarget�� �浹 ó�� �ǰ� �ϴ� �ڵ�
            {
                return;
            }

            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<AttackProjectile>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }

            Debug.Log("���θ� ��Ÿ ����");
            Instantiate(RlrorProjectileEffect, this.gameObject.transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
        }

        if (collision.tag == "RlrorSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<RlrorSkill>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }

        if (collision.tag == "ElectoSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<ElectoSkill>().damage; //projectile�� �������� �޾ƿ�
                hp -= damage; //���� �������� �޴� �ڵ�
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Die();
    }
}
