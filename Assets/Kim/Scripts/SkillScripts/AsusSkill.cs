using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsusSkill : MonoBehaviour
{
    public float damage = 220f;

    private void Update()
    {
        Destroy(this.gameObject, 8f);
    }
}
