using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cysharp.Threading.Tasks;
using System;

public class TutorialScripts : MonoBehaviour, IEndDragHandler
{
    public GameObject goGrid; // ��⼮���� ��ġ������
    public GameObject enemy_0; // ���� ������
    //   public GameObject ep_IMG; // ���� �̹���
    //   public GameObject ep_IMGGrid; // ���� �̹���
    //   public GameObject IMG2; // ���� �̹���
    //   public GameObject IMG2_1; // ���� �̹���
    //   public GameObject IMG2_2; // ���� �̹���
    //// ���� �̹���

    public float enemy;
    private T_IMG waitsAnimation; // T_IMG ��ũ��Ʈ ����

    public string GridName; //��ġ�� �̸�
    public GameObject IMG_Grid; // �̹���
    private bool isGrid = false; // ��ġ���� ���� �Ǿ����� Ȯ��

    public string waitsName; // ��⼮ �̸�
    public GameObject IMG_waits; //���� �̹���
    private bool iswaits = false; // ��⼮�� ���� �Ǿ����� Ȯ��

    void Start()
    {
        Step2();
        IMG_waits.SetActive(false);
        waitsAnimation = IMG_waits.GetComponent<T_IMG>(); // T_IMG ��ũ��Ʈ ���� ��������
    }


    async UniTaskVoid Step2()
    {
        while(true)
        {
            await UniTask.WaitUntil(() => GameObject.FindWithTag("Enemy"));
            enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>().hp;
            if(enemy<=0)
            {
                goGrid.SetActive(false);
                IMG_Grid.SetActive(false);
                enemy_0.SetActive(true);
                Debug.Log("2");
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isGrid && !IMG_Grid.activeSelf) // ���� �����̰� �̹����� ��Ȱ��ȭ�� ���
        {
            IMG_Grid.SetActive(true); // �̹����� Ȱ��ȭ
        }
        else
        {
            Debug.Log("1");
            IMG_Grid.SetActive(false); // ��ġ�� �̹����� ��Ȱ��ȭ�մϴ�.
            goGrid.SetActive(false); // ��ġ�� �̹����� ��Ȱ��ȭ�մϴ�.
        }

        if(isGrid==true)
        {
            IMG_waits.SetActive(true);

            // IMG_waits �̹����� �ִϸ��̼� ����
            if (waitsAnimation != null)
            {
                waitsAnimation.StartAnimation();
            }
        }
        else
        {
            IMG_waits.SetActive(false);
        }

        //if (enemy <= 0)
        //{
        //    enemy_0.SetActive(true);
        //    Debug.Log("2");
        //}



        //// IMG_Grid�� ��Ȱ��ȭ�� ��� ��⼮ �̹����� Ȱ��ȭ�մϴ�.
        //if (!IMG_Grid.activeSelf)
        //{
        //    IMG_waits.SetActive(true); // ��⼮ �̹����� Ȱ��ȭ�մϴ�.
        //    Debug.Log("ddd"); // ����� �α� ���
        //}


        //if (iswaits && !IMG_waits.activeSelf) // ���� �����̰� �̹����� ��Ȱ��ȭ�� ���
        //{
        //    IMG_waits.SetActive(true); // �̹����� Ȱ��ȭ
        //    //ep_IMGGrid.SetActive(false);
        //    //IMG2.SetActive(false);
        //    //IMG2_1.SetActive(false);
        //    //IMG2_2.SetActive(false);
        //    //IMG.SetActive(true);

        //}
        //else
        //{
        //    IMG_waits.SetActive(false);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == GridName) // �浹�� ���� ������Ʈ�� �̸��� ��ġ�� �̸��� ���� ���
        {
            isGrid = true; // ���� ���¸� true�� ����
        }

        if (collision.gameObject.name == waitsName) // �浹�� ���� ������Ʈ�� �̸��� ��⼮ �̸��� ���� ���
        {
            iswaits = true; // ���� ���¸� true�� ����
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == GridName) // ��ġ���� �浹�� ���� ���
        {
            isGrid = false; // ���� ���¸� false�� ����
        }

        if (collision.gameObject.name == waitsName) // ��⼮�� �浹�� ���� ���
        {
            iswaits = false; // ���� ���¸� false�� ����
        }
    }
}
