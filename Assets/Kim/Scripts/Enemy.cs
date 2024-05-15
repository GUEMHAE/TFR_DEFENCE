using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class Enemy : MonoBehaviour
{
    //고박사의 towerDefense#01 강의 참고
    int wayPointCount;          //이동 경로 개수
    Transform[] wayPoints;     //이동 경로 정보
    int currentIndex = 0;       //현재 목표지점 인덱스
    EnemyMoveMent2D enemyMoveMent2D;  //오브젝트 이동 제어
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

        //적 이동 경로 WayPoints 정보 설정
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        //적의 위치를 첫번째 wayPoint위치로 설정
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

    private async UniTask OnMove() //다음 목표지점을 설정하는 함수 호출
    {
        //다음 이동 방향 설정
        NextMoveTo();

        while (true)
        {
            Vector3 direction = wayPoints[currentIndex].position - transform.position;

            if (Vector3.Dot(direction, direction) <= 0.06f * 0.06f * enemyMoveMent2D.MoveSpeed * enemyMoveMent2D.MoveSpeed)
            {
                NextMoveTo();
            }

            var token = this.GetCancellationTokenOnDestroy();//파괴 됬을 때 UniTask취소
            await UniTask.Delay(0, cancellationToken: token);
        }
    }

    void NextMoveTo()
    {
        //아직 이동할 wayPoints가 남아있다면
        if (currentIndex < wayPointCount - 1)
        {
            //적의 위치를 정확하게 목표 위치로 설정
            transform.position = wayPoints[currentIndex].position;
            //이동 방향 설정 => 다음 목표지점(wayPoints)
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            enemyMoveMent2D.MoveTo(direction);
        }
        //현재 위치가 마지막 wayPoints이면
        else
        {
            //적 오브젝트 다시 waypoint0으로 향하게
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
            if (gameObject.transform != collision.GetComponent<AttackProjectile>().attackTarget) //적이 여러기 겹쳐 있을때 projectile의 attackTarget만 충돌 처리 되게 하는 코드
            {
                return;
            }

            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<AttackProjectile>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
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
                damage = collision.GetComponent<DarbamSkill>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
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
                damage = collision.GetComponent<TonirSkill>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }

            Destroy(collision.gameObject);
        }

        if (collision.tag == "BoureSkill")
        {
            if (gameObject.transform != collision.GetComponent<BoureSkill>().attackTarget) //적이 여러기 겹쳐 있을때 projectile의 attackTarget만 충돌 처리 되게 하는 코드
            {
                return;
            }

            Instantiate(boureSkillEffect, this.transform.position, Quaternion.identity);

            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<BoureSkill>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
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
                damage = collision.GetComponent<SnelSkill>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }

            Instantiate(SnelSkillEffect, this.transform.position, Quaternion.identity);
            Debug.Log("스넬 스킬 적중");

            Destroy(collision.gameObject);
        }

        if (collision.tag == "AroxProjectile")
        {

            if (gameObject.transform != collision.GetComponent<AttackProjectile>().attackTarget) //적이 여러기 겹쳐 있을때 projectile의 attackTarget만 충돌 처리 되게 하는 코드
            {
                return;
            }

            Instantiate(AroxAttackEffect, this.transform.position, Quaternion.identity);
            Debug.Log("아록스 평타 적중");

            if (firstBoss == null || firstBoss.isInvincible==false)
            {
                damage = collision.GetComponent<AttackProjectile>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
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
                damage = collision.GetComponent<AroxSkill>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
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
                damage = collision.GetComponent<BabarianSkill>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
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
                damage = collision.GetComponent<PionaSkill>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
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
                damage = collision.GetComponent<IrsigSkill>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
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
                damage = collision.GetComponent<AsusSkill>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }

        if (collision.tag == "ArteProjectile") //범위형 평타
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<ArteAttackProjectile>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }

        if (collision.tag == "ArteSkill")
        {
            if (gameObject.transform != collision.GetComponent<ArteSkill>().attackTarget) //적이 여러기 겹쳐 있을때 projectile의 attackTarget만 충돌 처리 되게 하는 코드
            {
                return;
            }

            void CallDamage()
            {
                hp -= damage;
            }

            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<ArteSkill>().damage; //projectile의 데미지를 받아옴
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
                damage = collision.GetComponent<ArteAttackProjectile>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }
        }

        if (collision.tag == "RlrorProjectile")
        {
            if (gameObject.transform != collision.GetComponent<AttackProjectile>().attackTarget) //적이 여러기 겹쳐 있을때 projectile의 attackTarget만 충돌 처리 되게 하는 코드
            {
                return;
            }

            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<AttackProjectile>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
            }

            else if (firstBoss != null && firstBoss.isInvincible == true)
            {
                return;
            }

            Debug.Log("를로르 평타 적중");
            Instantiate(RlrorProjectileEffect, this.gameObject.transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
        }

        if (collision.tag == "RlrorSkill")
        {
            if (firstBoss == null || firstBoss.isInvincible == false)
            {
                damage = collision.GetComponent<RlrorSkill>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
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
                damage = collision.GetComponent<ElectoSkill>().damage; //projectile의 데미지를 받아옴
                hp -= damage; //적이 데미지를 받는 코드
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
