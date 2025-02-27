using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            //I hit the Player!
            SceneManager.LoadScene("Lose");

            //Unlocks cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
