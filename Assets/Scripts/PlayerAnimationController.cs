using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator m_Animator;
    public Rigidbody m_Chan;

    private float inputH;
    private float inputV;
    private bool run;

    // Start is called before the first frame update
    void Start()
    {
        // ��ȡ����������
        m_Animator = GetComponent<Animator>();
        run = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            m_Animator.Play("WAIT01", -1, 0f);
        }
        else if (Input.GetKeyDown("2"))
        {
            m_Animator.Play("WAIT02", -1, 0f);
        }
        else if (Input.GetKeyDown("3"))
        {
            m_Animator.Play("WAIT03", -1, 0f);
        }
        else if (Input.GetKeyDown("4"))
        {
            m_Animator.Play("WAIT04", -1, 0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            int type = Random.Range(0, 2);
            m_Animator.Play("DAMAGED0" + type, -1, 0f);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        } 
        else
        {
            run = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            m_Animator.SetBool("jump", true);
        }
        else
        {
            m_Animator.SetBool("jump", false);
        }

        // ����ǰ�������ƶ�������
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        // ����������ƶ���
        m_Animator.SetFloat("inputH", inputH);
        m_Animator.SetFloat("inputV", inputV);
        m_Animator.SetBool("run", run);

        // ���ƽ�ɫ�ƶ�
        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;
        if (moveZ <= 0)
        {
            // ���û����ǰ�ߣ���ô���������ƶ�
            moveX = 0;
        }
        else
        {
            if (run)
            {
                moveX *= 3f;
                moveZ *= 3f;
            }
        }
        m_Chan.velocity = new Vector3(moveX, 0f, moveZ);
    }
}
