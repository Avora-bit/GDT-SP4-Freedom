using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Settings : MonoBehaviour
{
    // Start is called before the first frame update
    public int bgmvol;
    public int sfxvol;
    public Text bgmdisplay;
    public Text sfxdisplay;
    
    public Image SettingsScreen;
    void Start()
    {
        bgmvol = PlayerPrefs.GetInt("BGMVOLUME");
        sfxvol = PlayerPrefs.GetInt("SFXVOLUME");
        bgmdisplay.text = bgmvol.ToString();
        sfxdisplay.text = sfxvol.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setBGMvol(float num)
    {
        bgmvol = (int)num;
        bgmdisplay.text = bgmvol.ToString();
    }

    public void setSFXvol(float num)
    {
        sfxvol = (int)num;
        sfxdisplay.text = sfxvol.ToString();
    }

    public void setHealthBarToggle(bool input)
    {
        int a = 1;
        if (input)
        {
            a = 1;
        }
        else
        {
            a = 0;
        }
        PlayerPrefs.SetInt("HPBARON", a);
        Debug.Log(PlayerPrefs.GetInt("HPBARON"));
    }

    public void setStaminaBarToggle(bool input)
    {
        int a = 1;
        if (input)
        {
            a = 1;
        }
        else
        {
            a = 0;
        }
        PlayerPrefs.SetInt("STAMBARON", a);
        Debug.Log(PlayerPrefs.GetInt("STAMBARON"));
    }

    public void setArrowCountToggle(bool input)
    {
        int a = 1;
        if (input)
        {
            a = 1;
        }
        else
        {
            a = 0;
        }
        PlayerPrefs.SetInt("ARROWCOUNTON", a);
        Debug.Log(PlayerPrefs.GetInt("ARROWCOUNTON"));
    }

    public void Save()
    {
        PlayerPrefs.SetInt("BGMVOLUME", bgmvol);
        PlayerPrefs.SetInt("SFXVOLUME", sfxvol);
        SettingsScreen.gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        SettingsScreen.gameObject.SetActive(true);
    }
}
