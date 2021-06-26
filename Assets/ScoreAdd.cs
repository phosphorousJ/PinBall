using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAdd : MonoBehaviour
{
    //得点を表示するテキスト
    private GameObject scoreText;

    //初期の得点
    private int score = 0;

    //SmallStarの得点
    private int SmallStarScore = 2;

    //LargeStarの得点
    private int LargeStarScore = 10;

    //SmallCloudの得点
    private int SmallCloudScore = 5;

    //LargeCloudの得点
    private int LargeCloudScore = 20;


    // Start is called before the first frame update
    void Start()
    {
        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }


    // Update is called once per frame
    void Update()
    {
        
        this.scoreText.GetComponent<Text>().text = score + "points";
    }


    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            this.score += SmallStarScore;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            this.score += LargeStarScore;
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            this.score += SmallCloudScore;
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            this.score += LargeCloudScore;
        }
    }
}
