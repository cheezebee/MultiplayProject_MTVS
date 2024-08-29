using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerStateBase
{
    Transform cam;
    CharacterController cc;
    Animator myAnim;

    float mx = 0;

    void Start()
    {
        cam = Camera.main.transform;
        cc = GetComponent<CharacterController>();
        myAnim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        // ���� ī�޶� �ٶ󺸴� �������� �̵��� �ϰ� �ʹ�.
        // �̵��� ���� ����� W,A,S,D Ű�� �̿��Ѵ�.
        // ĳ���� ��Ʈ�ѷ� Ŭ������ Move �Լ��� �̿��Ѵ�.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        dir = transform.TransformDirection(dir);
        cc.Move(dir * moveSpeed * Time.deltaTime);

        if(myAnim != null)
        {
            myAnim.SetFloat("Horizontal", h);
            myAnim.SetFloat("Vertical", v);
        }
    }

    void Rotate()
    {
        // ������� ���콺 �¿� �巡�� �Է��� �޴´�.
        mx += Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;

        // �Է¹��� ���⿡ ���� �÷��̾ �¿�� ȸ���Ѵ�.
        transform.eulerAngles = new Vector3(0, mx, 0);

    }
}