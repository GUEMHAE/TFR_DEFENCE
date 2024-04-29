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
    TMP_Text roundTime; //현재 라운드 시간 표시해주는 UI
    [SerializeField]
    TMP_Text _currentRound; //현재 라운드 표시 해주는 UI

    float _roundTime; //현재 라운드 시간 받아오는 변수

    [SerializeField]
    GameObject bossWarning;

    [SerializeField]
    Button synergyButton; //시너지 표시 버튼
    [SerializeField]
    GameObject synergyPannel; //시너지 표시 패널

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

    public void ActiveSynergyPannel() //시너지 표시 버튼 눌럿을때 시너지 패널 활성화
    {
        synergyButton.gameObject.SetActive(false);
        synergyPannel.SetActive(true);
    }

    public void QuitSynergyPannel() //시너지 표시 패널 닫기 버튼 눌럿을때 시너지 표시 버튼 활성화
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
        _currentRound.text = Round.instance.currentRound.ToString("F0")+"라운드";
    }
}
