using Kernel.Core;
using UnityEngine;

public class TestBTNodeIsHungry : BTNode
{
    private TestBehaviorTree1 t;
    public TestBTNodeIsHungry(TestBehaviorTree1 t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        return t.isHungry ? BTNodeStatus.Success : BTNodeStatus.Fail;
    }
}