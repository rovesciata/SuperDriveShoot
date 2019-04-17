using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // スワイプ用方向
    Vector2 startPos, endPos, direction;
    // スワイプしている長さ
    float touchTimeStart, touchTimeFinish, timeInterval;

    [SerializeField]
    // x軸方向のスワイプの強さ
    float throwForceInX = 1f;
    [SerializeField]
    // z軸方向のスワイプの強さ
    float throwForceInZ = 1f;
    // Rididbodyを入れる変数
    Rigidbody rb;
    // ボールを蹴る音を入れる変数
    AudioClip getBallSound;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        // Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        // ボールを蹴る音を取得
        getBallSound = Resources.Load<AudioClip>("Audio/ball_hit_solid_rnd_01");
        audioSource = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // タッチ開始時
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // タッチ開始時の位置を取得
            startPos = Input.GetTouch(0).position;
            // タッチ開始時の時間を取得
            touchTimeStart = Time.time;
        }
        // 指を離した時
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            // 指を離した時の位置を取得
            endPos = Input.GetTouch(0).position;
            // 指を離した時の時間を取得
            touchTimeFinish = Time.time;
            // 指を離した時からタッチ開始時の時間差を取得
            timeInterval = touchTimeFinish - touchTimeStart;
            // スワイプの方向を取得
            direction = startPos - endPos;
            // 物理演算の影響を無効
            rb.isKinematic = false;

            // ドライブシュート
            rb.AddForce(-direction.x * throwForceInX, 2000f, -direction.y * throwForceInZ, ForceMode.Impulse);
            // ライジングショット
            //rb.AddForce(-direction.x * throwForceInX, -10f, -direction.y * throwForceInZ, ForceMode.Impulse);
            // バナナシュート
            //rb.AddForce(-direction.x * 500f, 1000f, -direction.y * throwForceInZ, ForceMode.Impulse);

            // ボールを蹴る音を鳴らす
            audioSource.PlayOneShot(getBallSound);
            // ボールを0.3秒後に落とす
            Invoke("FallBall", 0.3f);
            // ボールの重力をを1秒後に戻す
            Invoke("ResetGravity", 1f);
        }
    }

    // ボールを落とす
    void FallBall()
    {
        // ドライブシュート(ボールに重力をかける)
        Physics.gravity = new Vector3(0f, -700f, 0f);
        // ライジングショット
        //Physics.gravity = new Vector3(0f, 600f, 0f);
        // バナナシュート
        //rb.AddForce(-direction.x * -1400f, 0f, -direction.y * throwForceInZ, ForceMode.Impulse);
    }

    // ボールの重力を戻す
    void ResetGravity()
    {
        Physics.gravity = new Vector3(0f, -20f, 0f);
    }
}
