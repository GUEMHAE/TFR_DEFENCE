using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    public GameObject info;

    public void UIActive()
    {
        info.SetActive(!info.activeSelf);
    }
}
