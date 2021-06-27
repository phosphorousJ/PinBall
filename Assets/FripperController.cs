using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;

    //弾いた時の傾き
    private float flickAngle = -20;


    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touches.Length; i++)
        {
            Touch touch = Input.touches[i];

            if (touch.phase == TouchPhase.Began)
            {
                TouchBegan();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                TouchEnded();
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle (float angle) 
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

    void TouchBegan()
    {
        if ((Input.mousePosition.x < Screen.width / 2) && tag == "LeftFripperTag")      //画面の左をタップした時、左のフリッパーを動かす
        {
            SetAngle(this.flickAngle);
        }
        if ((Input.mousePosition.x > Screen.width / 2) && tag == "RightFripperTag")     //画面の右をタップした時、右のフリッパーを動かす
        {
            SetAngle(this.flickAngle);
        }
        if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began)         //画面の左右を同時にタップした時、左右同時にフリッパーを動かす
        {
            SetAngle(this.flickAngle);
        }
    }

    void TouchEnded()
    {
        if ((Input.mousePosition.x < Screen.width / 2) && tag == "LeftFripperTag")      //画面の左を離した時、左のフリッパーを元に戻す
        {
            SetAngle(this.defaultAngle);
        }
        if ((Input.mousePosition.x > Screen.width / 2) && tag == "RightFripperTag")     //画面の右を離した時、右のフリッパーを元に戻す
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Ended)        //画面の左右を同時に離した時、左右同時にフリッパーを元に戻す
        {
            SetAngle(this.defaultAngle);
        }
    }
}
