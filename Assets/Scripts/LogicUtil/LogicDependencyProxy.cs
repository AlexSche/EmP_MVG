using System;
using UnityEngine;

[Serializable]
public class LogicDependencyProxy : LogicDependency
{
    [SerializeReference]
    public LogicBehaviour proxyObject;

    public override bool GetCurrentState()
    {
        return proxyObject.GetCurrentState();
    }

    public override bool isValid()
    {
        return proxyObject != null;
    }
}