using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class ThirdBoss : MonoBehaviour
{
    public bool isInvincible;

    [SerializeField]
    float coolTime;
    [SerializeField]
    float duration;

    public GameObject shieldParticle;
    public GameObject hpShieldParticle;
    public GameObject hpRegen;

    [SerializeField]
    Enemy enemy;

    float curHp;

    private bool shieldHasRun; //쉴드 패턴이 이미 실행됬는지 확인

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        coolTime = 14f;
        duration = 4f;
        Invincible();
        HpRegen();
        AddHp();
    }

    public async UniTaskVoid Invincible() //보스의 무적 관리하는 UniTask_첫번째 패턴
    {
        while (true)
        {
            var destroyToken = this.GetCancellationTokenOnDestroy();

            await UniTask.WaitForSeconds(coolTime, cancellationToken: destroyToken);//쿨타임 동안 대기 후 무적 활성화
            isInvincible = true;
            GameObject shield = Instantiate(shieldParticle, transform.position, Quaternion.identity, transform);
            shield.transform.SetParent(gameObject.transform);
            shield.transform.localPosition += new Vector3(-0.6f, 1.8f, 0);
            shield.transform.localScale = new Vector3(12f, 12f, 1.5f); // 필요에 따라 크기 조절
            Destroy(shield, 4f); 
            await UniTask.WaitForSeconds(duration, cancellationToken: destroyToken);//지속시간 동안 무적
            isInvincible = false;
        }
    }

    public async UniTaskVoid HpRegen() //두번 째 패턴
    {
        if (!shieldHasRun)
        {
            await UniTask.WaitUntil(() => enemy.hp <= 10000f);
            GameObject hpShield = Instantiate(hpShieldParticle, gameObject.transform);
            hpShield.transform.SetParent(gameObject.transform);
            hpShield.transform.localPosition += new Vector3(-0.6f, 1.8f, 0);
            hpShield.transform.localScale = new Vector3(1, 1, 1); // 필요에 따라 크기 조절
            curHp = enemy.hp;
            Debug.Log("실행");
            await UniTask.WaitForSeconds(6f);//6초동안 보스의 체력이 2000이상 달면 1000회복
            if (curHp - 5000 > enemy.hp)
            {
                GameObject heal = Instantiate(hpRegen, gameObject.transform);
                heal.transform.SetParent(gameObject.transform);
                enemy.hp += 2500;
            }
            shieldHasRun = true;
        }
    }

    public async UniTaskVoid AddHp()
    {
        while(true)
        {
            await UniTask.WaitUntil(() => enemy.currentIndex == 5);
            enemy.hp += 500;
            Debug.Log("HP회복");
            await UniTask.WaitUntil(() => enemy.currentIndex == 0);
        }
    }
}
