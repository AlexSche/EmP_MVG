using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public abstract class LogicDependency : LogicStateProvider
{

    public abstract bool GetCurrentState();

    public abstract bool isValid();

    [Serializable]
    public enum Operation
    {
        AND,
        OR
    }
}