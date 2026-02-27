using UnityEngine;

public class Destructible : MonoBehaviour
{
// 破壊された時に出すエフェクトや破片（あとで設定します）
public GameObject fragmentsPrefab;

private void OnCollisionEnter(Collision collision)
{
    // 当たった相手の名前に「WordProjectile」が含まれているかチェック
    if (collision.gameObject.name.Contains("WordProjectile"))
    {
        Shatter();
    }
}

void Shatter()
{
    Debug.Log("言葉の衝撃で破壊されました。");

    // 破片がある場合は生成
    if (fragmentsPrefab != null)
    {
        Instantiate(fragmentsPrefab, transform.position, transform.rotation);
    }

    // 自分自身（壁）を消去する
    Destroy(gameObject);
}
}