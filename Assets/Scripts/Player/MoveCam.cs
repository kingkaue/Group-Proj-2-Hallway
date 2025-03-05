using UnityEngine;

public class MoveCam : MonoBehaviour
{
    private GameObject cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = GameObject.Find("CameraPos");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos.transform.position;
    }
}
