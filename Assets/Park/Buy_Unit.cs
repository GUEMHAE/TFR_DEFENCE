using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy_Unit : MonoBehaviour
{
    [SerializeField] private GameObject[] champion;
    [SerializeField] private List<Sprite> champimg = new List<Sprite>();
    public SpriteRenderer[] wait;
    public Sprite img;

    // Start is called before the first frame update
    void Start()
    {
        // Start �Լ��� ���� �������
    }

    // Update is called once per frame
    void Update()
    {
        // Update �Լ��� ���� �������
    }

    // è�Ǿ� ���� �� ȣ��Ǵ� �Լ�
    public void ClickChampion(int index)
    {
        Debug.Log(index + "����");

        // champimg ����Ʈ�� img �߰�
        if (champimg.Count < wait.Length)
        {
            champimg.Insert(champimg.Count, img);
            wait[champimg.Count - 1].sprite = champimg[champimg.Count - 1];
        }
        else
        {
            Debug.LogWarning("è�Ǿ� ����â�� ���� á���ϴ�.");
        }
    }
}
