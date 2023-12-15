using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleInput : MonoBehaviour
{
    public static ConsoleInput Instance { get; private set; }

    //код для обработки ввода 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string GetInputText()
    {
        //код для получения текста из поля ввода
        return "";
    }

    public void ClearInputText()
    {
        //код для очистки поля ввода
    }
}