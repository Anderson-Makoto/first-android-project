using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject slider;
    [SerializeField]
    private GameObject collectable;
    public static float minSpawnTime = 2f;
    public static float maxSpawnTime = 5f;

    void Start()
    {
        StartCoroutine(this.spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            float xScale = this.slider.transform.localScale.x;
            int spawnLocation = Random.Range(0, 3);
            int whichObject = Random.Range(0, 2);
            float yLocation = this.transform.position.y;

            GameObject obj = whichObject == 0 ? Instantiate(this.enemy) : Instantiate(this.collectable);
            float zLocation = obj.transform.position.z;
            

            if (spawnLocation == 0)
            {
                obj.transform.position = new Vector3(-(xScale / 2), yLocation, zLocation);
            }
            else if (spawnLocation == 1)
            {
                obj.transform.position = new Vector3(0, yLocation, zLocation);
            }
            else
            {
                obj.transform.position = new Vector3((xScale / 2), yLocation, zLocation);
            }
        }
    }
}
