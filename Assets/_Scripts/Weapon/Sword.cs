using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator myAnimator;
    
    //private PlayerControls playerControls;

    //private PlayerControl playerController;
    //private ActiveWeapon activeWeapon;

    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    //[SerializeField] private Transform weaponCollider;
    //[SerializeField] private float swordAttackCD = .5f;
    [SerializeField] public WeaponInfo weaponInfo;

    private Transform weaponCollider;
    private GameObject slashAnim;
    //private bool attachButtonDown, isAttacking = false;

    private void Awake()
    {
        //playerController = GetComponentInParent <PlayerControl>();
        //activeWeapon = GetComponentInParent<ActiveWeapon>();
        myAnimator = GetComponent<Animator>();
        
        //playerControls = new PlayerControls();
    }
    //private void OnEnable()
    //{
    //    playerControls.Enable();
    //}
    private void Start()
    {
        //playerControls.Combat.Attack.started += _ => StartAttacking();
        //playerControls.Combat.Attack.canceled += _ => StopAttacking();
        weaponCollider = PlayerControl.Instance.GetWeaponCollider();
        slashAnimSpawnPoint = GameObject.Find("SlashSpawnPoint").transform;
    }

    private void Update()
    {
        MouseFollowWithOffset();
        
        
        
        GetWeaponInfo();
        

    //Attack();
}

    public WeaponInfo GetWeaponInfo()
    {
        //Debug.Log("Update");

        
        return weaponInfo;
    }

//private void StartAttacking()
//{
//    attachButtonDown = true;
//}

//private void StopAttacking()
//{
//    attachButtonDown = false;
//}
public void Attack()
    {
       //if (attachButtonDown &&  !isAttacking)
       // {
       //     isAttacking = true;
            myAnimator.SetTrigger("Attack");
            weaponCollider.gameObject.SetActive(true);
            slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
            slashAnim.transform.parent = this.transform.parent;
            //StartCoroutine(AttackCDRoutine());
        //}
    }
    //private IEnumerator AttackCDRoutine()
    //{
    //    yield return new WaitForSeconds(swordAttackCD);
    //    //isAttacking = false;
    //    ActiveWeapon.Instance.ToggleIsAttacking(false);
    //}
    public void DoneAttackingAnimEvent()
    {
        weaponCollider.gameObject.SetActive(false);
    }
    public void SwingUpFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);

        if (PlayerControl.Instance.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void SwingDownFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (PlayerControl.Instance.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerControl.Instance.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0); 
        }
        else
        {   
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }   
}
