using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void Set_Ru ()
    {
        PlayerPrefs.SetString("GameLanguage", "RU"); //сохранение пары ключ-значение
        Debug.Log("язык сменилс€ на –усский");
    }
    public void Set_En ()
    {
        PlayerPrefs.SetString("GameLanguage", "EN"); 
        Debug.Log("язык сменилс€ на јнглийский");

    }

}
