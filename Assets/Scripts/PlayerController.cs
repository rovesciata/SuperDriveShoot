using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // スワイプ用方向
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    [SerializeField]
    float throwForceInX = 1f;
    [SerializeField]
    float throwForceInZ = 1f;
    Rigidbody rb;
    AudioClip getBallSound;
    AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        getBallSound = Resources.Load<AudioClip>("Audio/ball_hit_solid_rnd_01");
        audioSource = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPos = Input.GetTouch(0).position;
            touchTimeStart = Time.time;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endPos = Input.GetTouch(0).position;
            touchTimeFinish = Time.time;
            // calculate swipe time interval
            timeInterval = touchTimeFinish - touchTimeStart;
            direction = startPos - endPos;
            rb.isKinematic = false;
            // ドライブシュート
            rb.AddForce(-direction.x * throwForceInX, 2000f, -direction.y * throwForceInZ, ForceMode.Impulse);
            // ライジングショット
            //rb.AddForce(-direction.x * throwForceInX, -10f, -direction.y * throwForceInZ, ForceMode.Impulse);
            // バナナシュート
            //rb.AddForce(-direction.x * 500f, 1000f, -direction.y * throwForceInZ, ForceMode.Impulse);
            audioSource.PlayOneShot(getBallSound);
            Invoke("FallBall", 0.3f);
            Invoke("ResetGravity", 1f);
            //Invoke("Instantiate", 3f);
        }
    }
    void FallBall()
    {
        //rb.AddForce(-direction.x * throwForceInX, -2000f, -direction.y * throwForceInZ, ForceMode.Impulse);
        // ドライブシュート
        Physics.gravity = new Vector3(0f, -700f, 0f);
        // ライジングショット
        //Physics.gravity = new Vector3(0f, 600f, 0f);
        // バナナシュート
        //rb.AddForce(-direction.x * -1400f, 0f, -direction.y * throwForceInZ, ForceMode.Impulse);
    }
    void ResetGravity()
    {
        Physics.gravity = new Vector3(0f, -20f, 0f);
    }



}
