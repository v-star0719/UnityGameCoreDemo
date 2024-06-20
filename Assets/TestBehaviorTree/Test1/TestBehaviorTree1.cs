using System.Collections;
using System.Collections.Generic;
using Kernel.Core;
using UnityEngine;

public class TestBehaviorTree1 : MonoBehaviour
{
    public bool updateBtn;
    public BehaviorTree tree;

    public int appleCount = 5;
    public int bananCount = 5;
    public int orangeCount = 5;
    public bool isHungry = false;
    public bool isThirsty = false;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        tree = new BehaviorTree();
        //var root = new BTNodeSelector(tree);
        //var drink = new BTNodeSequence(tree,
        //    new TestBTNodeIsThirsty(this),
        //    new TestBTNodeDrinkWater(this)
        //    );

        //var eat = new BTNodeSequence(tree,
        //    new TestBTNodeIsHungry(this),
        //    new BTNodeSelector(tree,
        //        new TestBTNodeEatApple(this),
        //        new TestBTNodeEatBanana(this),
        //        new TestBTNodeEatOrange(this)
        //        )
        //);
        //root.AddNode(drink);
        //root.AddNode(eat);
        var root = new BTNodeParallel(tree,
            new TestBTNodeEatApple(this),
            new TestBTNodeEatBanana(this),
            new TestBTNodeEatOrange(this));
        tree.root = root;
    }

    // Update is called once per frame
    void Update()
    {
        if (updateBtn)
        {
            updateBtn = false;
        }

        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer -= 1;
            tree.Tick(Time.deltaTime);
        }
    }
}
