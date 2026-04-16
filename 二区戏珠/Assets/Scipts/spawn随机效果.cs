using UnityEngine;

public class spawn随机效果 : MonoBehaviour
{
    public Transform[] SpawnPoints1;
    public Transform[] SpawnPoints2;
    public float spawnTime = 3f;
    public GameObject objects;
    private float timer = 0f;
    void Start()
    {
        //InvokeRepeating("SpawnItem1", spawnTime, spawnTime);
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime && GameController.Instance.player1.HP > GameController.Instance.player2.HP)
        {
            SpawnItem2();
        }
        if (timer >= spawnTime && GameController.Instance.player1.HP < GameController.Instance.player2.HP)
        {
            SpawnItem1();
        }
    }
    void SpawnItem1()
    {
        int spawnIndex = Random.Range(0, SpawnPoints1.Length);
        //int objectIndex = Random.Range(0, objects.Length);
        Instantiate(objects, SpawnPoints1[spawnIndex].position, SpawnPoints1[spawnIndex].rotation);
        timer = 0f;

    }
    void SpawnItem2()
    {
        int spawnIndex = Random.Range(0, SpawnPoints2.Length);
        //int objectIndex = Random.Range(0, objects.Length);
        Instantiate(objects, SpawnPoints2[spawnIndex].position, SpawnPoints2[spawnIndex].rotation);
        timer = 0f;
    }
}
