using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLevel : MonoBehaviour
{
    protected bool run = false;

    public virtual void Run()
    {
        run = true;
    }

    public virtual void Stop()
    {
        run = false;
    }
    
    public virtual void End()
    {
        run = true;
    }
}
