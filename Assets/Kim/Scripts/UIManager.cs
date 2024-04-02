using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text roundTime; //���� ���� �ð� ǥ�����ִ� UI
    [SerializeField]
    TMP_Text _currentRound; //���� ���� ǥ�� ���ִ� UI


    float _roundTime; //���� ���� �ð� �޾ƿ��� ����

    void Update()
    {
        _roundTime = TimeManager.instance.roundTime; 
        roundTime.text = _roundTime.ToString("F0");
        _currentRound.text = Round.instance.currentRound.ToString("F0")+"����";
    }
}
