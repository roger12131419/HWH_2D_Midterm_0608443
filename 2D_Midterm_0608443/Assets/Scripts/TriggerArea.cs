using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [Header("要關閉的牆壁")]
    public GameObject[] stones;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "石塊")
        {
            stones[0].SetActive(false);
        }
    
                
                
     }
}
