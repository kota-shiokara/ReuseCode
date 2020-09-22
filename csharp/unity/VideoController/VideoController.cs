using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rayを視点からマウスの位置に飛ばす
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(myRay, out hit, Mathf.Infinity))
        {
            //Rayに当たったgameobjectを参照
            var obj = hit.collider.gameObject;
            Debug.Log(obj.name);

            //movieタグを持っていればロードか動画の再生一時停止処理
            if(obj.tag == "movie" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(obj.GetComponent<VideoLoader>().loaded)
                {
                    var vp = obj.GetComponent<VideoPlayer>();
                    if(vp.isPlaying) vp.Pause();
                    else vp.Play();
                }
                else obj.GetComponent<VideoLoader>().loadkey = true;
            }
        }
    }
}
