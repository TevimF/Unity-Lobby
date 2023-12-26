using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    float velocidade;
    Animator player_animation;
    Rigidbody rb;
    bool atacando = false;
    bool correndo = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        player_animation = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        MovimentarJogador();
    }
    void Update()
    {
        CombateJogador();
        atacando = player_animation.GetCurrentAnimatorStateInfo(0).IsName("RatAttack") || 
        player_animation.GetCurrentAnimatorStateInfo(0).IsName("RatAttack2");
    }
    void CombateJogador() // vai ficar os codigo de atk
    {
        if (atacando && Input.GetButtonDown("Fire1"))
        {
            player_animation.SetInteger("ataque", 2);
        }
        else if (!atacando && Input.GetButtonDown("Fire1"))
        {
            player_animation.SetInteger("ataque", 1);
        }
        else
        {
            player_animation.SetInteger("ataque", 0);
        }
    }

    void MovimentarJogador()
    {
        if (atacando)
        {
            velocidade = 0f;
        }
        else
        {
            velocidade = 5f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {  // correr
            velocidade = 10f;
            correndo = true;
        }
        else
        {
            correndo = false;
        }
        // Criar um vetor de movimento para ele andar
        Vector3 movimento = new Vector3(horizontal, 0f, vertical);
        Vector3 velocidadeMovimento = movimento * velocidade;

        // Configurar a velocidade do Rigidbody
        rb.velocity = new Vector3(velocidadeMovimento.x, rb.velocity.y, velocidadeMovimento.z);
        AnimarJogador();
    }
    void AnimarJogador()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            player_animation.SetBool("esta_andando", true);

            if (Input.GetAxis("Horizontal") > 0) // Se o jogador estiver indo para a direita
            {
                //virar sprite
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (Input.GetAxis("Horizontal") < 0) // Se o jogador estiver indo para a esquerda
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (correndo)
            {
                player_animation.SetBool("esta_correndo", true);
            }
            else
            {
                player_animation.SetBool("esta_correndo", false);
            }
        }
        else
        {
            player_animation.SetBool("esta_andando", false);
        }
    }
}