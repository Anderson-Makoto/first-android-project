using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static float speed = 3f;
    private readonly string PLAYER_TAG = "Player";
    [SerializeField]
    private GameObject spawner;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.moveCollectable();
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

    void moveCollectable()
    {
        Vector3 position = this.transform.position;
        position.y -= speed * Time.deltaTime;
        transform.position = position;
    }
}
