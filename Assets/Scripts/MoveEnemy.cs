using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] WayPoints;
    public float SpeedEnemy = 1.0f;

    private float _startToEndTravelTime;
    private int _currentWayPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        //WayPoints = GameObject.Find("PointsForEnemiesEast").transform;
        _startToEndTravelTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = WayPoints[_currentWayPoint].transform.position;
        Vector3 endPosition = WayPoints[_currentWayPoint + 1].transform.position;
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / SpeedEnemy;
        float currentTimeOnPath = Time.time - _startToEndTravelTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (_currentWayPoint < WayPoints.Length - 2)
            {
                _currentWayPoint++;
                _startToEndTravelTime = Time.time;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
