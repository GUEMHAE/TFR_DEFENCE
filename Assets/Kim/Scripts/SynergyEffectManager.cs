using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergyEffectManager : MonoBehaviour
{
    public int light_num;            //�ż�(���� ȸ��) �ó����� ����
    public int dark_num;            //�Ͽ�(�߰� ���� ����) �ó����� ����
    public int water_num;          //���(�ֹ��� ����) �ó����� ����
    public int fire_num;             //Ȳȥ(���ݷ� ����)�ó����� ����
    public int ground_num;       //�ٿ�(���� �� ����,�������׷� ����)�ó����� ����
    public int air_num;             //õ��(���Ϸ� ���� �� �� ��ü ���� �ӵ� ����)�ó����� ����

    public float mana_regen = 2;  //�÷��̾� ������ �ʱ� ���� ȸ����
    public float playerDamege;  //�÷��̾� ������ �߰��������� ����� ���� �÷��̾��� �������� �޾ƿ��� ����
    public float trueDamage;    //�÷��̾� ������ �߰� ��������
    public float damage;         //�÷��̾� ������ �ִ� ����+��������
    public float ap;                //�÷��̾� ������ �ֹ���
    public float ad;                //�÷��̾� ������ ���ݷ�
    public float armor;           //���� ����
    public float ability_resist;   //���� �������׷�
    public float team_attack_spd; //�÷��̾� ������ �߰� ���ݼӵ�

    void Start()
    {
        trueDamage = 0; //�ʱ� �߰� �������� 0���� �ʱ�ȭ
        team_attack_spd = 1f; //�ʱ� �߰� ���ݼӵ� 1�� �ʱ�ȭ
    }

    void Update()
    {

    }

    void Light_Synergy()
    {
        switch (light_num)        //�� �ó����� ������ ���� ���� ȸ���� ����
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
        switch (dark_num)  //��� �ó����� ������ ���� �߰� ��������,�������� ����� ������ ���� ������*�������� ���
        {
            case 0:
                break;
            case 1:
                trueDamage = playerDamege * 0.05f;
                damage = trueDamage + playerDamege;
                if (trueDamage < 1) //���� ���ذ� 1���� ������ �ּ� �������� 1�� ����
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
        switch (water_num)  //�� �ó����� ������ ���� �ֹ��� ����
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

    void Fire_Synergy() //�� �ó����� ������ ���� ���ݷ� ����
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

    void Ground_Synergy() //�ٿ� �ó����� ������ ���� ���� ����,���� ���׷� ���� ����
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
