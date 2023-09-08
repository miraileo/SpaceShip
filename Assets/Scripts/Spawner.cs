using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float cooldown;

    [SerializeField] private float spawnTime;

    private bool ReadyToSpawn;

    [SerializeField] private Transform spawnPos;

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject rock;

    Quaternion angle;

    private void Start()
    {
        angle = Quaternion.Euler(0, 0, -180);
    }

    private void Update()
    {
        SpawnEnemies();
        coolDown();
    }

    void coolDown()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            ReadyToSpawn= false;
        }
        else 
        {
            ReadyToSpawn= true;
            cooldown = spawnTime;
        }
    }

    void SpawnEnemies()
    {
        if (ReadyToSpawn == true)
        {
            spawnPos = randomSpawnPos();
            Instantiate(enemy, spawnPos.position, angle);
            if (RandomSpawnVarity() == 1)
            {
                SpawnRocks();
            }
        }
    }

    void SpawnRocks()
    {
        spawnPos = randomSpawnPos();
        Instantiate(rock, spawnPos.position, Quaternion.identity);
    }

    private int RandomSpawnVarity()
    {
        int random = Random.Range(0, 3);
        return random;
    }

    Transform randomSpawnPos()
    {
        float randomX = Random.Range(-2.5f, 2.5f);
        spawnPos.position = new Vector2(randomX, spawnPos.transform.position.y);
        return spawnPos;
    }
}
