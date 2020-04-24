using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlaceForTower : MonoBehaviour
{
    public GameObject TowerPrefab;

    private GameObject _tower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool CanPlaceTower()
    {
        return _tower = null;
    }
    public void OnMouseUp()
    {
        if (!CanPlaceTower())
        {
            _tower = (GameObject)
                Instantiate(TowerPrefab, transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
