using UnityEngine;
using System.Collections;

public class MonsterSight : MonoBehaviour {

    public delegate void onFirstTimeSeenDelegate();

    private float range;
    private bool seenEnemy;
    private Transform monster;
    private Transform target;
    private Animator animator;
    private onFirstTimeSeenDelegate onFirstTimeSeen;

    // Use this for initialization
    public void init(float range, Transform monster, Transform target, Animator animator, onFirstTimeSeenDelegate _onFirstTimeSeen)
    {
        this.range = range;
        this.monster = monster;
        this.target = target;
        this.animator = animator;
        this.onFirstTimeSeen = _onFirstTimeSeen;
        seenEnemy = false;
    }

    public bool isEnemyInSight()
    {
        var hit = Physics2D.Linecast(monster.position, target.position);
        if (hit && hit.distance < range)
        {
            Debug.DrawLine(monster.position, hit.point);
            Debug.Log("distance to player: " + hit.distance);

            // on first time seeing enemy
            if (!seenEnemy)
            {
                onInitialEnemyFound();
            }
            seenEnemy = true;
        }
        else
        {
            seenEnemy = false;
        }
        return seenEnemy;
    }


    public void onInitialEnemyFound()
    {
        // run delegate from MonsterWander
        onFirstTimeSeen();

        createDiscoverStatus();

    }

    public void createDiscoverStatus()
    {
        Vector3 statusPos = monster.transform.position;
        statusPos.y += 1;
        var status = Instantiate(Resources.Load("StatusIcons/exclamation_mark"), statusPos, Quaternion.identity) as GameObject;
        status.transform.parent = monster;
        Destroy(status, 2);
    }

    public bool hasRecentlySeenEnemy()
    {
        return seenEnemy;
    }
}
