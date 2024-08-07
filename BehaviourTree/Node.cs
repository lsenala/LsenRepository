using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Node : ScriptableObject 
{   
    public enum State { 
        Runing,
        Success,
        Failure
    }
    [HideInInspector]public State state = State.Runing;
    [HideInInspector]public bool started;
    [HideInInspector]public string guid;
    [HideInInspector]public Vector2 position;
    public virtual Node Clone() {
        return Instantiate(this);
    }
    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract State OnUpdate();
    public State Update()
    {       
        if (!started) {
            OnStart();
            started = true;
        }     
        state = OnUpdate();
        if (state == State.Failure || state == State.Success) {
            OnStop();
            started = false;
        }
        return state;           
    }
}
