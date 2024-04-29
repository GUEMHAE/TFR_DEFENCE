using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text roundTime; //���� ���� �ð� ǥ�����ִ� UI
    [SerializeField]
    TMP_Text _currentRound; //���� ���� ǥ�� ���ִ� UI

    float _roundTime; //���� ���� �ð� �޾ƿ��� ����

    [SerializeField]
    GameObject bossWarning;

    [SerializeField]
    Button synergyButton; //�ó��� ǥ�� ��ư
    [SerializeField]
    GameObject synergyPannel; //�ó��� ǥ�� �г�

    async UniTask BossWarning()
    {
        while(true)
        {
            if (Round.instance.currentRound % 5 == 0)
            {
                bossWarning.SetActive(true);
                await UniTask.Delay(5000);
                bossWarning.SetActive(false);
                await UniTask.WaitUntil(() => Round.instance.currentRound % 5 == 0);
            }
            await UniTask.WaitUntil(() => Round.instance.currentRound % 5 == 0);
        }
    }

    public void ActiveSynergyPannel() //�ó��� ǥ�� ��ư �������� �ó��� �г� Ȱ��ȭ
    {
        synergyButton.gameObject.SetActive(false);
        synergyPannel.SetActive(true);
    }

    public void QuitSynergyPannel() //�ó��� ǥ�� �г� �ݱ� ��ư �������� �ó��� ǥ�� ��ư Ȱ��ȭ
    {
        synergyButton.gameObject.SetActive(true);
        synergyPannel.SetActive(false);
    }


    private void Start()
    {
        BossWarning();
    }

    void Update()
    {
        _roundTime = TimeManager.instance.roundTime; 
        roundTime.text = _roundTime.ToString("F0");
        _currentRound.text = Round.instance.currentRound.ToString("F0")+"����";
    }
}
