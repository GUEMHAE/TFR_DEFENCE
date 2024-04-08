using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float roundTime; //���� ���� �ð� ����
    private bool isTime ;
    public static TimeManager instance; //�̱��� ����

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isTime = false;
    }

    void Update()
    {
        roundTime += Time.deltaTime;
        if (isTime == false && Round.instance.isRound == false)
        {
            roundTime = 0;
            isTime = true;
        }
        if (isTime == true && Round.instance.isRound == true)
        {
            roundTime = 0;
            isTime = false;
        }
    }
}
