
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class LogicBehaviour : MonoBehaviour, LogicStateProvider
{
    public bool state = false;
    private bool _oldState = false;

    private bool _hasDependency = false;

    [SerializeField]
    private LogicDependency _dependencyInt;
    
    public LogicDependency Dependency
    {
        get => _dependencyInt;
        set
        {
            _dependencyInt = value;
            _hasDependency = value.isValid();
        }
    }


    public void Start()
    {
        _hasDependency = _dependencyInt.isValid();
        CustomStart();
    }

    public void FixedUpdate()
    {
        if (_hasDependency)
            state = _dependencyInt.GetCurrentState();
        if(_oldState != state)
            OnLogicStateChange();
        _oldState = state;

        CustomFixedUpdate();
    }

    protected virtual void CustomFixedUpdate()
    {
        
    }

    protected virtual void CustomStart()
    {
        
    }

    protected virtual void OnLogicStateChange()
    {
    }

    public bool GetCurrentState()
    {
        return state;
    }
    
    
}