using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClickObject3D : MonoBehaviour
{
    GameObject clickedGameObject;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedGameObject = null;

            //Rayを視点からマウスの位置に飛ばす
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(myRay, out hit, Mathf.Infinity))
            {
                //Rayに当たったgameobjectを参照
                clickedGameObject = hit.collider.gameObject;
            }
            if(clickedGameObject != null)
            {

            }
            Debug.Log(clickedGameObject.name);
        }
    }
}
