using UnityEngine;
using System.Collections;

public class MonsterSight : MonoBehaviour {

    private float range;
    private bool seenEnemy;
    private Transform monster;
    private Transform target;

    public MonsterSight(float range, Transform monster, Transform target)
    {
        this.range = range;
        this.monster = monster;
        this.target = target;
        seenEnemy = false;
    }

    public bool isEnemyInSight()
    {
        var hit = Physics2D.Linecast(monster.position, target.position);
        if (hit && hit.distance < range)
        {
            Debug.DrawLine(monster.position, hit.point);
            Debug.Log("distance to player: " + hit.distance);

            if (!seenEnemy)
            {
                enemyFound();
            }
            seenEnemy = true;
        }
        else
        {
            seenEnemy = false;
        }
        return seenEnemy;
    }

    public void enemyFound()
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
