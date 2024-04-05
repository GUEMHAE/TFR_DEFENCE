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

    public bool expRound = false; // ���� ���� ���� ���� ���� ����
    public int exp = 0; // ����ġ ���� �Լ�
    public TMP_Text expText;   // ����ġ�� ǥ���� �ؽ�Ʈ UI

    public bool isRound;

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

    void Update()
    {
        // ����ġ �ؽ�Ʈ ������Ʈ
        expText.text = "Experience: " + exp.ToString();
    }

    private async UniTaskVoid WaitRound()
    {
        while (currentRound <= totalRounds)
        {
            isRound = true;
            await UniTask.Delay(TimeSpan.FromMinutes(1f)); // 1�� ���
            Debug.Log("���ýð�") ;
            isRound = false;

            exp++;

            await UniTask.Delay(TimeSpan.FromSeconds(15f)); // 15�� ���ýð�
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
