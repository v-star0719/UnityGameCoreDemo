using Kernel.Core;
using UnityEngine;

public class TestBTNodeRandomMoveSpeedUp : BTNode
{
    private TestBehaviorTreeAI t;
    public TestBTNodeRandomMoveSpeedUp(TestBehaviorTreeAI t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        var actor = t.actor;
        if(actor.IsArrivedAt(actor.randomPos))
        {
            actor.speedUp = 1;
            return BTNodeStatus.Success;
        }

        actor.speedUp = 10;
        actor.MoveTo(actor.randomPos, deltaTime);
        return BTNodeStatus.Running;
    }

    public override void Exist()
    {
        t.actor.speedUp = 1;
        Debug.Log("TestBTNodeRandomMoveSpeedUp exist");
    }
}