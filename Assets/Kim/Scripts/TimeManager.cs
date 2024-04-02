using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float roundTime; //���� ���� �ð� ����

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
        
    }

    void Update()
    {
        roundTime += Time.deltaTime;
    }
}
