﻿using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] WayPoints;
    public float SpeedEnemy = 1.0f;

    private float _startToEndTravelTime;
    private int _currentWayPoint = 0;
    void Start()
    {
        _startToEndTravelTime = Time.time;
    }
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
                GameManagerBehavior gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
                gameManager.Health -= 1;
            }
        }
    }
    public float DistanceToAim()
    {
        float distance = 0;
        distance += Vector3.Distance(gameObject.transform.position, WayPoints[_currentWayPoint + 1].transform.position);
        for (int i = _currentWayPoint + 1; i<WayPoints.Length - 1; i++)
        {
            Vector3 startPosition = WayPoints[i].transform.position;
            Vector3 endPosition = WayPoints[i].transform.position;
            distance += Vector3.Distance(startPosition, endPosition);
        }
        return distance;
    }
}
