using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingParticle : MonoBehaviour //Particle�� SortingOrder�� ���ϱ� ���� ��ũ��Ʈ
{
    [SerializeField]
    public int sortingOrder;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().sortingOrder= sortingOrder;
    }
}
