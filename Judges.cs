using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judges : MonoBehaviour
{
    public void Delay()
    {
        Invoke("Destroy",1f);
    }

    void Destroy()
    {

    }
}
