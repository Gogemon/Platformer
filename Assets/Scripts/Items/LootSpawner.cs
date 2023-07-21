using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    public void Spawn(GameObject item)
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }
}
