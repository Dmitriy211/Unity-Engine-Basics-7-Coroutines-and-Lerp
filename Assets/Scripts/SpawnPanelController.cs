using UnityEngine;


public class SpawnPanelController : MonoBehaviour
{
    [SerializeField] private SpawnBuildingButton _buttonPrefab;
    private BuildingData[] _allBuilding;
    
    private void Awake()
    {
        _allBuilding = Resources.LoadAll<BuildingData>("Buildings/");
        SpawnButtons();
    }

    private void SpawnButtons()
    {
        foreach (var building in _allBuilding)
        {
            var button = Instantiate(_buttonPrefab, transform);
            button.buildingData = building;
        }
    }
}