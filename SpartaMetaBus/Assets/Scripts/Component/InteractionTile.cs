using System;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // �÷��̾ Ʈ���ſ� ������ �� ����Ǵ� �Լ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ʈ���ſ� ���� ������Ʈ�� "Player" �±׸� ������ �ִ��� Ȯ��
        if (other.CompareTag("Player"))
        {
            Debug.Log("��ȣ�ۿ� ������ ������ �����߽��ϴ�!");

            UnityEngine.SceneManagement.SceneManager.LoadScene("FlappyPlane");
        }
    }
}
