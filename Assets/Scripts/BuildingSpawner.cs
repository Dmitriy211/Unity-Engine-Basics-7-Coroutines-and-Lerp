using System;
using System.Collections;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private Building _buildingPrefab;
    [SerializeField] private float _cooldownTime;

    private bool _isBuilding;
    
    private bool _isCooldown;
    private PlayerResources _playerResources;

    private void Awake()
    {
        // Not Optimized, change to Singleton
        _playerResources = FindObjectOfType<PlayerResources>();
    }
    
    private void Update()
    {
        if (_isBuilding == false) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
            {
                if (hitInfo.transform.CompareTag("Ground"))
                {
                    SpawnBuilding(hitInfo.point);
                    _isBuilding = false;
                }
            }
        }
    }

    public void StartBuilding(Building buildingPrefab)
    {
        _isBuilding = true;
        _buildingPrefab = buildingPrefab;
    }

    public void SpawnBuilding(Vector3 position)
    {
        if (_isCooldown == false)
        {
            if (_playerResources.TrySpendMoney(_buildingPrefab.buildingData.price) == false) return;
            Instantiate(_buildingPrefab, position, Quaternion.identity, transform);
            StartCoroutine(CooldownRoutine(_cooldownTime));
        }
    }

    private IEnumerator CooldownRoutine(float cooldownTime)
    {
        _isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        _isCooldown = false;
    }
}
