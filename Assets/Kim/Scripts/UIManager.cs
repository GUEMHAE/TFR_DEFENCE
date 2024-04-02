using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text roundTime; //현재 라운드 시간 표시해주는 UI
    [SerializeField]
    TMP_Text _currentRound; //현재 라운드 표시 해주는 UI

    Round round; //Round 클래스 받아오기 위한 변수

    float _roundTime; //현재 라운드 시간 받아오는 변수

    void Start()
    {
        round = GetComponent<Round>();
    }

    void Update()
    {
        _roundTime = TimeManager.instance.roundTime; 
        roundTime.text = _roundTime.ToString("F0");
        _currentRound.text = round.currentRound.ToString("F0")+"라운드";
    }
}
