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
