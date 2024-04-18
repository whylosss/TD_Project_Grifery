using System;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public static Action<int> unlock;

    public void Unlock(int index)
    {
        unlock?.Invoke(index);
    }
}
