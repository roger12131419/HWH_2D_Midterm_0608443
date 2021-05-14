using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [Header("等級")]
    [Tooltip("這是角色的等級")]
    public int lv = 1;
    [Header("移動速度"), Range(0, 300)]
    public float speed = 10.5f;
    public bool isDead = false;
    [Tooltip("這是角色的名稱")]
    public string cName = "男孩";
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("變形物件")]
    public Transform tra;
    [Header("偵測範圍")]
    public float rangeAttack = 2.5f;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("攻擊音效")]
    public AudioClip soundAttack;
    [Header("血量")]
    public float hp = 200;
    [Header("血條系統")]
    public HpManager hpManager;

    private float hpMax;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.4f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }


    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float h = joystick.Horizontal;
        float v = joystick.Vertical;
      

        tra.Translate(h * speed * Time.deltaTime, 0, 0);

       
    }

    public void Attack()
    {
        aud.PlayOneShot(soundAttack, 1.2f);

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, rangeAttack, -transform.up, 0, 1 << 8) ;



        if (hit && hit.collider.tag == "道具") hit.collider.GetComponent<Item>().Droppro();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收到的傷害值</param>
    public void  Hit(float damage)
    {
        hp -= damage;
        hpManager.UpdateHpBar(hp, hpMax);
    }

    private void Dead()
    {

    }

    // 事件
    private void Start()
    {
        hpMax = hp; 
    }

    private void Update()
    {
        Move();
    }
    [Header("吃金幣音效")]
    public AudioClip soundEat;
    [Header("金幣數量")]
    public Text textCoin;

    private int coin;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "金幣")
        {
            coin++;
            aud.PlayOneShot(soundEat);
            Destroy(collision.gameObject);
            textCoin.text = "金幣:" + coin;
            
        }
    }
}
