using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemVisibility : MonoBehaviour
{
    void OnTriggerEnter(Collider whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            GetComponentInParent<SpriteRenderer>().enabled = true;
        }
    }

    void OnTriggerExit(Collider whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            GetComponentInParent<SpriteRenderer>().enabled = false;
        }
    }
}
