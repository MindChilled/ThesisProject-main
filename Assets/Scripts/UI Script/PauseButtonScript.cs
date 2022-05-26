using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseButtonScript : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        pausePanel.gameObject.SetActive(true);
        GamemanagerScript.instance.PauseTimer();
    }

    public void ResumeTimer()
    {
        pausePanel.gameObject.SetActive(false);
        GamemanagerScript.instance.ResumeTimer();
    }
}
