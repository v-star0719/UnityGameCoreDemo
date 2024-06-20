using Kernel.Core;
using UnityEngine;

public class TestBTNodeIsHit : BTNode
{
    private TestBehaviorTreeAI t;
    public TestBTNodeIsHit(TestBehaviorTreeAI t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        if (t.actor.isHit)
        {
            t.actor.isHit = false;
            if (Random.value > 0.3f)
            {
                return BTNodeStatus.Success;
            }
        }

        return BTNodeStatus.Fail;
    }
}