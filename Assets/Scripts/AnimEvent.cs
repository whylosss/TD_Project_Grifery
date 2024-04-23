using System;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    public static Action checkRay;
    public void SendRay()
    {
        checkRay?.Invoke();
    }
}
