using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class waitZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Unit")
        {
            other.gameObject.GetComponent<Tonir>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Tonir>().enabled = true;
    }
}
