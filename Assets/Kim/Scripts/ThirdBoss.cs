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

    private bool shieldHasRun; //���� ������ �̹� ��������� Ȯ��

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        coolTime = 14f;
        duration = 4f;
        Invincible();
        HpRegen();
        AddHp();
    }

    public async UniTaskVoid Invincible() //������ ���� �����ϴ� UniTask_ù��° ����
    {
        while (true)
        {
            var destroyToken = this.GetCancellationTokenOnDestroy();

            await UniTask.WaitForSeconds(coolTime, cancellationToken: destroyToken);//��Ÿ�� ���� ��� �� ���� Ȱ��ȭ
            isInvincible = true;
            GameObject shield = Instantiate(shieldParticle, transform.position, Quaternion.identity, transform);
            shield.transform.SetParent(gameObject.transform);
            shield.transform.localPosition += new Vector3(-0.6f, 1.8f, 0);
            shield.transform.localScale = new Vector3(12f, 12f, 1.5f); // �ʿ信 ���� ũ�� ����
            Destroy(shield, 4f); 
            await UniTask.WaitForSeconds(duration, cancellationToken: destroyToken);//���ӽð� ���� ����
            isInvincible = false;
        }
    }

    public async UniTaskVoid HpRegen() //�ι� ° ����
    {
        if (!shieldHasRun)
        {
            await UniTask.WaitUntil(() => enemy.hp <= 10000f);
            GameObject hpShield = Instantiate(hpShieldParticle, gameObject.transform);
            hpShield.transform.SetParent(gameObject.transform);
            hpShield.transform.localPosition += new Vector3(-0.6f, 1.8f, 0);
            hpShield.transform.localScale = new Vector3(1, 1, 1); // �ʿ信 ���� ũ�� ����
            curHp = enemy.hp;
            Debug.Log("����");
            await UniTask.WaitForSeconds(6f);//6�ʵ��� ������ ü���� 2000�̻� �޸� 1000ȸ��
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
            Debug.Log("HPȸ��");
            await UniTask.WaitUntil(() => enemy.currentIndex == 0);
        }
    }
}
