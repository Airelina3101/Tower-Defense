using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float Speed = 10;
    public int Damage = 50;
    public GameObject Target;
    public Vector3 StartPosition;
    public Vector3 TargetPosition;

    private float _startTime;
    private float _distance;
    private GameManagerBehavior _gameManager;
    void Start()
    {
        _startTime = Time.time;
        _distance = Vector3.Distance(StartPosition, TargetPosition);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }
    void Update()
    {
        float timeInterval = Time.time - _startTime;
        gameObject.transform.position = Vector3.Lerp(StartPosition, TargetPosition, timeInterval * Speed / _distance);
        if (gameObject.transform.position.Equals(TargetPosition))
        {
            if (Target!=null)
            {
                Destroy(Target);
                _gameManager.Money += 20;                    
            }
            Destroy(gameObject);
        }
    }
}
