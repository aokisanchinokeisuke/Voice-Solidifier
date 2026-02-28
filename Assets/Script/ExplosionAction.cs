using UnityEngine;

public class ExplosionAction : MonoBehaviour
{
    public GameObject myExplosion;
    public AudioClip explosionSound;

    public void ExecuteExplosion()
    {
        // 爆発エフェクトを生成
        if (myExplosion != null)
        {
            Instantiate(myExplosion, transform.position, transform.rotation);
        }

        // 爆発音を再生
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }

        // 自分（ハート）を消滅させる
        Destroy(this.gameObject);
    }
}