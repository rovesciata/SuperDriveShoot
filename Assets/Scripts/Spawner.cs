using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ボールを入れる変数
    public GameObject ball;

    // Use this for initialization
    IEnumerator Start()
    {
        while (true)
            {
                // ボール生成
                Instantiate(ball, transform.position, transform.rotation);
                yield return new WaitForSeconds(5f);
            }
        }
}
