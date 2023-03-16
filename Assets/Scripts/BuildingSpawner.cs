using System;
using System.Collections;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private Building _buildingPrefab;
    [SerializeField] private float _cooldownTime;

    private bool _isCooldown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
            {
                if (hitInfo.transform.CompareTag("Ground"))
                    SpawnBuilding(hitInfo.point);
            }
        }
    }

    public void SpawnBuilding(Vector3 position)
    {
        if (_isCooldown == false)
        {
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
