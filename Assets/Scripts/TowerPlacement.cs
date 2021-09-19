using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private Tower _placedTower;
    private Tower _candidateTower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fungsi yang terpanggil sekali ketika ada object Rigidbody yang menyentuh area collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_placedTower != null)
        {
            return;
        }
        
        Tower tower = collision.GetComponent<Tower>();
        if (tower != null)
        {
            _candidateTower = tower;
            _candidateTower.SetPlacePosition(transform.position);
        }
    }

    // Kebalikan dari OnTriggerEnter2D, fungsi ini terpanggil sekali ketika object tersebut meninggalkan area collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_placedTower == null)
        {
            _placedTower = _candidateTower;
            _candidateTower.SetPlacePosition(null);
            _candidateTower = null;
        }
    }

    public Tower GetPlacedTower()
    {
        return _placedTower;
    }

    public void SetPlacedTower(Tower tower = null)
    {
        _placedTower = tower;
    }
}
