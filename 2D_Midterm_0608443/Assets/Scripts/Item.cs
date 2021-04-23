using UnityEngine;

public class Item : MonoBehaviour
{

    [Header("掉落物品")]
    public GameObject prop;
    [Header("掉落機率"), Range(0f, 0)]
    public float percent = 0.7f;

    public void Droppro()
    {
        float r = Random.Range(0f, 1f);

      // print("隨機值: " + r);

      if (r <= percent)
      {
            Instantiate(prop, transform.position, transform.rotation);
      }

        Destroy(gameObject);
    }
}


