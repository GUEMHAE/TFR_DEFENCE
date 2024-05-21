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
            await UniTask.WaitUntil(() => !TimeManager.instance.isRoundTime);

            Debug.Log("���ýð�");
            isRound = false;

            bool goldGiven = false;

            int curGold=0;

            if (!goldGiven)
            {
                if (GameManager.instance.gold < 10)
                {
                    GameManager.instance.gold = curGold;
                    GameManager.instance.gold = curGold+5;
                }
                else if (GameManager.instance.gold < 20)
                {
                    GameManager.instance.gold = curGold;
                    GameManager.instance.gold = curGold + 6;
                }
                else if (GameManager.instance.gold < 30)
                {
                    GameManager.instance.gold = curGold;
                    GameManager.instance.gold = curGold + 7;
                }
                else if (GameManager.instance.gold >= 30)
                {
                    GameManager.instance.gold = curGold;
                    GameManager.instance.gold = curGold + 8;
                }
                goldGiven = true;
            }

            if (isLock == false)
            {
                RandomSprite_Unit.instance.RoundRandomSprite();
            }

            await UniTask.WaitUntil(() => TimeManager.instance.isRoundTime);
            Debug.Log("���ýð� ����");
            Exp.instance.exp += 1;
            Exp.instance.exping.text = Exp.instance.exp.ToString() + " / " + Exp.instance.expBar.ToString();
            currentRound++;
            EnemySpawnManager.instance.enemyCount = 0; //���� �� ������ ���� EnemySpawnManager�� enemyCount�� 0���� �ʱ�ȭ
        }
    }

    private void Start()
    {
        WaitRound();
    }
}
