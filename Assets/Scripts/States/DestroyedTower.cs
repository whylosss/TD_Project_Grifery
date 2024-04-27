using UnityEngine;

public class DestroyedTower : ITowerBehavior
{
    public void Enter()
    {
        Debug.Log("Enter destroyed state");
    }

    public void Exit()
    {
        Debug.Log("Exit destroyed state");
    }

    public void Update()
    {
        Debug.Log("Update destroyed state");
    }
}
