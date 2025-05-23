using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curInteractGameObject;
    private IInteractable curInteractable;

    public TextMeshProUGUI promptText;
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
    }
    
    void Update()
    {
        if(Time.time - lastCheckTime > checkRate)   // 일정 주기 마다 체크
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));    // 화면 중심에서 레이 발사
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, maxCheckDistance, layerMask)) // 상호 작용 가능 여부 체크
            {
                if(hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();   // 상호 작용 가능 시 정보 및 키 입력 가능
                    SetPromptText();
                }
            }
            else
            {
                curInteractGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()    // 정보 텍스트 활성화
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curInteractable.GetInteractPrompt();
    }

    public void OnInteractInput(InputAction.CallbackContext context)    // 상호 작용 키 입력시
    {
        if(context.phase == InputActionPhase.Started && curInteractable != null)
        {
            if (curInteractGameObject.layer == LayerMask.NameToLayer("Interactable"))   // 가능 여부체크
            {
                curInteractable.OnInteract();   // 상호 작용 발생
            }
            curInteractGameObject = null;
            curInteractable = null;
            if (promptText != null)
            {
                promptText.gameObject.SetActive(false);
            }
        }
    }
}