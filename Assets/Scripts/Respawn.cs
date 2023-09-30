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

    // �������
    private void OnTriggerEnter(Collider other)
    {
        // �����׹�䵽FallZone
        if (other.tag == "death")
        {
            transform.position = startPosition;
            transform.rotation = startRotation;

            // ����ʱ����ʧ�ܵĶ���
            GetComponent<Animator>().Play("LOSE00", -1, 0f);
            // ����ʱ�����ƶ�
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
        // ����Ǹ����
        else if (other.tag == "check")
        {
            startPosition = other.transform.position;
            startRotation = other.transform.rotation;
            Destroy(other.gameObject);
        }
        // ������յ�
        else if (other.tag == "final")
        {
            Destroy(other.gameObject);
            GetComponent<Animator>().Play("WIN00", -1, 0f);
        }
    }
}
