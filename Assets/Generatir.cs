using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Generatir : MonoBehaviour
{
    [SerializeField] GameObject obstacjeObj;
    UnityEngine.Vector3 startPosition = new UnityEngine.Vector3(0, 0, 10);
    float generateStep = 10;
    float xDistance = 3;
    List<GameObject> obstaclesonMap = new List<GameObject>();
    private IEnumerator courtine;

    void SpawnObstacle(UnityEngine.Vector3 lastPosition)
    {
        UnityEngine.Vector3 positionToSpawn = new UnityEngine.Vector3((int) Random.Range(-1.9f, 1.9f) * xDistance, lastPosition.y, lastPosition.z + generateStep);
        obstaclesonMap.Add(Instantiate(obstacjeObj, positionToSpawn, transform.rotation));
    }

    IEnumerator WaitToSpawn(float timeToWait)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToWait);
            SpawnObstacle(obstaclesonMap[obstaclesonMap.Count - 1].transform.position);
            if (obstaclesonMap.Count > 45)
            {
                Destroy(obstaclesonMap[0]);
                obstaclesonMap.Remove(obstaclesonMap[0]);
            }
        }
    }

    void Start()
    {
        SpawnObstacle(startPosition);
        for (int i = 0; i < 20; i++)
        {
            SpawnObstacle(obstaclesonMap[obstaclesonMap.Count - 1].transform.position);
        }

        courtine = WaitToSpawn(0.8f);
        StartCoroutine(courtine);
    }

    void Update()
    {
        
    }
}
