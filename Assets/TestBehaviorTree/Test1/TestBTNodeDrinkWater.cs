using Kernel.Core;
using UnityEngine;

public class TestBTNodeDrinkWater : BTNode
{
    private TestBehaviorTree1 t;
    public TestBTNodeDrinkWater(TestBehaviorTree1 t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        t.isThirsty = false;
        Debug.Log("drink water");
        return BTNodeStatus.Success;
    }
}