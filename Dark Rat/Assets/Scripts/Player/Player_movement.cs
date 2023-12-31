using UnityEngine;

public class Player_movement : MonoBehaviour
{
    // objetos
    public Player_animation player_animation;
    public Player_actions player_actions;
    public GameObject player;
    public Rigidbody rb;
    public BoxCollider boxCollider;

    // status
    bool andando = false;
    bool atacando = false;

    // velocidades
    public float v_run = 8f;
    public float v_walk = 4f;
    public float velocidade_atual = 0;

    void Start()
    {
        // inicializando os componentes
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        player_animation = player.GetComponent<Player_animation>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {
        MovimentarJogador();
    }
    void Update()
    {
        atacando = player_animation.TaRolando("ataque1")
        || player_animation.TaRolando("ataque2");
    }

    void MovimentarJogador()
    {
        bool morto = player_animation.TaRolando("morrer");
        if (morto)
        {
            velocidade_atual = 0;
            andando = false;
            rb.velocity = Vector3.zero;
            return;
        }
        if (atacando) // se o jogador estiver atacando, ele não pode se mover direito
        {
            velocidade_atual = v_walk/2;
            andando = false;
        }
        else
        {
            andando = Input.GetAxis("Horizontal") != 0
            || Input.GetAxis("Vertical") != 0;
        }

        // definindo o que é correr
        if (!atacando && Input.GetKey(KeyCode.LeftShift))
        {
            velocidade_atual = v_run;
            player_animation.AnimatePlayer("correndo");
        }
        else if (andando)
        {
            velocidade_atual = v_walk;
            player_animation.AnimatePlayer("andando");
        }
        else
        {
            player_animation.AnimatePlayer("parado");
        }

        // Pegar os valores do eixo horizontal e vertical valor de -1 a 1
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal < 0)
        {
            boxCollider.center = new Vector3(boxCollider.center.x * -1, boxCollider.center.y, boxCollider.center.z);
        }
        else if (horizontal > 0)
        {
            boxCollider.center = new Vector3(boxCollider.center.x * -1, boxCollider.center.y, boxCollider.center.z);
        }


        // Movimentar o jogador
        Vector3 movimento = new Vector3(horizontal, 0f, vertical);
        Vector3 velocidadeMovimento = movimento * velocidade_atual;
        rb.velocity = new Vector3(velocidadeMovimento.x, rb.velocity.y, velocidadeMovimento.z);

    }

    public float Boost()
    {
        if (v_walk != 0)
        {
            return (float)(v_run / v_walk);
        }
        else
        {
            return 0;
        }
    }
}
