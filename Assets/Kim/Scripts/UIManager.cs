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

    Round round; //Round Ŭ���� �޾ƿ��� ���� ����

    float _roundTime; //���� ���� �ð� �޾ƿ��� ����

    void Start()
    {
        round = GetComponent<Round>();
    }

    void Update()
    {
        _roundTime = TimeManager.instance.roundTime; 
        roundTime.text = _roundTime.ToString("F0");
        _currentRound.text = round.currentRound.ToString("F0")+"����";
    }
}
