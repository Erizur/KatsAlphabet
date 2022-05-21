using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    public bool isHidden = false;
    public GameObject minimap;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            isHidden = !isHidden;
            minimap.SetActive(isHidden);
        }
    }
}
