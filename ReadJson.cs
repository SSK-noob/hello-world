using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ReadJson : MonoBehaviour
{
    //Json全体のデータを格納するオブジェクト
    JObject notes = new JObject();
    public string _FilePath;

    //ノーツの各情報
    public float[] _Timing;//ノーツの到達時間
    public int[] _Lane;//レーン(block)
    public int[] _Notetype;//Tap or Long(type)
    public int[] _Num;//ノーツの場所(num)
    public int[] _LongnoteNum;//ロングノーツ終端の位置(num)

    private float BPM;
    private int LPB;
    public void ReadAndMakeNotesInfomation(string _FilePath)
    {
        //Jsonファイルを読み込む
        using(StreamReader reader = File.OpenText(_FilePath))
        {
            //notesオブジェクトにjsonファイルの中身を代入?
            notes = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
        }

        _Timing = new float[1024];
        _Lane = new int[1024];
        _Notetype = new int[1024];
        _Num = new int[1024];
        _LongnoteNum = new int[1024];

        BPM = (float)notes["BPM"];

        //配列,変数に各ノーツの情報を記録
        JArray Notes = (JArray)notes["notes"];//ノーマルノーツ
        LPB = (int)(JValue)Notes[0]["LPB"];

        int i = 0;
        int j = 0;

        foreach (JObject fumenobj in Notes)
        {
            _Num[i] = (int)(JValue)fumenobj["num"];//場所(何拍目か)
            _Lane[i] = (int)(JValue)fumenobj["block"];//レーン
            _Notetype[i] = (int)(JValue)fumenobj["type"];//ノーツ種類
            _Timing[i] = (60 / BPM) * _Num[i] / 4;

            if(_Timing[i] == 0)
            {
                _Timing[i] += 0.001f;
            }

            if(_Notetype[i] == 2)
            {
                JArray longnotes = (JArray)fumenobj["notes"];//ロングノーツの終端情報を取得
                _LongnoteNum[j] = (int)(JValue)longnotes[0]["num"];
                j++;
            }
            i++;
        }
    }
}
