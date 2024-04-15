using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Enemy : MonoBehaviour
{
    //��ڻ��� towerDefense#01 ���� ����
    int wayPointCount;          //�̵� ��� ����
    Transform[] wayPoints;     //�̵� ��� ����
    int currentIndex = 0;       //���� ��ǥ���� �ε���
    EnemyMoveMent2D enemyMoveMent2D;  //������Ʈ �̵� ����
    public float hp;
    public float damage;

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
            Destroy(gameObject);
        }
    }

    private async UniTask OnMove() //���� ��ǥ������ �����ϴ� �Լ� ȣ��
    {
        //���� �̵� ���� ����
        NextMoveTo();

        while(true)
        {
            //���� ������ġ�� ��ǥ��ġ�� �Ÿ��� 0.02*EnemyMovement2D.MoveSpeed���� ���� �� if ���ǹ� ����
            //EnemyMovement2D.MoveSpeed�� �����ִ� ������ �ӵ��� ������ �� �����ӿ� 0.02���� ũ�� �����̱� ������
            //if���ǹ��� �ɸ��� �ʰ� ��θ� Ż���ϴ� ������Ʈ�� �߻��� �� �ִ�.
            if(Vector3.Distance(transform.position,wayPoints[currentIndex].position)<=0.03f*enemyMoveMent2D.MoveSpeed)
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
        if(currentIndex<wayPointCount-1)
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Projectile")
        {

            if (gameObject.transform != collision.GetComponent<AttackProjectile>().attackTarget) //���� ������ ���� ������ projectile�� attackTarget�� �浹 ó�� �ǰ� �ϴ� �ڵ�
            {
                return;
            }

            damage = collision.GetComponent<AttackProjectile>().damage; //projectile�� �������� �޾ƿ�
            hp -= damage; //���� �������� �޴� �ڵ�

            Destroy(collision); //projectile �ı�
        }

        if(collision.tag=="DarbamSkill")
        {
            damage = collision.GetComponent<DarbamSkill>().damage;
            hp -= damage;
        }

        if(collision.tag=="TonirSkill")
        {
            if (gameObject.transform != collision.GetComponent<TonirSkill>().attackTarget) //���� ������ ���� ������ projectile�� attackTarget�� �浹 ó�� �ǰ� �ϴ� �ڵ�
            {
                return;
            }
            damage = collision.GetComponent<TonirSkill>().damage;
            Debug.Log("��ϸ� ��ų ����");
        }
        hp -= damage;

        Destroy(collision);
    }

    private void Update()
    {
        Die();
    }
}
