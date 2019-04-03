using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
        public bool getDestroy = false;
        public float timer = 1f;
        // ボールと接触したらボールを消す
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Ball")
            {
                Destroy(other.gameObject, timer);
                getDestroy = true;
            }
        }
}
