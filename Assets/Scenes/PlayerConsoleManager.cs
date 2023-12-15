using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager_1 : MonoBehaviour
{
    private bool isConsoleOpen = false;
    private bool isNoclipEnabled = false;
    private Rigidbody rb;

    public GameObject consolePanel; // ������� ��� ���������� � �������� ������ ������� � Unity
    public InputField consoleInputField; // ������� ��� ���������� � �������� ���� ����� ������� � Unity

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // ���������, ��� ������ ������� ���������� �� ������������
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
            string inputText = consoleInputField.text;

            if (inputText.ToLower() == "noclip on")
            {
                EnableNoclip();
            }
            else if (inputText.ToLower() == "noclip off")
            {
                DisableNoclip();
            }

            consoleInputField.text = ""; // ������� ���� �����
            ToggleConsole(); // ��������� ������� ����� ����� �������
        }
    }

    void ToggleConsole()
    {
        // ��������� � ���������� ������ �������
        isConsoleOpen = !isConsoleOpen;
        consolePanel.SetActive(isConsoleOpen);

        // ���� ������ ������� ��������, ���������� ����� �� ���� �����
        if (isConsoleOpen)
        {
            consoleInputField.Select();
            consoleInputField.ActivateInputField();
        }

        // ��������� � ���������� ������� � ����������� �� ��������� �������
        Cursor.lockState = isConsoleOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isConsoleOpen;
    }

    void EnableNoclip()
    {
        isNoclipEnabled = true;
        rb.isKinematic = true;

        Debug.Log("Noclip enabled!");
    }

    void DisableNoclip()
    {
        isNoclipEnabled = false;
        rb.isKinematic = false;

        Debug.Log("Noclip disabled!");
    }
}