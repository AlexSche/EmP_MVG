using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class LogicDependency : LogicStateProvider
{
    [SerializeReference]
    public LogicDependency[] children;
    public Operation operation;
    public bool not;
    public bool proxy;
    [SerializeReference]
    public LogicBehaviour proxyObject;
    public bool GetCurrentState()
    {
        if (proxy)
            return not ? !proxyObject.GetCurrentState() : proxyObject.GetCurrentState();
        bool res;
        switch (operation)
        {
            case Operation.AND:
                res = children.All(ld => ld.GetCurrentState());
                break;
            case Operation.OR:
                res = children.Any(ld => ld.GetCurrentState());
                break;
            default:
                res = false;
                break;
        }

        return not ? !res : res;
    }

    public bool isValid()
    {
        return (!proxy && children.Length != 0) || proxy && proxyObject != null;
    }

    public enum Operation
    {
        AND,
        OR
    }
}