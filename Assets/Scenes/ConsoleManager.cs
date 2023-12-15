using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour
{
    private bool isConsoleOpen = false;
    private bool isNoclipEnabled = false;
    private Rigidbody playerRigidbody;
    public Transform maincamera;
    public GameObject consolePanel;
    public InputField consoleInputField;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        consolePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleConsole();
        }

        if (isConsoleOpen && Input.GetKeyDown(KeyCode.Return))
        {
            string inputText = consoleInputField.text.ToLower();

            if (inputText == "noclip on")
            {
                EnableNoclip();
            }
            else if (inputText == "noclip off")
            {
                DisableNoclip();
            }

            consoleInputField.text = "";
            consolePanel.SetActive(false);
        }

        if (isNoclipEnabled)
        {
            float moveSpeed = 10f;
            float verticalSpeed = 10f;
            float speedMultiplier = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? 2f : 1f; // Ускорение при зажатии Shift
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveDirection = maincamera.transform.TransformDirection(new Vector3(horizontal, 0f, vertical)).normalized;
            Vector3 moveVelocity = moveDirection * moveSpeed * speedMultiplier;

            moveVelocity.y += (Input.GetKey(KeyCode.Space) ? 1f : 0f) * verticalSpeed;
            moveVelocity.y -= (Input.GetKey(KeyCode.LeftControl) ? 1f : 0f) * verticalSpeed;

            playerRigidbody.velocity = moveVelocity;
        }
    }

    void ToggleConsole()
    {
        isConsoleOpen = !isConsoleOpen;
        consolePanel.SetActive(isConsoleOpen);

        if (isConsoleOpen)
        {
            consoleInputField.Select();
            consoleInputField.ActivateInputField();
        }

        Cursor.lockState = isConsoleOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isConsoleOpen;
    }

    void EnableNoclip()
    {
        isNoclipEnabled = true;
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.useGravity = false;
        Debug.Log("Noclip enabled!");
    }

    void DisableNoclip()
    {
        isNoclipEnabled = false;
        playerRigidbody.useGravity = true;
        Debug.Log("Noclip disabled!");
    }
}