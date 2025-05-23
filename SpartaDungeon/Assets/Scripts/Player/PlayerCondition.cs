using System;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health
    {
        get { return uiCondition.health; }
    }

    Condition hunger
    {
        get { return uiCondition.hunger; }
    }

    Condition stamina
    {
        get { return uiCondition.stamina; }
    }
    
    public float noHungerHealthDecay;
    public event Action onTakeDamage;

    private void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);  // 일정 시간마다 배고픔 감소
        stamina.Add(stamina.passiveValue * Time.deltaTime); // 일정 시간마다 스테미나 회복

        if (hunger.curValue <= 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);  // 배고픔이 0이될 시 체력감소
        }

        if (health.curValue < 0f)   // 체력이 0이될 시 사망처리
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }
    
    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }
    
    public bool UseStamina(float amount)    // 스테미나 사용 이벤트
    {
        if(stamina.curValue - amount < 0)   // 비용 체크
        {
            return false;
        }
        stamina.Subtract(amount);
        return true;
    }
}