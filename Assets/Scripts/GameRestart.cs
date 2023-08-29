using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    public static GameRestart Instance;

    public GameObject restartbtn;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void ShowRestartbutton(bool show)
    {
        restartbtn.gameObject.SetActive(show);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Battle");
    }
}
