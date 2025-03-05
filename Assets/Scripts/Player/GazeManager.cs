using UnityEngine;

public class GazeManager : MonoBehaviour
{
    public Camera viewCamera;
    private GameObject lastGazedUpon;

    // Update is called once per frame
    void Update()
    {
        CheckGaze();
    }
    public void CheckGaze()
    {
        if (lastGazedUpon)
        {
            lastGazedUpon.SendMessage("NotGazingUpon", SendMessageOptions.DontRequireReceiver);
        }

        Ray gazeRay = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;
        float sphereCastRadius = 1.8f;
        if (Physics.SphereCast(gazeRay, sphereCastRadius, out hit))
        {
            hit.transform.SendMessage("GazingUpon", SendMessageOptions.DontRequireReceiver);
            lastGazedUpon = hit.transform.gameObject;
        }
    }

}
