using Kernel.Core;
using UnityEngine;

public class TestBTNodeMoveToTarget : BTNode
{
    private TestBehaviorTreeAI t;
    public TestBTNodeMoveToTarget(TestBehaviorTreeAI t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        var actor = t.actor;
        if (actor.target == null)
        {
            return BTNodeStatus.Fail;
        }

        if (actor.IsCollide(actor.target))
        {
            return BTNodeStatus.Success;
        }

        actor.MoveTo(actor.target.transform.position, deltaTime);
        return BTNodeStatus.Running;
    }

    public override void Exist()
    {
        t.actor.target = null;
        Debug.Log("TestBTNodeMoveToTarget exist");
    }
}