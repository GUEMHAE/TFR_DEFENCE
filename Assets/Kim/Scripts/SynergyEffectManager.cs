using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergyEffectManager : MonoBehaviour
{
    public int light_num;            //신성(마나 회복) 시너지의 갯수
    public int dark_num;            //암영(추가 고정 피해) 시너지의 갯수
    public int water_num;          //기원(주문력 증가) 시너지의 갯수
    public int fire_num;             //황혼(공격력 증가)시너지의 갯수
    public int ground_num;       //근원(공격 시 방어력,마법저항력 감소)시너지의 갯수
    public int air_num;             //천공(단일로 썻을 시 팀 전체 공격 속도 증가)시너지의 갯수

    public float mana_regen = 2;  //플레이어 유닛의 초기 마나 회복량
    public float playerDamege;  //플레이어 유닛의 추가고정피해 계산을 위한 플레이어의 데미지를 받아오는 변수
    public float trueDamage;    //플레이어 유닛의 추가 고정피해
    public float damage;         //플레이어 유닛이 주는 피해+고정피해
    public float ap;                //플레이어 유닛의 주문력
    public float ad;                //플레이어 유닛의 공격력
    public float armor;           //적의 방어력
    public float ability_resist;   //적의 마법저항력
    public float team_attack_spd; //플레이어 유닛의 추가 공격속도

    void Start()
    {
        trueDamage = 0; //초기 추가 고정피해 0으로 초기화
        team_attack_spd = 1f; //초기 추가 공격속도 1로 초기화
    }

    void Update()
    {

    }

    void Light_Synergy()
    {
        switch (light_num)        //빛 시너지의 갯수에 따라 마나 회복량 증가
        {
            case 0:
                break;
            case 1:
                mana_regen += 1f;
                break;
            case 2:
                mana_regen += 2f;
                break;
            case 3:
                mana_regen += 3.5f;
                break;
            case 4:
                mana_regen += 5f;
                break;
            case 5:
                mana_regen += 8f;
                break;
            default:
                break;
        }
    }

    void Dark_Synergy()
    {
        switch (dark_num)  //어둠 시너지의 갯수에 따라 추가 고정피해,고정피해 계산은 유닛의 원래 데미지*고정피해 계수
        {
            case 0:
                break;
            case 1:
                trueDamage = playerDamege * 0.05f;
                damage = trueDamage + playerDamege;
                if (trueDamage < 1) //고정 피해가 1보다 적을시 최소 고정피해 1로 고정
                    trueDamage = 1;
                break;
            case 2:
                trueDamage = playerDamege * 0.15f;
                damage = trueDamage + playerDamege;
                if (trueDamage < 1)
                    trueDamage = 1;
                break;
            case 3:
                trueDamage = playerDamege * 0.3f;
                damage = trueDamage + playerDamege;
                if (trueDamage < 1)
                    trueDamage = 1;
                break;
            case 4:
                trueDamage = playerDamege * 0.5f;
                damage = trueDamage + playerDamege;
                if (trueDamage < 1)
                    trueDamage = 1;
                break;
            default:
                break;
        }
    }

    void Water_Synergy()
    {
        switch (water_num)  //물 시너지의 갯수에 따라 주문력 증가
        {
            case 0:
                break;
            case 1:
                ap += 20;
                break;
            case 2:
                ap += 50;
                break;
            case 3:
                ap += 100;
                break;
            case 4:
                ap += 200;
                break;
            default:
                break;
        }
    }

    void Fire_Synergy() //불 시너지의 갯수에 따라서 공격력 증가
    {
        switch (fire_num)
        {
            case 0:
                break;
            case 1:
                ad += 20;
                break;
            case 2:
                ad += 50;
                break;
            case 3:
                ad += 100;
                break;
            case 4:
                ad += 200;
                break;
            default:
                break;
        }
    }

    void Ground_Synergy() //근원 시너지의 갯수에 따라 방어력 감소,마법 저항력 감소 증가
    {
        switch (ground_num)
        {
            case 0:
                break;
            case 1:
                armor -= 3;
                ability_resist -= 3;
                break;
            case 2:
                armor -= 8;
                ability_resist -= 8;
                break;
            case 3:
                armor -= 16;
                ability_resist -= 16;
                break;
            case 4:
                armor -= 30;
                ability_resist -= 30;
                break;
            default:
                break;
        }
    }

    void Air_Synergy()
    {
        switch (air_num)
        {
            case 0:
                break;
            case 1:
                team_attack_spd=team_attack_spd * 0.3f;
                break;
            case 2:
                team_attack_spd = 1f;
                break;
            default:
                break;
        }
    }
}
