using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Musiclist Musiclist = new Musiclist();
    CanvasController canvasController = null;
    ReadJson readJson = null;

    public GameObject[] notes;
    public GameObject[] longnotes;
    public GameObject[] Poor;

    private GameObject Music;//楽曲をまとめたオブジェクト
    private Transform NowMusic;//選択された楽曲のオブジェクト
    private AudioSource audioSource;//曲の再生などを行う
    public string MusicName;//選曲画面から選択された楽曲の名前を取得（予定）
    public AudioClip[] MusicList;//楽曲リスト

    private float StartMusicTime = 0;
    private int NotesCount = 0;
    private int LongNotesCount = 0;
    private bool Playing = false;
    private float[] NotesXposition = new float[5] {-2.98f,-1.4f,0.175f,1.75f,3.34f};

    public float offset = 0f;
    public string[] FilePath;
    public int Length;
    
    void Start()
    {
        canvasController = gameObject.AddComponent<CanvasController>();
        readJson = gameObject.AddComponent<ReadJson>();
        readJson.ReadAndMakeNotesInfomation(FilePath[1]);
        StartFumen();
        Invoke("PlayMusic", 6f);//5秒後に曲再生
    }

    void Update()
    {
        if (Playing)
        {
            CheckNextNotes();
        }
    }

    //選択された楽曲のAudioClipを返す
    private AudioClip PlayMusicAudio(string name)
    {
        foreach (AudioClip audio in MusicList)
        {
            if (audio.name == name)
            {
                return audio;
            }
        }
        return MusicList[0];//見つからなかった場合は先頭のAudioClipを返す
    }

    void PlayMusic()
    {
        Music = GameObject.Find("Musics");
        NowMusic = Music.transform.Find(MusicName);//親オブジェクトから子オブジェクトを取得(MusicString)
        audioSource = NowMusic.GetComponent<AudioSource>();
        audioSource.PlayOneShot(PlayMusicAudio(MusicName));
        StartMusicTime = Time.time;
    }

    //ノーツの生成
    void CheckNextNotes()
    {
        while(readJson._Timing[NotesCount] < GetMusicTime() && readJson._Timing[NotesCount] != 0)
        {
            if(readJson._Notetype[NotesCount] == 1)
            {
                SpawnNotes(readJson._Lane[NotesCount]);
                NotesCount++;
            }
            else if(readJson._Notetype[NotesCount] == 2)
            {
                SpawnLongNotes(readJson._Lane[NotesCount]);
                NotesCount++;
                LongNotesCount++;
            }
        }
    }

    void SpawnNotes(int lane)
    {
        Instantiate(notes[lane],new Vector3(NotesXposition[lane],10.0f,0),Quaternion.identity);
    }

    void SpawnLongNotes(int lane)
    {
        Length = readJson._LongnoteNum[LongNotesCount] - readJson._Num[NotesCount];
        Instantiate(longnotes[lane],new Vector3(NotesXposition[lane],10.0f,0),Quaternion.identity);
    }

    float GetMusicTime()
    {
        return Time.time - 5f;
    }

    void StartFumen()
    {
        Playing = true;
    }
}
