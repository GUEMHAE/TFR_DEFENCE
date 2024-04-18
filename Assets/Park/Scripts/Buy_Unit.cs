using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy_Unit : MonoBehaviour
{
    [SerializeField] private GameObject[] champion;
    [SerializeField] private List<Sprite> champimg = new List<Sprite>();
    public SpriteRenderer[] wait;
    public Sprite img;

    // 챔피언 선택 시 호출되는 함수
    public void ClickChampion(int index)
    {
        Debug.Log(index + "눌림");
    }
}
