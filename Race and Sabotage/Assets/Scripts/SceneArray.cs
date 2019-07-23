﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneArray : MonoBehaviour
{
    public static string[] ArrayOfScenes = {"Loading1", "Loading2", "Loading3", "Loading4", "Loading6", "Loading5", "Loading7", "Loading8", "Loading9", "Loading10", "Loading11","Loading12", "Loading13", "Loading14", "Loading15", "Loading16", "FinishedScene"};


	public static int SceneNumber = -1;

    public void NextScene()
    {
        if (SceneNumber >= ArrayOfScenes.Length)
        {
            SceneNumber = 0;
        }
        SceneNumber++;
        SceneManager.LoadScene(ArrayOfScenes[SceneNumber]);

        PrintArray();
    }

    public void LoadFirstLevel()
	{
        SceneManager.LoadScene(ArrayOfScenes[SceneNumber]);
        SceneNumber++;
	}

    public void WrongAnswer()
    {
        NextScene();
        string wrong = ArrayOfScenes[SceneNumber-1];
        for (int i = SceneNumber; i < ArrayOfScenes.Length; i++)
        {
            ArrayOfScenes[i-1] = ArrayOfScenes[i];
        }
        ArrayOfScenes[ArrayOfScenes.Length - 1] = wrong;
        SceneNumber--;

        string FinishedScene = ArrayOfScenes[ArrayOfScenes.Length - 2];
        string WrongScene = ArrayOfScenes[ArrayOfScenes.Length - 1];
        ArrayOfScenes[ArrayOfScenes.Length - 2] = WrongScene;
        ArrayOfScenes[ArrayOfScenes.Length - 1] = FinishedScene;

        PrintArray();
    }

    void PrintArray()
    {
        string statement = "THE ARRAY RIGHT NOW IS ";
        for (int i = 0; i < ArrayOfScenes.Length; i++)
        {
            statement += (ArrayOfScenes[i] + " ");
        }

    }

}
