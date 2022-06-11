using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    // Start is called before the first frame update
    public void Pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int SceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneID);
    }

}

