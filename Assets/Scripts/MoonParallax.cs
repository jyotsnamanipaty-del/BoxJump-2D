using UnityEngine;

public class MoonParallax : MonoBehaviour
{
    public Transform player;

    private float startMoonY;
    private float startPlayerY;

    public float parallaxAmount = 0.1f;

    void Start()
    {
        startMoonY = transform.position.y;
        startPlayerY = player.position.y;
    }

    void Update()
    {
        float playerHeight = player.position.y - startPlayerY;

        transform.position = new Vector3(
            transform.position.x,
            startMoonY + playerHeight * parallaxAmount,
            transform.position.z
        );
    }
}