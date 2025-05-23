using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetInteractPrompt() // 상호작용 프롬프트 표시
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()    // 상호작용 시 발생이벤트
    {
        //Player 스크립트 먼저 수정
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}