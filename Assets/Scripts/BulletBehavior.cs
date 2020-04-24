using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float Speed = 10;
    public int Damage;
    public GameObject Target;
    public Vector3 StartPosition;
    public Vector3 TargetPosition;

    private float _startTime;
    private float _distance;
    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        _distance = Vector3.Distance(StartPosition, TargetPosition);
    }

    // Update is called once per frame
    void Update()
    {
        float timeInterval = Time.time - _startTime;
        gameObject.transform.position = Vector3.Lerp(StartPosition, TargetPosition, timeInterval * Speed / _distance);
        if (gameObject.transform.position.Equals(TargetPosition))
        {
            if (Target!=null)
            {
                Destroy(Target);
            }
            Destroy(gameObject);
        }
    }
}
