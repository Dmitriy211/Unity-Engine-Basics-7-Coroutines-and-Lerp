using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBuildingButton : MonoBehaviour
{
    public BuildingData buildingData;

    [SerializeField] private TMP_Text _text;
    
    private BuildingSpawner _buildingSpawner;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buildingSpawner = FindObjectOfType<BuildingSpawner>();
    }

    private void Start()
    {
        _text.text = buildingData.name;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(() =>
            { _buildingSpawner.StartBuilding(buildingData.buildingPrefab); }
        );
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(() =>
            { _buildingSpawner.StartBuilding(buildingData.buildingPrefab); }
        );
    }
}
