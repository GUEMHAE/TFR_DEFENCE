using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Round : MonoBehaviour
{
    public static Round instance;

    public int totalRounds = 20; // �� ���� ��
    public int currentRound = 1; // ���� ����

    public bool isRound;
    public bool isLock = false;
    public Image lockimg;
    void Awake()
    {
        if (instance == null) //�̱��� ����
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private async UniTaskVoid WaitRound()
    {
        while (currentRound <= totalRounds)
        {
            isRound = true;
            isLock = false;
            lockimg.color = Color.white;
            await UniTask.WaitUntil(() => !TimeManager.instance.isRoundTime );

            Debug.Log("���ýð�");
            isRound = false;
            if (isLock == false)
            {
                RandomSprite_Unit.instance.RoundRandomSprite();
            }

            if(GameManager.instance.gold<10)
            {
                GameManager.instance.gold += 6;
            }
            else if (GameManager.instance.gold < 20)
            {
                GameManager.instance.gold += 7;
            }
            else if (GameManager.instance.gold < 30)
            {
                GameManager.instance.gold += 8;
            }
            else if (GameManager.instance.gold >= 30)
            {
                GameManager.instance.gold += 9;
            }

            await UniTask.WaitUntil(() => TimeManager.instance.isRoundTime);
            Debug.Log("���ýð� ����");

            currentRound++;
            EnemySpawnManager.instance.enemyCount = 0; //���� �� ������ ���� EnemySpawnManager�� enemyCount�� 0���� �ʱ�ȭ
        }

    }

    private void Start()
    {
        WaitRound().Forget();
    }
}
