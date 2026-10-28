using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;

    private float time = 0f;
    private bool running = true;

    void Update()
    {
        if (!running) return;

        time += Time.deltaTime;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void StopTimer()
    {
        running = false;
    }
}