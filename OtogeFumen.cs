using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class OtogeFumen //他のスクリプトから参照されるのでMono...は消す
{
    //変数名はjsonファイル内と同じにしなければならない
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
  
    public struct notes
    {
        public int[] LPB;
        public int[] num;
        public int[] block;
        public int[] type;
    }
}
