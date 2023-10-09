using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    [SerializeField]
    private GameObject _cam;
    [SerializeField]
    private Transform _player;

    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX * 100;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY * 100;

        _yRotation += mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _cam.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _player.transform.rotation = Quaternion.Euler(_player.transform.rotation.x, _yRotation, _player.transform.rotation.z);
    }
}
