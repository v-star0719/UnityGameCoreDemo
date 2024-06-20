using Kernel.Core;
using UnityEngine;

public class TestBTNodeEatApple : BTNode
{
    private TestBehaviorTree1 t;
    public TestBTNodeEatApple(TestBehaviorTree1 t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        if(t.appleCount > 0)
        {
            t.appleCount -= 1;
            Debug.Log("eat 1 apple, left " + t.appleCount);
            return BTNodeStatus.Success;
        }
        else
        {
            return BTNodeStatus.Fail;
        }
    }
}