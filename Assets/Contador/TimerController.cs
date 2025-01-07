using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TimerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; 
    [SerializeField] private float remainingTime; 
    [SerializeField] private TextMeshProUGUI gameOverText;

    private bool isTimerActive = false; 

    void Start()
    {
 
        timerText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false); 
    }

    void Update()
    {
        if (isTimerActive)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;

                
                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);

              
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
              
                remainingTime = 0;
                isTimerActive = false;
                TimerEnded();
            }
        }
    }

    
    public void StartTimer()
    {
        isTimerActive = true;
        timerText.gameObject.SetActive(true); 
    }


    private void TimerEnded()
    {
        timerText.gameObject.SetActive(false); 
        gameOverText.gameObject.SetActive(true); 
        gameOverText.text = "¡Tu hija ha muerto! Se acabó el tiempo.";
    }
}
