using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMove : MonoBehaviour
{
    //移動量
    [SerializeField, Range(0.1f, 10.0f)]
    private float speed = 2.0f;

    //マウス感度
    [SerializeField, Range(30.0f, 150.0f)]
    private float _mouseSensitive = 90.0f;

    //shiftキーでの速度上昇値
    [SerializeField, Range(1.0f, 2.0f)]
    private float _shiftkey = 1.5f;

    //移動できるエリアの大きさ(原点を中心とした正方形)
    [SerializeField, Range(0.0f, 125.0f)]
    private float _moveArea = 100.0f;

    //カメラ操作の有効無効
    private bool _cameraMoveActive = true;
    //カメラのtransform  
    private Transform _camTransform;

    //マウスの始点 
    private Vector3 _startMousePos;
    //カメラ回転の始点情報
    private Vector3 _presentCamRotation;

    //初期状態 Rotation
    private Quaternion _initialCamRotation;
    //UIメッセージの表示
    private bool _uiMessageActiv;

    void Start ()
    {
        _camTransform = this.gameObject.transform;

        //初期回転の保存
        _initialCamRotation = this.gameObject.transform.rotation;
    }

    void Update () {
        #if UNITY_EDITOR
        CamControlIsActive(); //カメラ操作の有効無効
        #endif

        if (_cameraMoveActive)
        {
            var angleDir = _camTransform.eulerAngles.y * (Mathf.PI / 180.0f);
            var dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
            var dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));

            CameraRotationMouseControl();
            PlayerKeyMove(dir1, dir2);
        }
    }

    private void CameraRotationMouseControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startMousePos = Input.mousePosition;
            _presentCamRotation.x = _camTransform.transform.eulerAngles.x;
            _presentCamRotation.y = _camTransform.transform.eulerAngles.y;
        }

        if (Input.GetMouseButton(0))
        {
            //(移動開始座標 - マウスの現在座標) / 解像度 で正規化
            float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

            //回転開始角度 ＋ マウスの変化量 * マウス感度
            float eulerX = _presentCamRotation.x + y * _mouseSensitive;
            float eulerY = _presentCamRotation.y - x * _mouseSensitive;

            _camTransform.rotation = Quaternion.Euler(eulerX, eulerY, 0);
        }
    }

    public void PlayerKeyMove(Vector3 dir1, Vector3 dir2)
    {
        var shiftkey = 1.0f;
        if (Input.GetKey(KeyCode.LeftShift)) shiftkey = _shiftkey;
        if (Input.GetKey(KeyCode.W)) _camTransform.position += dir1 * speed * Time.deltaTime * shiftkey;
        if (Input.GetKey(KeyCode.A)) _camTransform.position += dir2 * speed * Time.deltaTime * shiftkey;
        if (Input.GetKey(KeyCode.D)) _camTransform.position += -dir2 * speed * Time.deltaTime * shiftkey;
        if (Input.GetKey(KeyCode.S)) _camTransform.position += -dir1 * speed * Time.deltaTime * shiftkey;

        //移動エリアを限定
        var pos = _camTransform.position;
        if(pos.x >= _moveArea) pos.x = _moveArea;
        if(pos.x <= -_moveArea) pos.x = -_moveArea;
        if(pos.z >= _moveArea) pos.z = _moveArea;
        if(pos.z <= -_moveArea) pos.z = -_moveArea;
        _camTransform.position = pos;
    }

    //カメラ操作の有効無効
    public void CamControlIsActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _cameraMoveActive = !_cameraMoveActive;

            if (_uiMessageActiv == false)
            {
                StartCoroutine(DisplayUiMessage());
            }            
            Debug.Log("CamControl : " + _cameraMoveActive);
        }
    }

    //UIメッセージの表示
    private IEnumerator DisplayUiMessage()
    {
        _uiMessageActiv = true;
        float time = 0;
        while (time < 2)
        {
            time = time + Time.deltaTime;
            yield return null;
        }
        _uiMessageActiv = false;
    }

    void OnGUI()
    {
        if (_uiMessageActiv == false) { return; }
        GUI.color = Color.black;
        if (_cameraMoveActive == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 30, 100, 20), "カメラ操作 有効");
        }

        if (_cameraMoveActive == false)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 30, 100, 20), "カメラ操作 無効");
        }
    }
}