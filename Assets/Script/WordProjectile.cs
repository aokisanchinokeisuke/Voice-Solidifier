using UnityEngine;
using TMPro;

public class WordProjectile : MonoBehaviour
{
    public WordPower myPower;
    private TextMeshPro textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    // 性質を設定するメソッド
    public void SetPower(WordPower power)
    {
        myPower = power;
        if (textMesh == null) textMesh = GetComponent<TextMeshPro>();

        switch (power)
        {
            case WordPower.Aggressive:
                textMesh.color = Color.red;
                transform.localScale *= 1.8f;
                break;
            case WordPower.Gentle:
                textMesh.color = Color.cyan;
                transform.localScale *= 0.7f;
                break;
            case WordPower.Normal:
                textMesh.color = Color.white;
                break;
        }
    }

    // 衝突した時の処理
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突が起きているか確認するためのログ
        Debug.Log("衝突しました: " + collision.gameObject.name);

        var heart = collision.gameObject.GetComponent<DestructibleHeart>();
        
        if (heart != null)
        {
            heart.TriggerExplosion(myPower);
            // Destroy(gameObject);
        }
    }
}