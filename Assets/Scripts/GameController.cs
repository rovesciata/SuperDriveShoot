using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // ボールを入れる変数
    public GameObject ball;
    // グランドを入れる変数
    public GameObject ground;
    // ゴールを入れる変数
    public GameObject goal;
    // ボールの配列
    GameObject[] balls;
    // GoalScriptクラスのスクリプトを定義
    GoalScript goalScript;
    // ボールの位置を入れる変数
    Transform ballPos;

    // Use this for initialization
    void Start()
    { 
    // GoalScriptクラスを取得
    goalScript = goal.GetComponent<GoalScript>();
    // ボールを生成
    Instantiate(ball, new Vector3(0f, 0.45f, -10f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // goalScriptがgetDestoryならGenerateBall関数を呼び出す
        if (goalScript.getDestroy == true)
            {
            // ボールを再製
            StartCoroutine("GenerateBall");
            goalScript.getDestroy = false;
            }
        }
        // ボールを再製する関数
        IEnumerator GenerateBall()
        {
            yield return new WaitForSeconds(1f);
            Instantiate(ball, new Vector3(0f, 0.45f, -10f), Quaternion.identity);
        }
}
