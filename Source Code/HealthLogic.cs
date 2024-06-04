using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class HealthLogic : MonoBehaviour
{
    private GameObject player;
    private Animator animator;
    private Animator animator2;
    private float FallSpeed;
    private bool damageready = false;
    private float intensity = 0.5f;
    private PlayerLogic playerLogic;
    private LadderLogic[] ladderLogic;
    private MusicHandler musicHandler;
    private GameObject[] Hearts;
    private float total = 6f;
    public bool ignorefall = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        animator = this.GetComponent<Animator>();
        animator2 = player.GetComponent<Animator>();
        playerLogic = FindObjectOfType<PlayerLogic>();
        musicHandler = GameObject.Find("MusicHandler").GetComponent<MusicHandler>();
        Transform parentTransform = transform;
        Hearts = new GameObject[parentTransform.childCount];
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Hearts[i] = parentTransform.GetChild(i).gameObject;
        }
    }

    public async void dodamage(float intensity, bool playsound=true)
    {
        if (playsound)
        {
            musicHandler.PlaySFX(musicHandler.Death);
            animator2.SetTrigger("Hurt");
        }
        animator.SetBool("flash", true);
        await Task.Delay(100);
        animator.SetBool("flash", false);
        total -= intensity;
        if (total < 6f)
        {
            if (total == 5.5f)
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartH");
            }
            else if (total == 5.0f)
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
            }
            else if (total == 4.5f)
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartH");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
            }
            else if (total == 4.0f)
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
            }
            else if (total == 3.5f)
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartH");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
            }
            else if (total == 3.0f)
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
            }
            else if (total == 2.5f)
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartH");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
            }
            else if (total == 2.0f)
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
            }
            else if (total == 1.5f)
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartH");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
            }
            else if (total == 1.0f)
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
            }
            else if (total == 0.5f)
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartH");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
            }
            else
            {
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartL");
                animator2.SetBool("Die", true);
                await Task.Delay(400);
                animator2.SetBool("Die", false);
                player.transform.position = new Vector3(0f, -3.58f, -2f);
                await Task.Delay(400);
                Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
                total = 6f;
            }
        } else
        {
            total = 6f;
            Hearts[0].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
            Hearts[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
            Hearts[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
            Hearts[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
            Hearts[4].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
            Hearts[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HeartF");
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            ladderLogic = FindObjectsOfType<LadderLogic>();
        }
        catch {}
        if (!ignorefall)
        {
            FallSpeed = player.GetComponent<Rigidbody2D>().velocity.y;
            if (FallSpeed < -30)
            {
                playerLogic.isGrounded = false;
                damageready = true;
                intensity = 2f;
            }
            else if (FallSpeed < -20)
            {
                playerLogic.isGrounded = false;
                damageready = true;
                intensity = 1;
            }
            else if (FallSpeed < -15)
            {
                playerLogic.isGrounded = false;
                damageready = true;
                intensity = 0.5f;
            }

            if (ladderLogic.Length != 0)
            {
                if (ladderLogic[0].LadderTrigger || ladderLogic[1].LadderTrigger)
                {
                    damageready = false;
                }
            }

            if (damageready == true && playerLogic.isGrounded)
            {
                damageready = false;
                dodamage(intensity);
            }
        }
    }
}
