using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class FirstBoss : MonoBehaviour
{
    public bool isInvincible;

    [SerializeField]
    float coolTime;
    [SerializeField]
    float duration;

    public GameObject shieldParticle;

    private void Start()
    {
        coolTime = 16f;
        duration = 4f;
        Invincible();
    }

    async UniTaskVoid Invincible() //������ ���� �����ϴ� UniTask
    {
        while (true)
        {
            var destroyToken = this.GetCancellationTokenOnDestroy();

            await UniTask.WaitForSeconds(coolTime, cancellationToken: destroyToken);//��Ÿ�� ���� ��� �� ���� Ȱ��ȭ
            isInvincible = true;
            GameObject shield = Instantiate(shieldParticle, transform.position, Quaternion.identity);
            shield.transform.SetParent(gameObject.transform);
            shield.transform.position += new Vector3(0,-0.5f,0);
            await UniTask.WaitForSeconds(duration, cancellationToken: destroyToken);//���ӽð� ���� ����
            isInvincible = false;
        }
    }
}
