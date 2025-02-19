using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Unlocks cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
            SceneManager.LoadScene("Win");
        }
    }
}
