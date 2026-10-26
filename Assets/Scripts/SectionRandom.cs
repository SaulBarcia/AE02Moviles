using UnityEngine;
using System.Collections.Generic;
public class SectionRandom : MonoBehaviour
{
    public List<GameObject> obstaculos = new List<GameObject>();
    public float speed = 1.0f;
    private int sectionsCount = 0;
    public float sectionSize = 50f;
    private static int lastRndIdx = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sectionsCount = GameObject.FindGameObjectsWithTag("Section").Length;
        foreach (Transform child in transform)
        {
            if(child.tag == "Obstacle")
            {
                obstaculos.Add(child.gameObject);
            }
        }
        EnableRandomObs();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if(transform.position.z <= -sectionSize)
        {
            transform.Translate(Vector3.forward * sectionSize * sectionsCount);
            EnableRandomObs();
        }
        
    }

    public void EnableRandomObs()
    {
        foreach (GameObject obstacle in obstaculos)
        {
            obstacle.SetActive(false);
        }
        int randomIdx = lastRndIdx;
        while (randomIdx == lastRndIdx)
        {
            randomIdx = Random.Range(0, obstaculos.Count);
        }
        lastRndIdx = randomIdx;
        obstaculos[randomIdx].SetActive(true);
    }
}
