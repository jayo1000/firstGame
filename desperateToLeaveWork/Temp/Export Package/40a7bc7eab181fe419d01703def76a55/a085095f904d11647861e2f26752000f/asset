using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {
    public GameObject prefab_PlatformGroup;
    // 새로 추가된 부분 _ 생성할 코인!
    public GameObject prefab_Coin;

    Vector2 pos_WillCreatePlatformGroup;
    public float heightBetweenPlatform = 3.0f;
    int index = 0;

    bool stop = false; // 새로 추가된 부분
    private void Awake() {
        pos_WillCreatePlatformGroup = prefab_PlatformGroup.transform.position;
    }

    private void Start() {
        AddNewPlatform();
    }

    public void AddNewPlatform() {
        if(stop == false) // 새로 추가된 부분
        {
            GameObject added_platformGroup = Instantiate(prefab_PlatformGroup);
            added_platformGroup.transform.position = pos_WillCreatePlatformGroup;
            added_platformGroup.name = "new_platform" + index;
            added_platformGroup.GetComponent<PlatformGroup>().SetName("new_platform" + index);
            index = index + 1;

            pos_WillCreatePlatformGroup = new Vector2(pos_WillCreatePlatformGroup.x, pos_WillCreatePlatformGroup.y + heightBetweenPlatform);

            //플랫폼을 추가할때마다 동전을 추가해준다.
            AddCoin(pos_WillCreatePlatformGroup.y);
        }
    }

    // 새로 추가된 부분 _ 확률적으로 코인 추가 함수
    public void AddCoin(float height) {
        Debug.Log("add_coin");
        float add_percent = 0.3f; // 30% 확률로!
        float r_value = UnityEngine.Random.Range(0.0f, 1.0f);
        if(r_value < add_percent) {
            GameObject added_Coin = Instantiate(prefab_Coin);  // 새로운 동전을 추가해준다!
            added_Coin.transform.position = new Vector3(0.0f, height, transform.position.z);
        }
    }

    public void Stop()
    {
        stop = true;
    }
}
