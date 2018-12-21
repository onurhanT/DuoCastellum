using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public Controller controller;

    public State()
    {
        
    }
    public virtual void OnPlay() { }
    public virtual void OnBack() { }
    public virtual void OnNext() { }
    public virtual void OnOptions() { }
    public virtual void OnCredits() { }

}
