using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] DynamicJoystick joy;
  public float speed;

  [SerializeField] Rigidbody rigid;
  [SerializeField] Animator anim;
  Vector3 moveVec;

  void FixedUpdate()
  {
    //Input value
    float x = joy.Horizontal;
    float z = joy.Vertical;

    //Move Position
    moveVec = new Vector3(x, 0, z) * speed * Time.fixedDeltaTime;
    rigid.MovePosition(rigid.position + moveVec);
    if (moveVec.sqrMagnitude == 0) return;

    //move Rotation
    Quaternion dirQuat = Quaternion.LookRotation(moveVec);
    Quaternion moveQuat = Quaternion.Slerp(rigid.rotation, dirQuat, 0.3f);
    rigid.MoveRotation(moveQuat);
  }

  void LateUpdate()
  {
    anim.SetFloat("Move", moveVec.sqrMagnitude);
  }
}
