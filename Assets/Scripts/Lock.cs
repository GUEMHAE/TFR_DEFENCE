using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public Image lockimg; 
    public void OnLock()
    {
        if (Round.instance.isLock == true)
        {
            Round.instance.isLock = false;
            lockimg.color = Color.white;
        }

        else if (Round.instance.isLock == false)
        {
            Round.instance.isLock = true;
            lockimg.color = Color.gray;
        }
    }
}
