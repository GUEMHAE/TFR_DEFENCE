using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectoSkill : MonoBehaviour
{
    public float damage;

    public void SetDamage(float damage) // ������ ����
    {
        this.damage = damage * 3f;
    }
}
