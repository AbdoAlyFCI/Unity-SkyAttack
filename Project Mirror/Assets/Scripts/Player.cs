using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {



    [SerializeField]
    private float V_speed;  //سرعة التحرك الرائسيه

    [SerializeField]
    public float H_speed;  //سرعه التحرك الافقيه

    private float respeed;

    private float maxspeed = 50;
    [SerializeField]
    private Transform LiserGo;  //مكان خروج الليزر

    [SerializeField]
    private GameObject Liser;  //الماده المراد اطلاقها  

    private Rigidbody2D PlayerBody;  //خصائص الفيزيائيه  للاعب 

    private Animator change; //التغير بين الانيمشن

    private bool pause=false;

    private float attackTimer;     //فاصل بين الوقت
    private float attackCoolDown = 5;   //الفتره الزمنيه
    private bool canAttack = true;    //سماحيه الهجوم

    private float barTimer=0;     //فاصل بين الوقت
    private float barCoolDown = 3;   //الفتره الزمنيه
    //private bool canAttack = true;    //سماحيه الهجوم

    private float SUPERtime = 0;
    private float supercooldown = 60;
    private float numbermax=40f;
    private float numbermin=0;

    private int waittime=0;
    [SerializeField]
    public State fillup;   //حد الاطلاق

    [SerializeField]
    public State SuperPower;  //الليزر الاقصي


    private bool attack=true;

    public int score=0;
    private void Awake()
    {
        fillup.Initialize();
        SuperPower.Initialize();
    }
	// Use this for initialization
	void Start () {
        respeed = H_speed;
        PlayerBody = GetComponent<Rigidbody2D>();
        change = GetComponent<Animator>();
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        InPut();
        filldown();
        bardown();
        if(change.GetBool("super")==true)
        {
            H_speed = maxspeed;
            superbardown();
        }
	}

    void FixedUpdate()
    {
        PlayerBody.velocity = Vector2.right * H_speed;
        float V_Move = Input.GetAxis("Vertical");  //التحرك راسي
        PlayerMove( V_Move);
 
    }
    private void PlayerMove(float V)
    {
        PlayerBody.velocity = new Vector2(PlayerBody.velocity.x, V * V_speed);
    }

    private void ThrowLiser(int num) //اطلاق الليزر
    {
        attackTimer = num;
        attackTimer += 1;
        if (attackTimer >= attackCoolDown)
        {

            canAttack = true;
            attackTimer = 0;
        }
        if (canAttack && fillup.CurrentVAL <= 10 && fillup.CurrentVAL >= 0)
        {
            canAttack = false;
            fillup.CurrentVAL += 1;
    
            GameObject Tmp = (GameObject)Instantiate(Liser, LiserGo.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Tmp.GetComponent<LiserAttack>().Initialize(Vector2.right*2);            
        }
    
    }

    private void InPut()
    {
        if(Input.GetKeyDown(KeyCode.Space))  //زر اطلاق الليزر
        {       
                    int num = 6;
                    if (attack &&Time.timeScale==1)
                    {
                        fillup.CurrentVAL += 1;

                        ThrowLiser(num);
                    }
        }

        if(Input.GetKey(KeyCode.X))
        {
            superpower();
        }
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    ispause();
        //}
        
    }

    private void filldown()
    {
        if (attack &&Time.timeScale==1)
        {
            barTimer += 1;
            if (barTimer >= barCoolDown && fillup.CurrentVAL < 10 && fillup.CurrentVAL >= 0)
            {
                fillup.CurrentVAL -= .5f;
                barTimer = 0;
            }
            if (fillup.CurrentVAL >= fillup.MaxVAL)
            {
                attack = false;
            }
        }
    }
    private void bardown()
    {
        if (attack == false && Time.timeScale == 1)
        {
            numbermin += 1;
            if (attack == false &&numbermin>numbermax&& fillup.CurrentVAL >= 0f)
            {
                fillup.CurrentVAL -= .5f;
                numbermin = 0;
            }
            if (fillup.CurrentVAL ==-.5f)
            {
                attack = true;
            }
        }
    }

    private void superbardown()
    {
        if (change.GetBool("super") == true && Time.timeScale == 1)
        {
            SUPERtime += 1;
            if (SUPERtime > supercooldown && SuperPower.CurrentVAL >= 0f)
            {
                SuperPower.CurrentVAL -= 1f;
                SUPERtime = 0;
            }
            if (SuperPower.CurrentVAL == 0f)
            {
                H_speed = respeed;
                change.SetBool("super", false);
            }
        }
    }
    private void ispause()
    {
        if(!pause)
        {
            
            Time.timeScale = 0;
            pause = !pause;
        }
        else
        {
            Time.timeScale = 1;
            pause = !pause;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (change.GetBool("super") == false)
        {
            if (other.tag == "star" || other.tag == "mirror")
            {
                if (PlayerPrefs.HasKey("hscore"))
                {
                    if (PlayerPrefs.GetInt("hscore") < score)
                    {
                        PlayerPrefs.SetInt("hscore", score);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("hscore", score);
                }
                change.SetTrigger("Boom");
                H_speed = 0;
                V_speed = 0;
            }

            if (other.tag == "coin")
            {
                score++;
                Destroy(other.gameObject);
            }
            if (other.tag == "SUPERCOIN")
            {
                if (SuperPower.CurrentVAL < SuperPower.MaxVAL)
                {
                    score += 15;
                    SuperPower.CurrentVAL++;
                }
                Destroy(other.gameObject);
            }
        }
        if(change.GetBool("super")==true)
        {
            if (other.tag == "star" || other.tag == "mirror")
            {
                score += 7;
                Destroy(other.gameObject);
            }
            if (other.tag == "coin")
            {
                score++;
                Destroy(other.gameObject);
            }
        }
    }

    private void superpower()
    {
        if(SuperPower.CurrentVAL==SuperPower.MaxVAL)
        {
            change.SetBool("super", true);
        }
    }
}
