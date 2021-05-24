using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public Animator playerAnimator;
    public float speed = 8f;
    public GameObject gameOver;
    public Text scoText;
    public Text bestScoText;
    public int hp = 100;
    private float sco;
    public HpBar hpbar;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        speed = 8f;
        sco = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");


        if (xInput == 0 && zInput == 0)
        {
            playerAnimator.SetTrigger("Idle");
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerAnimator.SetTrigger("Dash");
                speed = 15.0f;
                float xSpeed = xInput * speed;
                float zSpeed = zInput * speed;
                Vector3 newV = new Vector3(xSpeed, 0f, zSpeed);
                playerRigidbody.velocity = newV;
                transform.LookAt((transform.position + newV));

            }
            else
            {
                playerAnimator.SetTrigger("Walk");
                speed = 7.0f;
                float xSpeed = xInput * speed;
                float zSpeed = zInput * speed;
                Vector3 newV = new Vector3(xSpeed, 0f, zSpeed);
                playerRigidbody.velocity = newV;
                transform.LookAt((transform.position + newV));

            }
        }

        sco += Time.deltaTime;
        scoText.text ="생존 시간 : " + (int)sco;


    }
    public void die()
    {
        EndGame();
        Time.timeScale = 0;
    }
    public void EndGame()
    {
        this.gameObject.SetActive(false);
        gameOver.SetActive(true);
        float bestSco = PlayerPrefs.GetFloat("bestSco");
        Debug.Log(bestSco);
        if (sco> bestSco)
        {
            bestSco = sco;
            PlayerPrefs.SetFloat("bestSco", bestSco);
        }
        bestScoText.text = "최고 기록 : " + (int)bestSco;
    }
    public void GetDamage(int damage)
    {
        hp -= damage;
        hpbar.SetHP(hp);
        if (hp <= 0)
        {
            die();
        }
    }
}


