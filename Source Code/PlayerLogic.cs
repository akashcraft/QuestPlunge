using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLogic : MonoBehaviour
{
    public Rigidbody2D control;
    public int JumpSpeed;
    public int MoveSpeed;
    public int LadderSpeed;
    public bool isGrounded = true;
    public Animator animator;
    private LadderLogic[] ladderLogic;
    private bool ladder;
    public bool shield = false;
    private MusicHandler musicHandler;

    private void Start()
    {
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //If Player is on Ground
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            ladderLogic = FindObjectsOfType<LadderLogic>();
            ladder = ladderLogic.Length != 0 ? ladderLogic[0].LadderTrigger || ladderLogic[1].LadderTrigger : false;
        }
        catch {
            ladder = false;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject.Find("Pause").GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        } else if (Input.GetKeyDown(KeyCode.F1)){
            GameObject.Find("SpeedPU").GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        } else if (Input.GetKeyDown(KeyCode.F2)){
            GameObject.Find("JumpPU").GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        } else if (Input.GetKeyDown(KeyCode.F3)){
            GameObject.Find("RegenPU").GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        } else if (Input.GetKeyDown(KeyCode.F4)){
            GameObject.Find("ShieldPU").GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        } else if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Attack");
            musicHandler.PlaySFX(musicHandler.Sword);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(control.velocity.x));
        // Check if moving right
        if (control.velocity.x > 0)
        {
            transform.localScale = new Vector3(2, 2, 2); // No flip needed
        }
        // Check if moving left
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2); // Flip horizontally
        }
        //If User clicks Up or W and is on Ground
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && isGrounded && !ladder) //Regular Jump
        {
            isGrounded = false;
            control.velocity = new Vector2(control.velocity.x, control.velocity.y + JumpSpeed);
        }
        else if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && isGrounded && ladder) //Ladder
        {
            isGrounded = true;
            control.velocity = new Vector2(control.velocity.x, LadderSpeed);
        }
        else if (horizontalInput==0 && !isGrounded && ladder)
        {
            control.velocity = new Vector2(control.velocity.x, -LadderSpeed);
        }
        else //Horizontal
        {
            control.velocity = new Vector2(horizontalInput * MoveSpeed, control.velocity.y); 
            
        }
    }
}
