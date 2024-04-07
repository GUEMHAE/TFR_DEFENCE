using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveMent2D : MonoBehaviour
{
    //��ڻ��� ����Ƽ ����_TowerDefense#01 ������
    public float moveSpeed = 0.0f; //���� �̵��ӵ�
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero; //���� �̵� ����

    public float MoveSpeed => moveSpeed; //moveSpeed ������ ������Ƽ(Get ����)

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime; //���� �̵���Ű�� �ڵ�
    }

    public void MoveTo(Vector3 direction) //�ܺο��� �̵������� �����ϴ� MoveTo�Լ�
    {
        moveDirection = direction;
    }
}
