using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float launchForce = 200f; // 튀어오르는 힘
    public Vector3 launchDirection = Vector3.up; // 위쪽 방향

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 기존 속도 초기화 후 힘 가하기 (강하게 튀어오르게 하기 위해)
            rb.velocity = Vector3.zero;
            rb.AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
        }
    }
}