using System;
using System.Collections;
using System.Collections.Generic;
using Kernel.Core;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestBehaviorTree2 : MonoBehaviour
{
    public BehaviorTree tree;
    public TestBehaviorTreeActor player;
    public TestBehaviorTreeActor enemyPrefab;
    private List<TestBehaviorTreeActor> enemies = new List<TestBehaviorTreeActor>();

    public static float WORLD_SIZE = 10;

    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count < 5)
        {
            var newEnemy = Instantiate(enemyPrefab, transform);
            newEnemy.transform.position = new Vector3(Random.Range(-WORLD_SIZE, WORLD_SIZE), 
               0, Random.Range(-WORLD_SIZE, WORLD_SIZE));
            newEnemy.gameObject.SetActive(true);
            enemies.Add(newEnemy);
        }
    }

    public TestBehaviorTreeActor SearchTarget(Vector3 pos, float raduis)
    {
        float dict = Single.MaxValue;
        TestBehaviorTreeActor rt = null;
        foreach (var actor in enemies)
        {
            var d = Vector3.Distance(pos, actor.transform.position);
            if (d < dict && d <= raduis)
            {
                dict = d;
                rt = actor;
            }
        }

        return rt;
    }

    public void OnEnemyDead(TestBehaviorTreeActor actor)
    {
        enemies.Remove(actor);
    }
}
