using UnityEngine;
using TMPro;

// 言葉の強さを定義する型
public enum WordPower
{
    Gentle,   // 優しい
    Normal,   // 普通
    Aggressive // 攻撃的
}

public class WordProjectile : MonoBehaviour
{
    public WordPower myPower;
    private TextMeshPro textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    // 生成時にKoeControllerから呼ばれる設定用メソッド
    public void SetPower(WordPower power)
    {
        myPower = power;

        if (textMesh == null) textMesh = GetComponent<TextMeshPro>();

        // 強さに応じて見た目をフィードバックする
        switch (power)
        {
            case WordPower.Aggressive:
                textMesh.color = Color.red; // 攻撃的な言葉は赤
                transform.localScale *= 1.8f; // サイズを大きくして威圧感を出す
                break;
            case WordPower.Gentle:
                textMesh.color = Color.cyan; // 優しい言葉は水色
                transform.localScale *= 0.7f; // サイズを小さくして柔らかさを出す
                break;
            case WordPower.Normal:
                textMesh.color = Color.white; // 通常は白
                break;
        }
    }
}