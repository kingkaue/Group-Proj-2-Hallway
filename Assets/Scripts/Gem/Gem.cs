using UnityEngine;
using UnityEngine.SceneManagement;

public class Gem : MonoBehaviour
{
    public SpriteRenderer gemRenderer;

    void Start()
    {
        gemRenderer.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 50 * Time.deltaTime, 0f, Space.Self);

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
