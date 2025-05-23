using UnityEngine;

public class Resource : MonoBehaviour
{
    public ItemData itemToGive;
    public int quantityPerHit = 1;
    public int capacity;

    public void Gather(Vector3 hitPoint, Vector3 hitNormal) // 채집
    {
        for(int i = 0; i < quantityPerHit; i++) // 채집가능 갯수 체크
        {
            if (capacity <= 0) break;

            capacity -= 1;
            Instantiate(itemToGive.dropPrefab, hitPoint + Vector3.up, Quaternion.LookRotation(hitNormal, Vector3.up)); // 채집아이템 드롭
        }

        if(capacity <= 0)
        {
            Destroy(gameObject);
        }
    }
}
