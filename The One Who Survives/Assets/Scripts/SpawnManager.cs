using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public Transform enemyParent;
    public Transform player;

    void Start()
    {
        SpawnAllZombies();
    }

    void SpawnAllZombies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject zombie = Instantiate(
                zombiePrefab,
                spawnPoint.position,
                spawnPoint.rotation,
                enemyParent
            );

            EnemyAI enemyAI = zombie.GetComponent<EnemyAI>();
            if (enemyAI != null && player != null)
            {
                enemyAI.target = player;
            }
        }
    }
}
