using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : Singleton<PlayerControl> 
{

    

    public bool FacingLeft { get { return facingLeft; } }
    //public static PlayerControl Instance;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private TrailRenderer myTrailRenderer;
    [SerializeField] private Transform weaponCollider;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    private Knockback knockback;
    private float startingMoveSpeed;

    public GameObject PauseMenu;
    public GameObject BagGroup;
    public GameObject ShowBagInvenotry;
    //public GameObject Hint;

    const string PAUSE_MENU_TEXT = "PauseMenu";
    const string HEALTH_SLIDER_TEXT = "BagGroup";
    const string SHOW_BAG_INVENTORY_TEXT = "ShowBagInventory";
    const string HINT_TEXT = "Hint";


    private bool facingLeft = false;
    protected override void Awake()
    {
        base.Awake();
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        startingMoveSpeed = moveSpeed;
        //ActiveInventory.Instance.EquipStartingWeapon;
        
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        

        PlayerInput();
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Pause();
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    Resume();
        //}
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Application.Quit();
        //}
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    OpenBag();
        //    Hint.SetActive(false);
        //}
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    CloseBag();
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    Hint.SetActive(false);
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Hint.SetActive(false);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Hint.SetActive(false);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Hint.SetActive(false);
        //}
    }

    public Transform GetWeaponCollider()
    {
        return weaponCollider;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            
        }

        //if (collision.gameObject.CompareTag("Finish"))
        //{
        //    SceneManager.LoadScene("Scren1");
        //}
    }


   

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }
    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        if (knockback.GettingKnockedBack || PlayerHealth.Instance.isDead) { return; }
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRender.flipX = true;
            facingLeft = true;
        }
        else
        {
            mySpriteRender.flipX = false;
            facingLeft = false;
        }
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenBag()
    {
      
        BagGroup.SetActive(true);
        ShowBagInvenotry.SetActive(false);

    }

    public void CloseBag()
    {

        BagGroup.SetActive(false);
        ShowBagInvenotry.SetActive(true);

    }
}
