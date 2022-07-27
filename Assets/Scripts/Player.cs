using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int direction = 1;
    public static float speed = 2f;
    private float lastPoints = 0;
    [SerializeField]
    private GameObject slider;
    private Text pointText;
    private readonly string ENEMY_TAG = "Enemy";
    private readonly string COLLECTABLE_TAG = "Collectable";
    void Start()
    {
        this.pointText = GameObject.Find("Canvas/Point Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        this.movePlayer();
        this.detectWall();
        this.changeDirection();
    }

    void movePlayer()
    {
        Vector3 translate = new Vector3(
            speed * Time.deltaTime * this.direction, 
            this.transform.position.y, 
            this.transform.position.z
        );

        this.transform.Translate(translate);
    }

    void detectWall()
    {
        float xScale = this.slider.transform.localScale.x;
        float currentPosition = this.transform.position.x;

        if (currentPosition >= (xScale / 2))
        {
            this.direction = -1;
        } else if (this.transform.position.x <= -(xScale / 2))
        {
            this.direction = 1;
        }
    }

    void changeDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.direction *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(this.ENEMY_TAG))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }

        if (collision.gameObject.CompareTag(this.COLLECTABLE_TAG))
        {
            Destroy(collision.gameObject);
            this.pointText.text = (int.Parse(this.pointText.text) + 1).ToString();
            this.increaseSpeed();
        }
    }

    private void increaseSpeed()
    {
        if (((int.Parse(this.pointText.text) - this.lastPoints) == 5) && this.lastPoints <= 75)
        {
            this.lastPoints = int.Parse(this.pointText.text);
            Enemy.speed *= 1.1f;
            Collectable.speed *= 1.1f;
            speed *= 1.1f;
            Spawner.minSpawnTime *= 0.9f;
            Spawner.maxSpawnTime *= 0.9f;
        }
    }
}
