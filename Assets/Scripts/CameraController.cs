using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private int _screenEdgeWidth = 5;
    [SerializeField] private float _moveSpeed = 5;
    
    private void Update()
    {
        Move(CalculateMoveVector());
    }

    private void Move(Vector3 moveVector)
    {
        transform.Translate(moveVector * _moveSpeed * Time.deltaTime, Space.Self);
    }

    private Vector3 CalculateMoveVector()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 moveVector = Vector3.zero;
        
        if (mousePosition.x < _screenEdgeWidth) moveVector += Vector3.left;
        else if (mousePosition.x > Screen.width - _screenEdgeWidth) moveVector += Vector3.right;
        
        if (mousePosition.y < _screenEdgeWidth) moveVector += Vector3.back;
        else if (mousePosition.y > Screen.height - _screenEdgeWidth) moveVector += Vector3.forward;

        return moveVector;
    }
}
