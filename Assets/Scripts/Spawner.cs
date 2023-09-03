using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float cooldown;

    [SerializeField] private float spawnTime;

    private bool ReadyToSpawn;

    [SerializeField] private Transform spawnPos;

    [SerializeField] private GameObject enemy;

    Quaternion angle;

    private void Start()
    {
        angle = Quaternion.Euler(0, 0, -180);
    }

    private void Update()
    {
        Spawn();
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

    void Spawn()
    {
        if (ReadyToSpawn == true)
        {
            spawnPos = randomSpawnPos();
            Instantiate(enemy, spawnPos.position, angle);
        }
    }

    Transform randomSpawnPos()
    {
        float randomX = Random.Range(-2.5f, 2.5f);
        spawnPos.position = new Vector2(randomX, spawnPos.transform.position.y);
        return spawnPos;
    }
}
