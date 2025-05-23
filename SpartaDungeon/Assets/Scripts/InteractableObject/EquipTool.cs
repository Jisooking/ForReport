using UnityEngine;

public class EquipTool : Equip
{
    private Animator animator;
    private Camera camera;

    public float useStamina;

    private void Awake()
    {
        camera = Camera.main;
        animator = GetComponent<Animator>();
    }

    public float attackRate;
    private bool attacking;
    public float attackDistance;

    [Header("Resource Gathering")] public bool doesGatherResources;

    [Header("Combat")] public bool doesDealDamage;
    public int damage;

    public override void OnAttackInput()    //공격 키 입력
    {
        if (!attacking) //중복 공격 불가능 설정
        {
            if (CharacterManager.Instance.Player.condition.UseStamina(useStamina))  //스테미나 체크
            {
                attacking = true;
                animator.SetTrigger("Attack");
                Invoke("OnCanAttack", attackRate);
            }
        }
    }

    void OnCanAttack()
    {
        attacking = false;
    }

    public void OnHit() // 공격 적용 처리
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackDistance))
        {
            if (doesGatherResources && hit.collider.TryGetComponent(out Resource resource)) // 자원채집 가능시 채집
            {
                resource.Gather(hit.point, hit.normal);
            }
        }
    }
}