using Kernel.Core;
using UnityEngine;

public class TestBTNodeEatBanana : BTNode
{
    private TestBehaviorTree1 t;
    public TestBTNodeEatBanana(TestBehaviorTree1 t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        if(t.bananCount > 0)
        {
            t.bananCount -= 1;
            Debug.Log("eat 1 banana, left " + t.bananCount);
            return BTNodeStatus.Running;
        }
        else
        {
            return BTNodeStatus.Fail;
        }
    }
}