using Kernel.Core;
using UnityEngine;

public class TestBTNodeRandomPos : BTNode
{
    private TestBehaviorTreeAI t;
    public TestBTNodeRandomPos(TestBehaviorTreeAI t) : base(t.tree)
    {
        this.t = t;
    }
    public override BTNodeStatus Tick(float deltaTime)
    {
        var s = TestBehaviorTree2.WORLD_SIZE;
        t.actor.randomPos.x = Random.Range(-s, s);
        t.actor.randomPos.z = Random.Range(-s, s);
        return BTNodeStatus.Success;
    }
}