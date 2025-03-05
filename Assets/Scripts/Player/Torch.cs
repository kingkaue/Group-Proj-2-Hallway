using UnityEngine;

public class Torch : MonoBehaviour
{
    private Light lightToFlicker;
    [SerializeField, Range(0f, 5f)] private float minIntensity = 0.5f;
    [SerializeField, Range(0f, 5f)] private float maxIntensity = 1.2f;
    [SerializeField, Min(0f)] private float timeBetweenIntensity = 0.1f;
    private float currentTimer;

    private void Awake()
    {
        if (lightToFlicker == null)
        {
            lightToFlicker = GetComponent<Light>();
        }

        ValidateIntensityBounds();
    }

    private void Update()
    {
        currentTimer += Time.deltaTime;
        if (!(currentTimer >= timeBetweenIntensity))
        {
            return;
        }   
        lightToFlicker.intensity = Random.Range(minIntensity, maxIntensity);
        currentTimer = 0;
    }

    private void ValidateIntensityBounds()
    {
        if (!(minIntensity > maxIntensity))
        {
            return;
        }

        (minIntensity, maxIntensity) = (maxIntensity, minIntensity);
    }
}
