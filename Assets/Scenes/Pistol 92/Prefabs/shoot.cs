using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public GameObject smokePrefab;
    public GameObject shockwavePrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "barrel_dust_red_damage0(1)")
        {
            // 实例化烟雾效果
            Instantiate(smokePrefab, collision.contacts[0].point, Quaternion.identity);

            // 实例化冲击波效果
            Instantiate(shockwavePrefab, collision.contacts[0].point, Quaternion.identity);

            // 销毁桶
            Destroy(collision.gameObject);
        }
    }
}