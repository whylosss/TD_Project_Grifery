using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimEvent : MonoBehaviour
{
    public static Action checkRay;
    public void SendRay()
    {
        checkRay?.Invoke();
    }
}
