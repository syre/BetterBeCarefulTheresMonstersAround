using UnityEngine;
using System.Collections.Generic;

public class DesertLevelGeneration : MonoBehaviour {

     // List<GameObject> prefabList = new List<GameObject>();
    public Transform[] prefabs = new Transform[10];
    public int numberOfObjects;
    public Vector3 startPosition;
    public float recycleOffset;
    public int prefabLimit;
    public Transform initialPrefab;

    private Vector3 nextPosition;
    private float playerPosition;
    private int insertedPrefabs;

    // Use this for initialization
    void Start () {
        insertedPrefabs = 0;


        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        nextPosition = startPosition;

        for (int i = 0; i < numberOfObjects; i++)
        {
            InsertPrefab();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InsertPrefab()
    {
        int prefabIndex = UnityEngine.Random.Range(0, prefabs.Length);
        Transform o = (Transform)Instantiate(prefabs[prefabIndex]);
        o.localPosition = nextPosition;
        nextPosition.y = transform.localPosition.y;
        nextPosition.x += 4.46f;
        initialPrefab = o;
    }
}