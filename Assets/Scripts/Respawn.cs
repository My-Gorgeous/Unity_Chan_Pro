using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // 触发检测
    private void OnTriggerEnter(Collider other)
    {
        // 如果是坠落到FallZone
        if (other.tag == "death")
        {
            transform.position = startPosition;
            transform.rotation = startRotation;

            // 复活时播放失败的动画
            GetComponent<Animator>().Play("LOSE00", -1, 0f);
            // 复活时不可移动
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
        // 如果是复活点
        else if (other.tag == "check")
        {
            startPosition = other.transform.position;
            startRotation = other.transform.rotation;
            Destroy(other.gameObject);
        }
        // 如果是终点
        else if (other.tag == "final")
        {
            Destroy(other.gameObject);
            GetComponent<Animator>().Play("WIN00", -1, 0f);
        }
    }
}
