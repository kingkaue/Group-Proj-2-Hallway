using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    private bool isGazingUpon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGazingUpon)
        {
            transform.Rotate(0, 3, 0);
        }
    }

    public void GazingUpon()
    {
        isGazingUpon = true;
    }

    public void NotGazingUpon()
    {
        isGazingUpon = false;
    }
}
