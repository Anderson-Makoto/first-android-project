using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int direction = 1;
    private float speed = 2f;
    [SerializeField]
    private GameObject slider; 
    void Start()
    {
        
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
            this.speed * Time.deltaTime * this.direction, 
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
}
