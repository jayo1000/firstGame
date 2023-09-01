using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float offset_y;
    // Start is called before the first frame update

    public Transform bg1;

    public Transform bg2;

    private float size;

    void Start() {
        size = bg1.GetComponent<TilemapRenderer>().bounds.size.y;
    }

    private void FixedUpdate() {
        // Follow Player
        Vector3 targetPos = new Vector3(transform.position.x, target.position.y + offset_y, transform.position.z);
        transform.position = targetPos;

        // background
        if(transform.position.y >= bg2.position.y) {
            bg1.position = new Vector3(bg1.position.x, bg2.position.y + size, bg1.position.z);
            SwitchBg();
        }
    }

    private void SwitchBg() {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }
}
