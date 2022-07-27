using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    private Text versionText;

    void Start()
    {
        this.versionText = GameObject.Find("Canvas/Version Text").GetComponent<Text>();
        this.versionText.text = "version: " + Application.version;
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
}
