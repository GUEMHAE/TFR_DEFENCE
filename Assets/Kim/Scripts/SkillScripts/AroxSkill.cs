using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroxSkill : MonoBehaviour
{
    [SerializeField]
    public float damage =40f;

    public void SetDamage(float damage) // ������ ����
    {
        this.damage = damage * 1.3f;
    }

    private void Update()
    {
        Destroy(gameObject, 3f);
    }
}
