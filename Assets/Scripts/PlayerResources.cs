using TMPro;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyUI;
    
    private int _money;

    public void AddMoney(int income)
    {
        _money += income;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _moneyUI.text = _money.ToString();
    }
}
