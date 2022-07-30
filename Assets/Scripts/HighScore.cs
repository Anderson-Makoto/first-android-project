using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        this.highScoreText = GameObject.Find("Canvas/High Score").GetComponent<Text>();
        this.updateHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
        this.resetSpeed();
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    private void resetSpeed()
    {
        Enemy.speed = 3f; ;
        Collectable.speed = 3f;
        Player.speed = 2f;
        Spawner.minSpawnTime = 2f;
        Spawner.maxSpawnTime = 5f;
    }

    private void updateHighScoreText()
    {
        int highScore = PlayerPrefs.GetInt("highScore");

        this.highScoreText.text = "High Score: " + highScore.ToString();
    }
}
