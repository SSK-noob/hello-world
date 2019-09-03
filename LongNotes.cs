using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNotes : MonoBehaviour
{
    private GameController gc = null;
    // Start is called before the first frame update
    void Start()
    {
        gc = gameObject.AddComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(1.5f, 0.8f * gc.Length, 1f);
        this.transform.position += Vector3.down * 10 * Time.deltaTime;
        if (this.transform.position.y < -8.2f)
        {
            Debug.Log("POOR");
            Destroy(this.gameObject);
        }
    }
}
