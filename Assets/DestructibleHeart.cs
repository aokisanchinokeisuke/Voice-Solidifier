// using UnityEngine;

// public class DestructibleHeart : MonoBehaviour
// {
//     public GameObject explosionEffectPrefab;

//     public void TriggerExplosion(WordPower power)
//     {
//         // 言葉の強さによって演出を分岐させる
//         if (power == WordPower.Aggressive)
//         {
//             // 攻撃的な言葉なら、爆発エフェクトを出して自分を消す
//             Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
//             Destroy(gameObject);
//             Debug.Log("暴力的な言葉により粉砕されました");
//         }
//         else if (power == WordPower.Normal)
//         {
//             // 普通の言葉なら、少し揺れる、あるいはログを出すだけ
//             Debug.Log("Normal: 衝撃を与えましたが破壊には至りません");
//         }
//         else
//         {
//             // 優しい言葉なら、何もしない（あるいは色を変える）
//             Debug.Log("Gentle: ハートを傷つけることはありません");
//         }
//     }
// }

using UnityEngine;

public class DestructibleHeart : MonoBehaviour
{
    public GameObject explosionEffectPrefab;

    public void TriggerExplosion(WordPower power)
    {
        if (power == WordPower.Aggressive)
        {
            if (explosionEffectPrefab != null)
            {
                Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}