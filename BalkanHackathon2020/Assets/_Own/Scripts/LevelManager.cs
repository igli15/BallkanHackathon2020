using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public AbstractLevel[] levels;
    public SimpleEditor editor;
    public GameObject endPanel;
    private int currentLevelIndex = 0;

    private void Start()
    {
        levels[0].enabled = true;
        levels[0].Run();
        currentLevelIndex = 0;
    }

    public void MoveToNextLevel()
    {
        if (currentLevelIndex == levels.Length -1)
        {
            endPanel.SetActive(true);
            return;
        }
        
        levels[currentLevelIndex].gameObject.SetActive(false);
        levels[currentLevelIndex].Stop();
        editor.ResetEditor();
        currentLevelIndex++;
        levels[currentLevelIndex].gameObject.SetActive(true);
        
    }

    public void ResetCurrentLevel()
    {
        levels[currentLevelIndex].Reset();
    }
}
