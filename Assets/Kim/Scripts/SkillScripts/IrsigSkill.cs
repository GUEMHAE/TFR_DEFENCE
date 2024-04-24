using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrsigSkill : MonoBehaviour
{
    public float damage=200f;

    private void Update()
    {
        Destroy(this.gameObject, 4f);
    }
}
