using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CanvasController : MonoBehaviour
{
    public GameObject JudgeString;
    public GameObject canvas;

    public void DisplayPoor()
    {
        GameObject Poor = Instantiate(JudgeString,new Vector3(0,0,0),Quaternion.identity);
        Poor.transform.SetParent(canvas.transform, false);
        Destroy(this.gameObject);
    }
}
