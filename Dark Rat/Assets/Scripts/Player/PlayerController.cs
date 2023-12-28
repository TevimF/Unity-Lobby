using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variáveis
    // objetos
    public GameObject player;
    Animator player_animation;
    SpriteRenderer player_sprite;
    Rigidbody rb;

    // movimentação
    bool andando = false;
    bool atacando = false;
    bool correndo = false;
    public float v_run = 8f;
    public float v_walk = 4f;
    float velocidade_atual = 0;

    // vida
    public int vida_maxima = 5;
    int vida_atual = 1;

    // combate
    public int dano = 2;

    #endregion

    #region Start
    void Start()
    {
        // Pegar o componente Rigidbody do jogador
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        // Pegar o componente Animator do jogador
        player_animation = GetComponent<Animator>();
        player_sprite = GameObject.Find("Sprite").GetComponent<SpriteRenderer>();

        // inicializando o player
        vida_atual = vida_maxima;
    }
    #endregion

    #region Métodos
    void FixedUpdate()
    {
        MovimentarJogador();
    }

    void Update()
    {
        Status();
        AnimarJogador();
        CombateJogador();  
    }

    #endregion

    #region Funções
    void Status()
    {
        // movimentação
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            andando = true;
        }
        else
        {
            andando = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            correndo = true;
        }
        else
        {      
            correndo = false;
        }
        // ataques
        atacando =
            player_animation.GetCurrentAnimatorStateInfo(0).IsName("RatAttack")
            || player_animation.GetCurrentAnimatorStateInfo(0).IsName("RatAttack2");
    }

    public void CombateJogador()
    {
        //falta mecanica de combate
    }

    void MovimentarJogador()
    { 
        if (atacando) // se o jogador estiver atacando, ele não pode se mover
        {
            velocidade_atual = 0f;
        }
        else if (correndo) // se o jogador estiver correndo, ele se move mais rápido v_run
        {
            velocidade_atual = v_run;
        }
        else // se o jogador estiver andando, ele se move mais devagar v_walk
        {
            velocidade_atual = v_walk;
        }
        // Pegar os valores do eixo horizontal e vertical valor de -1 a 1
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // Criar um vetor de movimento para ele andar
        Vector3 movimento = new Vector3(horizontal, 0f, vertical);
        Vector3 velocidadeMovimento = movimento * velocidade_atual;

        // Configurar a velocidade do Rigidbody
        rb.velocity = new Vector3(velocidadeMovimento.x, rb.velocity.y, velocidadeMovimento.z);
        AnimarJogador();
    }

    void AnimarJogador()
    {
        // animação de ataque
        player_animation.speed = 1;
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
        // animação de movimentos
        if (andando)
        {
            // animação de andar
            player_animation.SetBool("andando", true);

            if (!atacando) // ele nao pode andar e atacar ao mesmo tempo
            {
                switch (Mathf.Sign(Input.GetAxis("Horizontal")))
                {
                    case >0: // se andando para a direita, desvira a sprite
                        player_sprite.flipX = false;
                        break;
                    case <0: // se andando para a esquerda, virar sprite
                        player_sprite.flipX = true;
                        break;
                }

                if (!correndo) // ao correr, a animação fica mais rápida
                {
                    player_animation.SetBool("correndo", false);
                    player_animation.speed = 1;
                }
                else
                {
                    player_animation.SetBool("correndo", true);
                    player_animation.speed = v_run / v_walk;
                }
            }
        }
        else
        {
            // animação de parado
            player_animation.SetBool("andando", false);
        }
    }
    #endregion
}
