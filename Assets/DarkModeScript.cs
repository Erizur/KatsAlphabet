using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkModeScript : MonoBehaviour
{
    public GameObject darkMode;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("DarkMode") == 1)
        {
            darkMode.SetActive(true);
        }
        else
        {
            darkMode.SetActive(false);
        }
    }
}
