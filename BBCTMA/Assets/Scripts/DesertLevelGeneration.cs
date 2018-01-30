using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DesertLevelGeneration : MonoBehaviour {
    
    public string resourcePath = "Levels/DesertTest";
    public int prefabLimit;
    public Transform RememberToPlaceThisObjectCorrectly;
    public GameObject finalPrefab;

    private Vector3 nextPosition;
    private int insertedPrefabs = 0;
    private int numberOfObjects;
    private Vector3 startPosition;
    private GameObject[] prefabs;

    // Use this for initialization
    void Start () {
        // load prefabs from Resource folder
        prefabs = Resources.LoadAll<GameObject>(resourcePath);

        numberOfObjects = prefabs.Length;
        // get start position
        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        nextPosition = startPosition;

        for (int i = 0; i < prefabLimit; i++)
        {
            InsertPrefab();
        }

        if (finalPrefab != null)
        {
            FinalPrefab();
        }
        // MISSING HERE: INSERT FINAL REFAB, that ends the level/room
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InsertPrefab()
    {
        // randomize a prefab from array
        int prefabIndex = Random.Range(0, prefabs.Length);
        GameObject g = Instantiate(prefabs[prefabIndex]);
        // Set position of generated prefab
        g.transform.localPosition = nextPosition;
                        //nextPosition.y = transform.localPosition.y;
        // get next position by adding the length of the "current"
        nextPosition.x += g.GetComponent<Collider2D>().bounds.size.x;
    }

    public void FinalPrefab()
    {
        GameObject g = Instantiate(finalPrefab);
        g.transform.localPosition = nextPosition;
    }
}