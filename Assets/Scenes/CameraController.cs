using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerCameraPivot;
    public float sensitivity = 2.0f;

    private Vector2 rotation = Vector2.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // ѕолучаем ввод от мыши
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // ќбновл€ем горизонтальное и вертикальное вращение
        rotation.x += mouseX;
        rotation.y = Mathf.Clamp(rotation.y - mouseY, -90, 90); // ќграничиваем вертикальное вращение

        // ѕримен€ем вращение к "PlayerCameraPivot" дл€ горизонтального вращени€
        playerCameraPivot.localRotation = Quaternion.Euler(0, rotation.x, 0);

        // ѕримен€ем вращение к камере дл€ вертикального вращени€
        transform.localRotation = Quaternion.Euler(rotation.y, 0, 0);

        // ƒобавл€ем вращение к самому игроку дл€ горизонтального вращени€
        transform.parent.Rotate(Vector2.up, mouseX);
    }
}
