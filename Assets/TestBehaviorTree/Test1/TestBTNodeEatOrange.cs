using Kernel.Core;
using UnityEngine;

public class TestBTNodeEatOrange : BTNode
{
    private TestBehaviorTree1 t;
    public TestBTNodeEatOrange(TestBehaviorTree1 t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        if (t.orangeCount > 0)
        {
            t.orangeCount -= 1;
            Debug.Log("eat 1 orange, left " + t.orangeCount);
            return BTNodeStatus.Success;
        }
        else
        {
            t.isHungry = false;
            return BTNodeStatus.Fail;
        }
    }
}