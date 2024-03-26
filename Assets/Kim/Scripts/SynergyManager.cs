using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergyManager : MonoBehaviour
{
    public int light_num;           //빛(마나 회복) 시너지의 갯수
    public int dark_num;           //어둠(추가 고정 피해) 시너지의 갯수
    public int water_num;         //물(주문력 증가) 시너지의 갯수
    public int fire_num;            //불(초 당 추가 데미지)시너지의 갯수
    public int ground_num;      //땅(방어력,마법저항력 감소)시너지의 갯수
    public int air_num;            //바람(공격속도 증가,단계에 따라 시너지 효과 변경)시너지의 갯수

    public float manaregen=2; //초기 마나 회복량

    void Start()
    {
        
    }

    void Update()
    {
        switch(light_num)        //빛 시너지의 갯수에 따라 마나 회복 증가
        {
            case 0: 
                break;
            case 1:
                break;
            case 2:
                manaregen =2.5f;
                break;
            case 3:
                manaregen =3.5f;
                break;
            case 4:
                manaregen = 5f;
                break;
            case 5:
                manaregen = 7;
                break;
            default:
                break;
        }
    }
}
