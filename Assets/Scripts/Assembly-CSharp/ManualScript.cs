using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualScript : MonoBehaviour
{
    public GameObject[] manualPages;
    public int index;

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            if(index < manualPages.Length - 1){
                this.NextPage();
                this.UpdatePage();
            }
        }
        else if(Input.GetMouseButtonDown(1)){
            if(index > 0){
                this.PreviousPage();
                this.UpdatePage();
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void NextPage()
    {
        if (index < manualPages.Length - 1)
        {
            index++;
        }
    }

    public void PreviousPage()
    {
        if (index > 0)
        {
            index--;
        }
    }

    public void UpdatePage()
    {
        for (int i = 0; i < manualPages.Length; i++)
        {
            if (i == index)
            {
                manualPages[i].SetActive(true);
            }
            else
            {
                manualPages[i].SetActive(false);
            }
        }
    }
}
