using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBt : MonoBehaviour
{
    public GameObject Shop;

    public void Shopbutton()
    {
        if (Shop.activeSelf)
        {
            Shop.SetActive(false);
        }
        else
        {
            Shop.SetActive(true);
        }
    }
}
