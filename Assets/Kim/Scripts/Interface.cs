using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

interface IUnit
{
    string unitNameP { get; set; } //���� �̸� ������Ƽ
    float attackSpeedP { get; set; } //���� �ӵ� ������Ƽ
    float attackRangeP { get; set; } //���� ���� ������Ƽ
    float adP { get; set; }//���� ad ������Ƽ
    float apP { get; set; }//���� ap ������Ƽ
    float costP { get; set; }//���� ���� ���� ������Ƽ
    float sellCostP { get; set; }//���� �Ǹ� ���� ������Ƽ
    GameObject attackProjectileP { get; set; }
}