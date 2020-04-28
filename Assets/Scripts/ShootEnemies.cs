using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour
{
    public List<GameObject> EnemiesInRange;
    public GameObject BulletPrefab;
    public float FireRate = 1;

    private float _lastShootTime;
    void Start()
    {
        EnemiesInRange = new List<GameObject>(); 
        _lastShootTime = Time.time;
    }

    private void Update()
    {
        GameObject target = null;
        float minTargetDistance = float.MaxValue;
        foreach (GameObject enemy in EnemiesInRange)
        {
            float distanceToTarget = enemy.GetComponent<MoveEnemy>().DistanceToAim();
            if (distanceToTarget < minTargetDistance)
            {
                target = enemy;
                minTargetDistance = distanceToTarget;
            }
        }
        if (target!=null)
        {
            if (Time.time - _lastShootTime > FireRate)
            {
                Shoot(target.GetComponent<Collider>());
                _lastShootTime = Time.time;
            }
        }
    }
    void OnEnemyDestroy(GameObject enemy)
    {
        EnemiesInRange.Remove(enemy);
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemiesInRange.Add(other.gameObject);
        EnemyDestructionDelegate delete = other.gameObject.GetComponent<EnemyDestructionDelegate>();
        delete.enemyDelegate += OnEnemyDestroy;
    }
    private void OnTriggerExit(Collider other)
    {
        EnemiesInRange.Remove(other.gameObject);
        EnemyDestructionDelegate delete = other.gameObject.GetComponent<EnemyDestructionDelegate>();
        delete.enemyDelegate -= OnEnemyDestroy;
    }
    private void Shoot(Collider target)
    {
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;

        GameObject newBullet = (GameObject)Instantiate(BulletPrefab);
        newBullet.transform.position = startPosition;
        BulletBehavior bullet = newBullet.GetComponent<BulletBehavior>();
        bullet.Target = target.gameObject;
        bullet.StartPosition = startPosition;
        bullet.TargetPosition = targetPosition;
    }
}
