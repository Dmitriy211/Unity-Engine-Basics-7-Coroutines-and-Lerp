using UnityEngine;

public class ObjectRaycaster : MonoBehaviour
{
    private Building _currentBuilding;
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            if (hitInfo.transform.TryGetComponent(out Building building))
            {
                if (_currentBuilding == building) return;
                HoverExit();
                building.OnHoverEnter();
                _currentBuilding = building;
            }
            else HoverExit();
        }
        else HoverExit();
    }

    private void HoverExit()
    {
        if (_currentBuilding != null)
        {
            _currentBuilding.OnHoverExit();
            _currentBuilding = null;
        }
    }
}
