using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class AbstractLevel : MonoBehaviour
{
    public TextMeshProUGUI helpTextMesh;
    public Transform playerSpawnTransform;
    public SimpleEditor editor;
    public LevelManager levelManager;
    protected bool run = false;

    public virtual void Run()
    {
        run = true;
    }
    
    public virtual void Stop()
    {
        run = false;
    }

    public virtual void Reset()
    {
        run = false;
    }
}
