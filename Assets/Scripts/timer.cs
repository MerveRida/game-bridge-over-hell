using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float timePassed = Time.time - startTime;
        float timeLeft = 30 - ((int)(timePassed % 60));
        timerText.text = "Kalan Zaman: "+timeLeft;
        if (timeLeft <= 0.0f)
        {
            SceneManager.LoadScene("DunyaGecis");
        }
    }
}
