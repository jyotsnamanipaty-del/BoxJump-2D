using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public Light2D lightSource;
    public float speed = 3f;
    public float amount = 0.2f;

    private float baseIntensity;

    void Start()
    {
        baseIntensity = lightSource.intensity;
    }

    void Update()
    {
        lightSource.intensity =
            baseIntensity + Mathf.Sin(Time.time * speed) * amount;
    }
}