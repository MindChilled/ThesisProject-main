using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameTimerScript : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public bool isPaused = false;
    [Header("Panel UI")]
    public GameObject pausePanel;
    [Header ("Time")]
    public int inGameTime = 0;
    public int inGameDate = 0;
    public int inGameMonth = 0;
    public int inGameYear = 0;
    [Header("Timer UI")]
    public TMP_Text gameHours;
    public TMP_Text gameMinutes;
    public TMP_Text gameDays;
    public TMP_Text gameMonths;
    public TMP_Text gameYears;





    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        UpdateMonth();
        pausePanel.gameObject.SetActive(false);

    }
    void Update()
    {
        if (timerIsRunning && isPaused == false)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                //Debug.Log("Time has run out!");
                inGameTime = inGameTime + 10;
                UpdateInGameClock();
                timeRemaining = 1;
                timerIsRunning = true;
            }
        }
    }

    private void UpdateInGameClock()
    {
        int InGameMinute = Mathf.FloorToInt(inGameTime % 60);
        int inGameHours = Mathf.FloorToInt(inGameTime / 60);
        //Debug.Log("In game time : " + inGameHours + " : " + InGameMinute);
        gameMinutes.text = InGameMinute.ToString();
        gameHours.text = inGameHours.ToString();
        if(inGameTime >= 1440)
        {
            inGameDate++;
            UpdateDate();
            inGameTime = 0;
        }

    }

    private void UpdateDate()
    {
        gameDays.text = inGameDate.ToString();
        //Debug.Log("This is inGameDate : " + inGameDate);
        if(inGameDate > 30)
        {
            inGameMonth++;
            UpdateMonth();
            inGameDate = 0;
        }
    }

    private void UpdateMonth()
    {
        gameMonths.text = inGameMonth.ToString();
        //Debug.Log("This is inGameMonth : " + inGameMonth);
        switch (inGameMonth)
        {
            case 1:
                gameMonths.text = "JAN";
                Debug.Log("Shud be Jan");
                break;
            case 2:
                gameMonths.text = "FEB";
                break;
            case 3:
                gameMonths.text = "MAR";
                break;
            case 4:
                gameMonths.text = "APR";
                break;
            case 5:
                gameMonths.text = "MAY";
                break;
            case 6:
                gameMonths.text = "JUN";
                break;
            case 7:
                gameMonths.text = "JUL";
                break;
            case 8:
                gameMonths.text = "AUG";
                break;
            case 9:
                gameMonths.text = "SEP";
                break;
            case 10:
                gameMonths.text = "OCT";
                break;
            case 11:
                gameMonths.text = "NOV";
                break;
            case 12:
                gameMonths.text = "DEC";
                break;
            default:
                gameMonths.text = "DEF";
                break;


        }
        if (inGameMonth > 12)
        {
            inGameYear++;
            UpdateYear();
            inGameMonth = 0;
        }
    }

    private void UpdateYear()
    {
        Debug.Log("This is inGameYear : " + inGameYear);
    }

    public void ChangeDay()
    {
        inGameDate = inGameDate + 1;
        inGameTime = 350;
        UpdateDate();
    }

    public void PauseTimer()
    {
        pausePanel.gameObject.SetActive(true);
        isPaused = true;
    }

    public void ResumeTimer()
    {
        pausePanel.gameObject.SetActive(false);
        isPaused = false;
    }
}
