using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleInput : MonoBehaviour
{
    public static ConsoleInput Instance { get; private set; }

    //��� ��� ��������� ����� 

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
        //��� ��� ��������� ������ �� ���� �����
        return "";
    }

    public void ClearInputText()
    {
        //��� ��� ������� ���� �����
    }
}