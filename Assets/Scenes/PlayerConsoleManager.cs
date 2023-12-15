using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager_1 : MonoBehaviour
{
    private bool isConsoleOpen = false;
    private bool isNoclipEnabled = false;
    private Rigidbody rb;

    public GameObject consolePanel; // Свяжите эту переменную с объектом панели консоли в Unity
    public InputField consoleInputField; // Свяжите эту переменную с объектом поле ввода консоли в Unity

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Убедитесь, что панель консоли изначально не отображается
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

            consoleInputField.text = ""; // Очистка поля ввода
            ToggleConsole(); // Закрываем консоль после ввода команды
        }
    }

    void ToggleConsole()
    {
        // Включение и отключение панели консоли
        isConsoleOpen = !isConsoleOpen;
        consolePanel.SetActive(isConsoleOpen);

        // Если панель консоли включена, установите фокус на поле ввода
        if (isConsoleOpen)
        {
            consoleInputField.Select();
            consoleInputField.ActivateInputField();
        }

        // Включение и отключение курсора в зависимости от состояния консоли
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