using UnityEngine;

public class DragonVisibility : MonoBehaviour
{
    private Transform playerPosition;
    public float visibilityRange;
    private SpriteRenderer dragonRenderer;

    // Start is called before the first frame update
    void Start()
    {
        dragonRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        
        float distanceToPlayer = Vector2.Distance(transform.position, playerPosition.position);

        if (distanceToPlayer <= visibilityRange)
        {
            dragonRenderer.enabled = true;
        }
        else
        {
            dragonRenderer.enabled = false;
        }
    }
}
