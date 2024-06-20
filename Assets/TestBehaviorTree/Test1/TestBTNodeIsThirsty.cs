using Kernel.Core;
using UnityEngine;

public class TestBTNodeIsThirsty : BTNode
{
    private TestBehaviorTree1 t;
    public TestBTNodeIsThirsty(TestBehaviorTree1 t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        return t.isThirsty ? BTNodeStatus.Success : BTNodeStatus.Fail;
    }
}