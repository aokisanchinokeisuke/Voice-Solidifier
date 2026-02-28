using UnityEngine;

public class DestructibleHeart : MonoBehaviour
{
    public void TriggerExplosion(WordPower power)
    {
        // 攻撃的な言葉の時だけ実行
        if (power == WordPower.Aggressive)
        {
            ExplosionAction action = GetComponent<ExplosionAction>();

            if (action != null)
            {
                // ExplosionAction.csに作った命令を呼び出す
                action.ExecuteExplosion(); 
            }
        }
    }
}