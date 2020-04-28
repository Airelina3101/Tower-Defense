using UnityEngine;

public class PlaceForTower : MonoBehaviour
{
    public GameObject TowerPrefab;

    private GameObject _tower;
    private GameManagerBehavior _gameManager;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

    private bool CanPlaceTower()
    {
        return _tower == null;
    }
    void OnMouseUp()
    {
        if (CanPlaceTower() && (_gameManager.Money-300>0))
        {
            _gameManager.Money -= 300;
            _tower = (GameObject)Instantiate(TowerPrefab, transform.position, Quaternion.identity);
        }
    }
}
