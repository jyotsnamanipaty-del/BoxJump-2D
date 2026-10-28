using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour
{
    public GameObject warningPanel;
    public GameObject winPanel;

    private bool finished = false;

    private void Start()
    {
        if (warningPanel != null)
            warningPanel.SetActive(false);

        if (winPanel != null)
            winPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (finished) return;

        if (!other.CompareTag("Player"))
            return;

        if (CoinManager.instance.AllCoinsCollected())
        {
            finished = true;

            if (winPanel != null)
                winPanel.SetActive(true);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }
    }

    IEnumerator ShowWarning()
    {
        if (warningPanel != null)
        {
            warningPanel.SetActive(true);

            yield return new WaitForSeconds(2f);

            warningPanel.SetActive(false);
        }
    }
}