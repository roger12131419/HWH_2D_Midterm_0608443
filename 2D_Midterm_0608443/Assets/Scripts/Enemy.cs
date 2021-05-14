using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("追蹤範圍"), Range(0, 500)]
    public float rangeTrack = 2;
    [Header("攻擊範圍"), Range(0, 50)]
    public float rangeQAttack = 0.5f;
    [Header("移動速度"), Range(0, 50)]
    public float speed = 2;
    
    
    private Transform player;

    private void Start()
    {
        // 玩家變形 = 尋找遊戲物件("物件名稱").變形
        player = GameObject.Find("玩家").transform;

        
    }

    // 繪製圖示事件 : 在 Unity 內顯示輔助開發
    private void OnDrawGizmos()
     
    
    {
            //  先指定顏色在畫圖
            Gizmos.color = new Color(0, 0, 1, 0.3f);
            // 繪製球體(中心點，半徑)
            Gizmos.DrawSphere(transform.position, rangeTrack);

            Gizmos.color = new Color(1, 0, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeQAttack);
    }

    private void Update()
    {
        Track();
    }

    /// <summary>
    /// 追蹤玩家
    /// <summary>
    private void Track()
     {
        // 距離 等於 三圍向量 的 距離(A 點，B點)
        float dis = Vector3.Distance(transform.position, player.position);
        
        if (dis <= rangeTrack)
        {
        
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
        
    }
 }
