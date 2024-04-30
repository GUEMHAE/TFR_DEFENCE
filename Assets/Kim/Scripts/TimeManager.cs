using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float roundTime=45f; //현재 라운드 시간 변수
    private bool isTime ;
    public static TimeManager instance; //싱글톤 패턴

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
        roundTime = 45f;
    }

    void Update()
    {
        roundTime -= Time.deltaTime;
        if (isTime == false && Round.instance.isRound == false)
        {
            roundTime = 15;
            isTime = true;
        }
        if (isTime == true && Round.instance.isRound == true)
        {
            roundTime = 45;
            isTime = false;
        }
    }
}
