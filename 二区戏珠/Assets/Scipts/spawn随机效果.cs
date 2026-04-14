using UnityEngine;

public class spawn随机效果 : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public float spawnTime = 3f;
    public GameObject objects;
    void Start()
    {
        InvokeRepeating("SpawnItem", spawnTime, spawnTime);
    }

    void Update()
    {
        
    }
    void SpawnItem()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        //int objectIndex = Random.Range(0, objects.Length);
        Instantiate(objects, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);


    }
}
