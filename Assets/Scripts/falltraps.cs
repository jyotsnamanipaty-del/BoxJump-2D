using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FallingTrap : MonoBehaviour
{
    private bool isDead = false;
    private bool triggered = false;

    private Rigidbody2D rb;
    private Vector3 originalPos;

    [Header("Shake Settings")]
    public float shakeDuration = 0.4f;
    public float shakeAmount = 0.05f;
    public float shakeSpeed = 25f;

    [Header("Trap Settings")]
    public float destroyDelay = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = transform.position;

        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // 👇 UnderTrigger (player below platform)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(ShakeThenFall());
        }
    }

    IEnumerator ShakeThenFall()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float offsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;

            transform.position = new Vector3(
                originalPos.x + offsetX,
                originalPos.y,
                originalPos.z
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPos;

        rb.bodyType = RigidbodyType2D.Dynamic;

        yield return new WaitForSeconds(destroyDelay);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isDead) return;

        if (other.gameObject.CompareTag("Player"))
        {
            isDead = true;

            Debug.Log("Player crushed!");

            Animator anim = other.gameObject.GetComponent<Animator>();

            if (anim != null)
            {
                anim.SetTrigger("death");
            }

            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                playerRb.linearVelocity = Vector2.zero;
                playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        Debug.Log("Restart started");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}