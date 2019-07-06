﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPauseScript : MonoBehaviour
{
    private Canvas TriggeredCanvas;
    public Canvas PauseCanvas;
    public Canvas GlossaryCanvas;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        TriggeredCanvas = GetComponent<Canvas>();
        PauseCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* SHOWING THE MAIN MENU */

    public void ShowPause()
    {
        camera.transform.SetParent(PauseCanvas.transform);
        TriggeredCanvas.gameObject.SetActive(false);
        PauseCanvas.gameObject.SetActive(true);
    }

    public void UnshowPause()
    {
        camera.transform.SetParent(TriggeredCanvas.transform);
        TriggeredCanvas.gameObject.SetActive(true);
        PauseCanvas.gameObject.SetActive(false);
    }

    /* SHOWING THE GLOSSARY */

    public void ShowGlossary()
    {
        SceneManager.LoadScene("Glossary");
        //GlossaryCanvas.gameObject.SetActive(true);
        //PauseCanvas.gameObject.SetActive(false);

    }

    public void ShowSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }



}