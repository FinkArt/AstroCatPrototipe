using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void Set_Ru ()
    {
        PlayerPrefs.SetString("GameLanguage", "RU"); //���������� ���� ����-��������
        Debug.Log("���� �������� �� �������");
    }
    public void Set_En ()
    {
        PlayerPrefs.SetString("GameLanguage", "EN"); 
        Debug.Log("���� �������� �� ����������");

    }

}
