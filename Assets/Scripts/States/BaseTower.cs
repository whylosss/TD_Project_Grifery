using UnityEngine;
public class BaseTower : ITowerBehavior
{
    public void Enter()
    {
        Debug.Log("Enter destroyed base");
    }

    public void Exit()
    {
        Debug.Log("Exit base state");
    }

    public void Update()
    {
        Debug.Log("Update base state");
    }
}
