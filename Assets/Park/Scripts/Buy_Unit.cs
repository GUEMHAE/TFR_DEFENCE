using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy_Unit : MonoBehaviour
{
    [SerializeField] private GameObject[] champion;
    [SerializeField] private List<Sprite> champimg = new List<Sprite>();
    public SpriteRenderer[] wait;
    public Sprite img;

    // è�Ǿ� ���� �� ȣ��Ǵ� �Լ�
    public void ClickChampion(int index)
    {
        Debug.Log(index + "����");
    }
}
