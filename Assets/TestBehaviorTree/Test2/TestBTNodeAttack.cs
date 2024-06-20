using Kernel.Core;
using UnityEngine;

public class TestBTNodeAttack : BTNode
{
    private TestBehaviorTreeAI t;
    public TestBTNodeAttack(TestBehaviorTreeAI t) : base(t.tree)
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

        if (!actor.IsCollide(actor.target))
        {
            return BTNodeStatus.Fail;
        }

        if (actor.cd <= 0)
        {
            actor.Attack(actor.target);
        }

        if (actor.target.isDead)
        {
            actor.target = null;
            return BTNodeStatus.Success;
        }

        return BTNodeStatus.Success;
    }

    public override void Exist()
    {
        t.actor.target = null;
        Debug.Log("TestBTNodeMoveToTarget exist");
    }
}