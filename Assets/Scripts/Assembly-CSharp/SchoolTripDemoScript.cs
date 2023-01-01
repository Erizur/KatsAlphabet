using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SchoolTripDemoScript : MonoBehaviour
{
    public GameObject cursor;
    [SerializeField] private TMP_Text txt;
    private string[] errorDialogs = new string[]{
        "DEMO HAS ERROR. EXITING ",
        "PLEASE DO NOT CONTINUE RUNNING ",
        "THIS DEMO DOES NOT EXIST YET ",
        "KAT WILL HAUNT YOU SOON ",
        "NEVER CONTINUE ",
        "ERROR CODE 123 ",
        "DO NOT CONTINUE AHEAD! ERROR ",
        "PLEASE STOP DOING THIS ",
        "KAT SHOULD NOT ",
        "ERROR 59 PLEASE NO NONONO ",
        "GOOD JOB YOU BROKE THE GAME ",
        "E3G EEEEAK ERROR MOMENT ",
        "PLEASE THIS IS BAD STOP IT "
    };

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        cursor.transform.position = Input.mousePosition;
    }

    public void CrashGame()
    {
        StartCoroutine(crashAnimation(3));
    }

    IEnumerator crashAnimation(int secondsCrash)
    {
        float secondsTilCrash = secondsCrash;
        while(secondsTilCrash > 0)
        {
            secondsTilCrash -= 0.01f;
            int randText = Random.Range(0, errorDialogs.Length);
            txt.text += errorDialogs[randText];
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("NONONONON");
        Application.Quit();
    }
}
