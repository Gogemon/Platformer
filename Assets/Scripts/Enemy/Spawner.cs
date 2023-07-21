using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void SpawnEnemy(Enemy enemy)
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
