using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exercise5 : MonoBehaviour
{
    public float minX =-4f;
    public float maxX = 4f;

    public float minY = -1f;
    public float maxY = 2f;

    public float minZ =-3f;
    public float maxZ = 3f;

    public bool gameOver;

    public Material mat;

    public int points=0;

    public bool hasBeenClick;


    private void Start()
    {
        points = 0;
        hasBeenClick = false; 
        StartCoroutine("GenerateNextRandomPos");
        mat = GetComponent<MeshRenderer>().material;
    }
    public Vector3 GenerateRandomPos()
    {
        Vector3 pos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        return pos;
    }
    public IEnumerator GenerateNextRandomPos()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(2);
            transform.position = GenerateRandomPos();
            mat.color = Color.blue;
            hasBeenClick = false;
        }
    }
    private void OnMouseDown()
    {
        if (!hasBeenClick)
        {
            mat.color = Color.green;
            points++;
            hasBeenClick = true;
        }
        
    }


}
