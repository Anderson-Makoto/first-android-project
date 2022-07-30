using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed = 3f;
    [SerializeField]
    private GameObject spawner;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.moveEnemy();
        this.die();
    }

    void die()
    {
        float yPos = -this.spawner.transform.position.y;

        if (this.transform.position.y <= yPos)
        {
            Destroy(this.gameObject);
        }
    }


    void moveEnemy()
    {
        Vector3 position = this.transform.position;
        position.y -= speed * Time.deltaTime;
        transform.position = position;
    }
}
