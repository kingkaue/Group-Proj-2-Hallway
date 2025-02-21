using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField] GameObject Flashlight;
    private bool FlashlightActive;

    // Start is called before the first frame update
    void Start()
    {
        Flashlight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!FlashlightActive == false)
            {
                Flashlight.gameObject.SetActive(true);
                FlashlightActive = true;
            }
            else 
            {
                Flashlight.gameObject.SetActive(false);
                FlashlightActive = false;
            }
        }
    }
}
