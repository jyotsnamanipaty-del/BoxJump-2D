using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Trap : MonoBehaviour
{
    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Player"))
        {
            isDead = true;

            Debug.Log("Player hit trap!");

            Animator anim = other.GetComponent<Animator>();

            if (anim != null)
            {
                Debug.Log("Animator found");
                anim.SetTrigger("death");
            }
            else
            {
                Debug.Log("Animator not found");
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