using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            //Player found gem
            GameObject.FindGameObjectWithTag("GameController").GetComponent<WinScreen>().Win();
            Destroy(this.gameObject);
        }
    }
}
