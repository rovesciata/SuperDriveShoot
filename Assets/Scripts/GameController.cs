using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
        public GameObject ball;
        public GameObject ground;
        public GameObject goal;
        // ボールの配列
        GameObject[] balls;
        // goalScriptクラスのスクリプトを定義
        GoalScript goalScript;
        Transform ballPos;
        // Use this for initialization
        void Start()
        {
            //ballPos.position = new Vector3(0f, 0.45f, 0f);
            goalScript = goal.GetComponent<GoalScript>();
            Instantiate(ball, new Vector3(0f, 0.45f, -10f), Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {
            // goalScriptがgetDestoryならGenerateBall関数を呼び出す
            if (goalScript.getDestroy == true)
            {
                StartCoroutine("GenerateBall");
                goalScript.getDestroy = false;
            }
        }
        // Ballを再生する関数
        IEnumerator GenerateBall()
        {
            yield return new WaitForSeconds(1f);
            Instantiate(ball, new Vector3(0f, 0.45f, -10f), Quaternion.identity);
        }
}
