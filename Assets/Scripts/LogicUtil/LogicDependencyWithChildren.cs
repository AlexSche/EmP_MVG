using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class LogicDependencyWithChildren<C> : LogicDependency where C : LogicDependency
{
    public LogicDependency.Operation operation;
    public bool not;
    public bool proxy;
    [SerializeReference]
    public LogicBehaviour proxyObject;
    public List<C> children;
    public override bool GetCurrentState()
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
    
    public override bool isValid()
    {
        return (!proxy && children.Count != 0) || proxy && proxyObject != null;
    }
}