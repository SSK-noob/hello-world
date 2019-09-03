using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    private CanvasController canvasController = null;
    public int LaneNum;

    void Start()
    {
        canvasController = gameObject.AddComponent<CanvasController>();
    }
    void Update()
    {
        this.transform.position += Vector3.down * 10 * Time.deltaTime;
        if(this.transform.position.y < -5.0f)
        {
            Debug.Log("POOR");
            //canvasController.DisplayPoor();
            Destroy(this.gameObject);
        }
    }
}
