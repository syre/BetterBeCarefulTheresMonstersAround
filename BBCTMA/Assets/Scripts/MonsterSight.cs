using UnityEngine;
using System.Collections;
/// <summary>
/// Monster sight.
/// Right now needs "Ignore raycast" layer on enemy to work
/// </summary>
public class MonsterSight : MonoBehaviour {
    
    public bool seenEnemy = false;
    public float range = 3f;
    public Vector2 resetPosition = new Vector2(10f, 10f);
    public Vector2 lastSighting;

    private GameObject player;
    private Animator monsterAnimator;
    private Animator playerAnimator;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        monsterAnimator = gameObject.GetComponent<Animator>();
        playerAnimator = player.GetComponent<Animator>();
        lastSighting = resetPosition;
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            seenEnemy = false;
            // get direction by subtraction player position from monster position
            var playerDirection = (player.transform.position - transform.position).normalized;
            var hit = Physics2D.Raycast(transform.position, playerDirection);
            Debug.DrawLine(transform.position, hit.point);
            if (hit.collider.gameObject == player)
            {
                seenEnemy = true;
                lastSighting = player.transform.position;
            }
        }
        
    }
    public void onInitialEnemyFound()
    {
        createDiscoverStatus();
    }

    public void createDiscoverStatus()
    {
        Vector2 statusPos = gameObject.transform.position;
        statusPos.y += 1;
        var status = Instantiate(Resources.Load("StatusIcons/exclamation_mark"), statusPos, Quaternion.identity) as GameObject;
        status.transform.parent = gameObject.transform;
        Destroy(status, 2);
    }
}
