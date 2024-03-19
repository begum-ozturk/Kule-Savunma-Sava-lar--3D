using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    public Text overTimeText;
    public Text continueTimeText;
    private float elapsedTime = 0f;

    void Start()
    {
        GameIsOver = false;

        elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);
    }

    void FixedUpdate()
    {
        if (!GameIsOver)
        {
            elapsedTime += Time.deltaTime;
            elapsedTime = Mathf.Clamp(elapsedTime, 0f, Mathf.Infinity);
            overTimeText.text = string.Format("{0:00.00}", elapsedTime);
            continueTimeText.text = string.Format("{0:00.00}", elapsedTime);
        }

        if (GameIsOver)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }    

    void EndGame()
    {
        GameIsOver = true;

        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        PlayerPrefs.Save();

        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;

        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        PlayerPrefs.Save();

        completeLevelUI.SetActive(true);
    }
}
