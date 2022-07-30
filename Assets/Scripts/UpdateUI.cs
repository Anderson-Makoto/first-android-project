using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    private Text versionText;
    private Text highScoreText;

    void Start()
    {
        this.versionText = GameObject.Find("Canvas/Version Text").GetComponent<Text>();
        this.highScoreText = GameObject.Find("Canvas/High Score").GetComponent<Text>();
        this.versionText.text = "version: " + Application.version;
        Enemy.speed = 3f;
        Collectable.speed = 3f;
        Player.speed = 2f;
        Spawner.minSpawnTime = 2f;
        Spawner.maxSpawnTime = 5f;
        this.getHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void getHighScore()
    {
        int highScore;
        if (!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", 0);
            highScore = 0;
        }
        else
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }

        this.highScoreText.text = "High Score: " + highScore.ToString();
    }
}
