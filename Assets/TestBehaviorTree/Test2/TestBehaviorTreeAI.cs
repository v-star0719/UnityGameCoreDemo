using System;
using System.Collections;
using System.Collections.Generic;
using Kernel.Core;
using UnityEngine;

public class TestBehaviorTreeAI
{
    public BehaviorTree tree;
    public TestBehaviorTreeActor actor;

    public TestBehaviorTreeAI(TestBehaviorTreeActor actor)
    {
        this.actor = actor;

        tree = new BehaviorTree();
        if(actor.isEnemy)
        {
            var idle = new BTNodeSequence(tree,
                new TestBTNodeRandomPos(this),
                new TestBTNodeRandomMove(this));

            var run = new BTNodeSequence(tree,
                new TestBTNodeIsHit(this),
                new TestBTNodeRandomMoveSpeedUp(this)
            );
            tree.root = new BTNodeSelector(tree,
                run,
                idle);
        }
        else
        {
            tree.root = new BTNodeSequence(tree,
                new TestBTNodeSearchTarget(this),
                new TestBTNodeMoveToTarget(this),
                new TestBTNodeAttack(this));
        }
    }

    // Update is called once per frame
    public void Tick(float deltaTime)
    {
        tree.Tick(deltaTime);
    }
}
