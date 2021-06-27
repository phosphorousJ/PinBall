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

            if (touch.position.x < Screen.width / 2 && touch.phase == TouchPhase.Began && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            else if(touch.position.x < Screen.width / 2 && touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }

            if (touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Began && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            else if (touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
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
}
