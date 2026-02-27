using UnityEngine;

public class ExplosionAction : MonoBehaviour
{
    // 爆発のエフェクト（プレハブ）
    public GameObject myExplosion;
    // 爆発音のデータ
    public AudioClip explosionSound;

    private void OnCollisionEnter(Collision myCollision)
    {
        // 言葉（WordProjectile）が当たったか判定
        if (myCollision.gameObject.name.Contains("WordProjectile"))
        {
            // 爆発エフェクトを生成（講義資料 P.23）
            if (myExplosion != null)
            {
                Instantiate(myExplosion, transform.position, transform.rotation);
            }

            // 爆発音を再生（講義資料 P.24）
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            // 自分自身を消滅させる
            Destroy(this.gameObject);
        }
    }
}