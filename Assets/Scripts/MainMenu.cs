﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator htpAnimator;
    public bool isHowOpen;
    public Animator aboutAnimator;
    public bool isAboutOpen;
    void Start()
    {
        var audioManager = AudioManager.GetInstance();
        audioManager.Stop("Ambient");
        audioManager.Play("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleHow()
    {
        if (isHowOpen)
        {
            htpAnimator.SetTrigger("Close");
            isHowOpen = false;
        }
        else
        {
            htpAnimator.SetTrigger("Open");
            isHowOpen = true;   
        }

    }public void ToggleAbout()
    {
        print("dasd");
        if (isAboutOpen)
        {
            aboutAnimator.SetTrigger("Close");
            isAboutOpen = false;
        }
        else
        {
            aboutAnimator.SetTrigger("Open");
            isAboutOpen = true;   
        }

    }
    
}
