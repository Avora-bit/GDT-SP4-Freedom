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
