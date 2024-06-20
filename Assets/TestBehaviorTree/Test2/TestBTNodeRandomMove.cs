using Kernel.Core;
using UnityEngine;

public class TestBTNodeRandomMove : BTNode
{
    private TestBehaviorTreeAI t;
    public TestBTNodeRandomMove(TestBehaviorTreeAI t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        var actor = t.actor;
        if(actor.IsArrivedAt(actor.randomPos))
        {
            return BTNodeStatus.Success;
        }

        actor.MoveTo(actor.randomPos, deltaTime);
        return BTNodeStatus.Running;
    }

    public override void Exist()
    {
        Debug.Log("TestBTNodeRandomMove exist");
    }
}