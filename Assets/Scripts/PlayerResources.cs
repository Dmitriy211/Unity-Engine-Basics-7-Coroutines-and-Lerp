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

    public bool TrySpendMoney(int price)
    {
        if (_money > price)
        {
            _money -= price;
            UpdateUI();
            return true;
        }

        return false;
    }
    
    private void UpdateUI()
    {
        _moneyUI.text = _money.ToString();
    }
}
