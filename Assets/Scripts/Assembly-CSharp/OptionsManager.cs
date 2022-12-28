using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Token: 0x0200001B RID: 27
public class OptionsManager : MonoBehaviour
{
    //used code from bambi racing, SHHHHHHHHHHHH
    public Toggle fullscreenOpt, vsyncOpt;
    public TMP_Dropdown resDrp;
    private List<Resolution> resolutions = new List<Resolution>();
    private int resIndex = 0;

    private void Start()
    {
        fullscreenOpt.isOn = Screen.fullScreen;
        vsyncOpt.isOn = (QualitySettings.vSyncCount == 0) ? false : true;

        resolutions = Screen.resolutions.ToList();
        List<string> resList = new List<string>();

        foreach (Resolution res in resolutions)
        {
            resList.Add(res.ToString());
        }

        resDrp.AddOptions(resList);

        bool foundRes = false;
        for(int i = 0; i < resolutions.Count; i++)
        {
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                foundRes = true;
                resIndex = i;
            }
        }

        if(foundRes) resDrp.value = resIndex;

        if (PlayerPrefs.HasKey("OptionsSet"))
        {
            this.slider.value = PlayerPrefs.GetFloat("MouseSensitivity");
            if (PlayerPrefs.GetInt("Rumble") == 1)
            {
                this.rumble.isOn = true;
            }
            else
            {
                this.rumble.isOn = false;
            }
            if (PlayerPrefs.GetInt("AnalogMove") == 1)
            {
                this.analog.isOn = true;
            }
            else
            {
                this.analog.isOn = false;
            }
            if (PlayerPrefs.GetInt("DarkMode") == 1)
            {
                this.darkMode.isOn = true;
            }
            else
            {
                this.darkMode.isOn = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("OptionsSet", 1);
        }
    }

    // Token: 0x06000062 RID: 98 RVA: 0x00003850 File Offset: 0x00001C50
    private void Update()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", this.slider.value);
        if (this.rumble.isOn)
        {
            PlayerPrefs.SetInt("Rumble", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Rumble", 0);
        }
        if (this.analog.isOn)
        {
            PlayerPrefs.SetInt("AnalogMove", 1);
        }
        else
        {
            PlayerPrefs.SetInt("AnalogMove", 0);
        }
        if (this.darkMode.isOn)
        {
            PlayerPrefs.SetInt("DarkMode", 1);
        }
        else
        {
            PlayerPrefs.SetInt("DarkMode", 0);
        }
        if (this.vsyncOpt.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }

    public void changeResIndex(int value)
    {
        resIndex = value;
    }

    public void ApplyChanges()
    {
        Screen.fullScreen = fullscreenOpt.isOn;
        Screen.SetResolution(resolutions[resIndex].width, resolutions[resIndex].height, fullscreenOpt.isOn, resolutions[resIndex].refreshRate);
    }

    // Token: 0x0400006F RID: 111
    public Slider slider;

    // Token: 0x04000070 RID: 112
    public Toggle rumble;

    // Token: 0x04000071 RID: 113
    public Toggle analog;

    // Token: 0x04000072 RID: 114
    public Toggle darkMode;
}
