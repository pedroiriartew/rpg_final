using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _rotationPower= 1f;
    [SerializeField] private Transform _playerTransform;

    private void Update()//Revisar que carajo hice acá
    {
        Rotate();
    }

    private void Rotate()
    {
        float horizontalMovement = Input.GetAxis("Mouse X");
        float verticalMovement = Input.GetAxis("Mouse Y");

        transform.rotation *= Quaternion.AngleAxis(horizontalMovement * _rotationPower, Vector3.up);

        transform.rotation *= Quaternion.AngleAxis(verticalMovement * _rotationPower, Vector3.right);

        Vector3 angles = transform.localEulerAngles;
        angles.z = 0;

        float angle = transform.localEulerAngles.x;

        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        transform.localEulerAngles = angles;

        _playerTransform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.localEulerAngles = new Vector3(angles.x, 0, 0);
    }
}
