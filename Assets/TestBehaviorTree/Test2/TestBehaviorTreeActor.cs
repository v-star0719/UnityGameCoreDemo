using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehaviorTreeActor : MonoBehaviour
{
    public TestBehaviorTree2 test2;
    public bool isEnemy;
    public float viewField = 3;
    public float size = 1;
    public float speed = 1;
    public float speedUp = 1;
    public float attack = 1;
    public float hp = 10;
    public float cd = 1;
    public float attackDist = 0;
    public float roateSpeed = 180;

    public TestBehaviorTreeActor target;
    public bool isDead;
    public Vector3 randomPos;
    public bool isHit;


    private float confCd = 0;
    private TestBehaviorTreeAI ai;

    public float CurSpeed => speed * speedUp;
    public float CurRotateSpeed => roateSpeed * speedUp;

    // Start is called before the first frame update
    void Start()
    {
        confCd = cd;
        ai = new TestBehaviorTreeAI(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        ai.Tick(Time.deltaTime);
    }

    public bool IsInAttackRange()
    {
        return false;
    }

    public bool IsCollide(TestBehaviorTreeActor target)
    {
        var p1 = target.transform.position;
        var p2 = transform.position;
        var min = (target.size + size) * 0.5;
        if (Mathf.Abs(p1.x - p2.x) > min)
        {
            return false;
        }
        if(Mathf.Abs(p1.y - p2.y) > min)
        {
            return false;
        }
        if(Mathf.Abs(p1.z - p2.z) > min)
        {
            return false;
        }

        return true;
    }

    public bool IsArrivedAt(Vector3 pos)
    {
        var p = transform.position;
        var min =  size * 0.5;
        if(Mathf.Abs(p.x - pos.x) > min)
        {
            return false;
        }
        if(Mathf.Abs(p.y - pos.y) > min)
        {
            return false;
        }
        if(Mathf.Abs(p.z - pos.z) > min)
        {
            return false;
        }

        return true;
    }

    public void Attack(TestBehaviorTreeActor actor)
    {
        actor.Hit(attack);
        cd = confCd;
    }

    public void Hit(float damage)
    {
        isHit = true;
        hp -= damage;
        if (hp <= 0)
        {
            isDead = true;
            test2.OnEnemyDead(this);
            Destroy(gameObject);
        }
    }

    public void MoveTo(Vector3 pos, float deltaTime)
    {
        var dir = pos - transform.position;
        var delta = dir.normalized * CurSpeed * deltaTime;
        if(delta.sqrMagnitude > dir.sqrMagnitude)
        {
            delta = dir;
        }
        var q = Quaternion.LookRotation(dir, Vector3.up);
        var angle = Vector3.Angle(dir, transform.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, CurRotateSpeed * deltaTime / angle);

        transform.position += delta;
    }
}
