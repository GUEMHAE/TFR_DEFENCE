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
    string unitNameP { get; set; } //유닛 이름 프로퍼티
    float attackSpeedP { get; set; } //공격 속도 프로퍼티
    float attackRangeP { get; set; } //공격 범위 프로퍼티
    float adP { get; set; }//유닛 ad 프로퍼티
    float apP { get; set; }//유닛 ap 프로퍼티
    float costP { get; set; }//유닛 구매 가격 프로퍼티
    float sellCostP { get; set; }//유닛 판매 가격 프로퍼티
    GameObject attackProjectileP { get; set; }
}