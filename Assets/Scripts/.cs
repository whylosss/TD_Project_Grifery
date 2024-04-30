using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ServiceBase : IService
{
    public int _version { get; }

    public ServiceBase(int version)
    {
        _version = version;
    }
}
