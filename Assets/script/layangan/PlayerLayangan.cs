using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayangan : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        Vector3 movement = new Vector3(_joystick.Horizontal, _joystick.Vertical, 0); // Mengabaikan sumbu Z
        _transform.Translate(movement * _moveSpeed * Time.deltaTime);
    }
}
