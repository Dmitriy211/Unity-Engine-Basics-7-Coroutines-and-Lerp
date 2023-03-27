using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Custom/Building", order = 0)]
public class BuildingData : ScriptableObject
{
    public Building buildingPrefab;
    public int price = 10;
    public float incomePeriod = 5;
    public int income = 15;
}