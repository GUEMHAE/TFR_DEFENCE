using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialScripts : MonoBehaviour, IEndDragHandler
{
    public GameObject IMG; // ���� �̹���
    public GameObject IMG1; // ���� �̹���
    public GameObject ep_IMG; // ���� �̹���
    public GameObject ep_IMGGrid; // ���� �̹���
    public GameObject IMG2; // ���� �̹���
    public GameObject IMG2_1; // ���� �̹���
    public GameObject IMG2_2; // ���� �̹���
 // ���� �̹���

    public string GridName; //��ġ�� �̸�
    public GameObject IMG_Grid; // �̹���
    private bool isGrid = false; // ��ġ���� ���� �Ǿ����� Ȯ��

    public string waitsName; // ��⼮ �̸�
    public GameObject IMG_waits; //���� �̹���
    private bool iswaits = false; // ��⼮�� ���� �Ǿ����� Ȯ��

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isGrid && !IMG_Grid.activeSelf) // ���� �����̰� �̹����� ��Ȱ��ȭ�� ���
        {
            IMG_Grid.SetActive(true); // �̹����� Ȱ��ȭ
            IMG_waits.SetActive(false);
            IMG1.SetActive(false);
            ep_IMG.SetActive(false);
            ep_IMGGrid.SetActive(true);
        }
        else
        {
            IMG_Grid.SetActive(false);
        }


        if (iswaits && !IMG_waits.activeSelf) // ���� �����̰� �̹����� ��Ȱ��ȭ�� ���
        {
            IMG_waits.SetActive(true); // �̹����� Ȱ��ȭ
            ep_IMGGrid.SetActive(false);
            IMG2.SetActive(false);
            IMG2_1.SetActive(false);
            IMG2_2.SetActive(false);
            IMG.SetActive(true);

        }
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
