using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] WayPoints;
    public GameObject EnemyPrefab;
    public float SpawnInterval = 2f;
    public int CountEnemies = 10;

    private float _timer;    
    private void Update()
    {
        _timer -= Time.deltaTime;
        if ((_timer < 0) && (--CountEnemies>-1))
        {
            Instantiate(EnemyPrefab).GetComponent<MoveEnemy>().WayPoints = WayPoints;

            _timer = SpawnInterval;
        }
    }
}
