using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChampionShop : MonoBehaviour
{
    [SerializeField]
    private GameObject[] champion;
    [SerializeField]
    private List<Sprite> champimg = new List<Sprite>();
    public SpriteRenderer[] wait;
    public Sprite img;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ClickChampion(int index)
    {
        Debug.Log(index + "´­¸²");

        if (champimg.Count == 0)
        {
            champimg.Insert(0, img);
            wait[0].sprite = champimg[0];
        }

        else if (champimg.Count == 1)
        {
            champimg.Insert(1, img);
            wait[1].sprite = champimg[1];
        }

        else if(champimg.Count == 2)
        {
            champimg.Insert(2, img);
            wait[2].sprite = champimg[2];
        }

        else if(champimg.Count == 3)
        {
            champimg.Insert(3, img);
            wait[3].sprite = champimg[3];
        }

        else if(champimg.Count == 4)
        {
            champimg.Insert(4, img);
            wait[4].sprite = champimg[4];
        }
    }
}
