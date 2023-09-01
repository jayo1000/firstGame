using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSecond : MonoBehaviour
{
    public Vector2 move_dir = Vector2.right;
    public float distance = 2.0f;
    public float move_time = 4.0f;

    public bool arrived = false; // 플랫폼이 이동을 완료 했을때 Flag가 True로 되는 변수입니다.

    public void Activate(float time)
    {
        StartCoroutine(movement((Vector2)transform.position + move_dir * distance, time));
    }

     public void Rotation(float time) {
        StartCoroutine(oneRotation(time));
    }

    IEnumerator oneRotation(float targetTime) {
        float target_angle = 360.0f;
        if (transform.position.x < 0) {
            target_angle = target_angle;
        }
        else {
            target_angle = target_angle*-1.0f;
        }

        float takenTime = 0.0f;
        Vector3 ori_angle = transform.eulerAngles;
        while (takenTime < targetTime) {
            transform.eulerAngles = Vector3.Lerp(ori_angle, Vector3.forward * target_angle, takenTime / targetTime);
            takenTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    IEnumerator movement(Vector2 targetPoint, float targetTime) {
        float agoTime = 0.0f;
        Vector2 firstPoint = transform.position;
        while (agoTime < targetTime)
        {
            Vector2 new_pos = Vector2.Lerp(firstPoint, targetPoint, agoTime / targetTime);
            transform.position = new_pos;
            agoTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }


        arrived = true;
    }
}