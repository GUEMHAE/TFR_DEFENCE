using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public int totalRounds = 20; // �� ���� ��
    private int currentRound = 1; // ���� ����

    private Text roundText; 

    private async UniTaskVoid WaitRound()
    {
        while (currentRound <= totalRounds)
        {
            await UniTask.Delay(TimeSpan.FromMinutes(1f)); // 1�� ���
            Debug.Log("���ýð�") ;
            await UniTask.Delay(TimeSpan.FromSeconds(15f)); // 15�� ���ýð�
            Debug.Log("���ýð� ����");

            roundText.text = "����: " + currentRound;
            currentRound++;
        }
    }

    private void Start()
    {
        WaitRound().Forget();
    }
}
