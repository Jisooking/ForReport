using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent;

    private PlayerController controller;
    private PlayerCondition condition;

    void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
        condition = CharacterManager.Instance.Player.condition;
    }

    public void EquipNew(ItemData data) // 플레이어 아이템 장착 처리
    {
        UnEquip();
        curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<Equip>();
    }

    public void UnEquip() // 플레이어 아이템 장착 해제 처리
    {
        if(curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip = null;
        }
    }
    
    public void OnAttackInput(InputAction.CallbackContext context)  // 공격 키 입력시 발생되는 함수
    {
        if(context.phase == InputActionPhase.Performed && curEquip != null && controller.canLook) 
        {
            curEquip.OnAttackInput();   // 무기별로 OnAttackInput 출력
        }
    }
}