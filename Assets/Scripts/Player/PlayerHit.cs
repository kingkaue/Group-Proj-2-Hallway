using UnityEngine;

public class PlayerHit : MonoBehaviour
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
        if (whatIHit.tag == "Dragon")
        {
            //I hit the Dragon!
            Destroy(this.gameObject);
        }
    }
}
