using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform obstaclePrefab;
    public GameObject ground;
    private float yRender;
    private float lastZ;
    private GameObject[] obstacles = new GameObject[8] { null, null, null, null, null, null, null, null};

    private float generateObstacleX() {
        Bounds groundBounds = ground.GetComponent<Collider>().bounds;
        return Random.Range(obstaclePrefab.GetComponent<Collider>().bounds.size.x / 2, groundBounds.size.x - (obstaclePrefab.GetComponent<Collider>().bounds.size.x/2));
    }

    private void storeObstacle(GameObject clone) {
        int storeCount = obstacles.Length;
        for (int i = 0; i < obstacles.Length; ++i) {
            if (obstacles[i] == null) storeCount--;
        }

        if (storeCount < obstacles.Length)
        {
            obstacles[storeCount] = clone;
        }
        else {
            Destroy(obstacles[0]);
            for (int k = 0; k < obstacles.Length; ++k) {
                if (k != obstacles.Length - 1)
                {
                    obstacles[k] = obstacles[k + 1];
                }
                else {
                    obstacles[k] = clone;
                }
            }
        }
    }

    void Start()
    {
        this.yRender = transform.position.y;
        float xRender = ground.GetComponent<Collider>().bounds.min.x + generateObstacleX();
        this.lastZ = transform.position.z + 20;
        GameObject renderedObstacle = Instantiate(
            obstaclePrefab, 
            new Vector3(xRender, yRender, lastZ), 
            Quaternion.identity
        ).gameObject;
        storeObstacle(renderedObstacle);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z + 100 >= lastZ) {
            this.lastZ += 20;
            float xRender = ground.GetComponent<Collider>().bounds.min.x + generateObstacleX();
            GameObject renderedObstacle = Instantiate(
                obstaclePrefab,
                new Vector3(xRender, yRender, lastZ),
                Quaternion.identity
            ).gameObject;
            storeObstacle(renderedObstacle);
        }
    }
}
