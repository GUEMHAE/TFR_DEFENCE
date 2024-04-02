using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public int totalRounds = 20; // �� ���� ��
    public int currentRound = 1; // ���� ����

    public bool isRound;

    private async UniTaskVoid WaitRound()
    {
        while (currentRound <= totalRounds)
        {
            isRound = true;
            await UniTask.Delay(TimeSpan.FromMinutes(1f)); // 1�� ���
            Debug.Log("���ýð�") ;
            isRound = false;
            await UniTask.Delay(TimeSpan.FromSeconds(15f)); // 15�� ���ýð�
            Debug.Log("���ýð� ����");

            currentRound++;
        }
    }

    private void Start()
    {
        WaitRound().Forget();
    }
}
