using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class ReadJson : MonoBehaviour
{
    OtogeFumen fumen2 = new OtogeFumen();
    OtogeFumen.notes notes = new OtogeFumen.notes();
    public string _FilePath;
    void Start()
    {
        OtogeFumen fumen = JsonConvert.DeserializeObject<OtogeFumen>(File.ReadAllText(_FilePath));
        Debug.Log(notes.x);
    }

    void Update()
    {
        
    }
}
