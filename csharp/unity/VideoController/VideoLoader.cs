using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
    [SerializeField]
    private string relativePath;

    //loadの操作
    public bool loaded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }

    //StreamingAssetsフォルダから動画のロードをするスクリプト
    public void LoadSequence()
    {
        loaded = true;
        VideoPlayer player = GetComponent<VideoPlayer>();
        player.source = VideoSource.Url;
        player.url = Application.streamingAssetsPath + "/" + relativePath;
        player.prepareCompleted += PrepareCompleted;
        player.Prepare();
    }

    void PrepareCompleted(VideoPlayer vp)
    {
        vp.prepareCompleted -= PrepareCompleted;
        vp.Play();
    }

}
