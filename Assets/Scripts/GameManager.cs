using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject 子彈;
    public Transform 生成位置;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ShootBullet();
        }
    }
    void ShootBullet()
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 cameraForward = mainCamera.transform.forward;
        // 实例化子弹对象
        GameObject bullet = Instantiate(子彈, 生成位置.position, Quaternion.identity);
        Vector3 bulletDirection = cameraForward;

        // 给子弹添加力，使其向前移动
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 5000f);

        // 销毁子弹对象，防止游戏中出现大量无用的子弹
        Destroy(bullet, 2f);
    }
}
