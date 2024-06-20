using Kernel.Core;
using UnityEngine;

public class TestBTNodeSearchTarget : BTNode
{
    private TestBehaviorTreeAI t;
    public TestBTNodeSearchTarget(TestBehaviorTreeAI t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        var rt = t.actor.test2.SearchTarget(t.actor.transform.position, t.actor.viewField);
        if (rt)
        {
            t.actor.target = rt;
            return BTNodeStatus.Success;
        }

        return BTNodeStatus.Fail;
    }
}