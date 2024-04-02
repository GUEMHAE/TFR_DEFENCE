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
        // Start 함수는 현재 비어있음
    }

    // Update is called once per frame
    void Update()
    {
        // Update 함수는 현재 비어있음
    }

    // 챔피언 선택 시 호출되는 함수
    public void ClickChampion(int index)
    {
        Debug.Log(index + "눌림");

        // champimg 리스트에 img 추가
        if (champimg.Count < wait.Length)
        {
            champimg.Insert(champimg.Count, img);
            wait[champimg.Count - 1].sprite = champimg[champimg.Count - 1];
        }
        else
        {
            Debug.LogWarning("챔피언 선택창이 가득 찼습니다.");
        }
    }
}
