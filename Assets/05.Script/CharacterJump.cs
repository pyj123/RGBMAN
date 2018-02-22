using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterJump : MonoBehaviour
{

    [SerializeField]
    private InGameUI ingameUI;

    [SerializeField]
    private PlatformCounter platformCounter;

    private Rigidbody2D rb;

    [SerializeField]
    private float jumpPower = 8f;


    private int jumpCount = 0;
    [SerializeField]
    private int jumpCountMax = 1;

    private CharacterAnimator characterAnimator;

    private CharacterEffector characterEffector;

    private CharacterAttacker characterAttacker;

    private bool nowPowerJump = false;
    public bool NowPowerJump
    {
        get
        {
            return nowPowerJump;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        characterAnimator = GetComponent<CharacterAnimator>();
        characterEffector = GetComponent<CharacterEffector>();
        characterAttacker = GetComponent<CharacterAttacker>();

        jumpPower = GameConstant.PlayerJumpPower;
        //jumpPower = 20f;
    }

    private bool CanJump()
    {
        return jumpCount < jumpCountMax;
    }

    private void ResetJumpCount()
    {
#if UNITY_EDITOR
        Debug.Log("JumpCountReset");
#endif
        jumpCount = 0;

        if (nowPowerJump == true)
            nowPowerJump = false;

        if(platformCounter!=null)
        {
            if (characterAttacker != null)
                platformCounter.CountPlatform(characterAttacker.NowRGBType);

        }


    }

    public void Jump()
    {
        if (nowPowerJump == true) return;

        if (CanJump() == false)
        {
            Down();
            return;
        }

        Addforce(jumpPower);
        jumpCount++;

        SoundManager.Instance.PlaySoundEffect("Jump");

        if (characterAnimator != null)
            characterAnimator.PlayerAnim(AnimState.Jump);
    }

    private void Addforce(float jumpPower)
    {
        if (rb == null) return;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    public void PowerJump(float jumpPower, bool PlaySound = true)
    {
        nowPowerJump = true;

        if (PlaySound == true)
            SoundManager.Instance.PlaySoundEffect("Holol");

        Addforce(jumpPower);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == GameConstant.CenterPlatformName)
        {
            if (rb.velocity.y <= 0f)
                ResetJumpCount();
        }
    }

    public void Down()
    {
        if (rb == null) return;

        int prefLayer = this.gameObject.layer;

        this.gameObject.layer = LayerMask.NameToLayer("Player");

        int layerMask = (1 << prefLayer) | (1 << LayerMask.NameToLayer(LayerName.All));

        RaycastHit2D rayHit = Physics2D.Raycast(this.transform.position, Vector3.down, 20, layerMask);
        if (rayHit.collider != null)
        {


            //이펙트
            if (characterEffector != null)
                characterEffector.MakeSparkEffect(rayHit.point);

            //사운드
            SoundManager.Instance.PlaySoundEffect("Down");

            //애니메이션
            if (characterAnimator != null)
                characterAnimator.PlayerAnim(AnimState.Down);

            if (rayHit.collider.gameObject.CompareTag("DeadLine"))
            {
                if (ingameUI != null)
                    ingameUI.WhenPlayerDead();

                rb.velocity = Vector3.zero;
                this.transform.position = rayHit.point;

#if UNITY_EDITOR

                Debug.Log("DeadLine");
#endif      
            }
            else
            {
                rb.velocity = Vector3.zero;
                this.transform.position = rayHit.point + Vector2.up * 0.6f;
            }


        }
        this.gameObject.layer = prefLayer;

    }




#if UNITY_EDITOR

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Jump();
            PowerJump(20f);
        }


    }
#endif

}
