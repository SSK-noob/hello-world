using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBeam : MonoBehaviour
{
    public GameObject keybeamPrefab;
    private string[] keys = new string[5] { "D", "F", "Space", "J", "K" };
    private float[] X = new float[5] { -3f, -1.4f, 0.2f, 1.8f,3.3f };

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DisplayKeyBeam(0);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            DisplayKeyBeam(1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayKeyBeam(2);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            DisplayKeyBeam(3);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            DisplayKeyBeam(4);
        }
    }

    void DisplayKeyBeam(int num)
    {
        GameObject g = Instantiate(keybeamPrefab, new Vector3(X[num], -3.2f, 0), Quaternion.identity);
        Destroy(g.gameObject, 0.1f);
    }
}
