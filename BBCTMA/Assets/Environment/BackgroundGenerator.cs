using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundGenerator : MonoBehaviour {


    public Transform prefab;
    public int numberOfObjects;
    public Vector3 startPosition;
    public float recycleOffset;

    private Vector3 nextPosition;
    private float playerPosition;
    //private Queue<Transform> objectQueue;
    //private Transform newestBackground;

    public GameObject player;

    public Vector3 minSize, maxSize;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = new Vector3(player.transform.localPosition.x-20, player.transform.localPosition.y, transform.localPosition.z);
        // objectQueue = new Queue<Transform>(numberOfObjects);
        nextPosition = startPosition;
        for (int i = 0; i < numberOfObjects; i++)
        {
            CreateBackground();
        }
    }
    
	// Update is called once per frame
	void Update () {
        playerPosition = player.transform.localPosition.x;

        //if (objectQueue.Peek().localPosition.x + recycleOffset < playerPosition)
        if (playerPosition+recycleOffset > nextPosition.x)
       {
            CreateBackground();
       }
    }

    private void CreateBackground()
    {
        
        //Vector3 position = nextPosition;
        //position.x += scale.x * 0.5f;
        //position.y += scale.y * 0.5f;

        Transform o = (Transform)Instantiate(prefab);

        //Transform o = objectQueue.Dequeue();
        o.localScale = new Vector3(
            Random.Range(minSize.x, maxSize.x),
            Random.Range(minSize.y, maxSize.y),
            o.localScale.z);
        o.localPosition = nextPosition;
        //nextPosition.y = transform.localPosition.y;
        nextPosition.x += o.localScale.x / 3;
        //objectQueue.Enqueue(o);
    }
}
