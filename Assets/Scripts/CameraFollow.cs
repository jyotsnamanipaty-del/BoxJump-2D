using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;
    public float yOffset = 2f;

    public float minX;
    public float maxX;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        float halfWidth = cam.orthographicSize * cam.aspect;

        float x = Mathf.Clamp(
            player.position.x,
            minX + halfWidth,
            maxX - halfWidth
        );

        Vector3 targetPosition = new Vector3(
            x,
            player.position.y + yOffset,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}