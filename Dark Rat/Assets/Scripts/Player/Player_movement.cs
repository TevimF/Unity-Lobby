using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    #region Variáveis
    // objetos
    public Player_animation player_animation;
    public Player_skills player_skills;
    public GameObject player;
    public Rigidbody rb;
    // status
    bool andando = false;
    bool atacando = false;
    bool correndo = false;
    // velocidades
    public float v_run = 8f;
    public float v_walk = 4f;
    float velocidade_atual = 0;
    // Start is called before the first frame update
    #endregion
    void Start()
    {
        // inicializando os componentes
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        player_animation = player.GetComponent<Player_animation>();

    }
    void FixedUpdate()
    {
        MovimentarJogador();
    }
    // Update is called once per frame
    void Update()
    {
        atacando = player_animation.ta_rolando("ataque1")
        || player_animation.ta_rolando("ataque2");
    }

    void MovimentarJogador()
    {
        if (atacando) // se o jogador estiver atacando, ele não pode se mover
        {
            velocidade_atual = 0f;
            andando = false;
        }
        else if (correndo) // se o jogador estiver correndo, ele se move mais rápido v_run
        {
            andando = true;
            velocidade_atual = v_run;
        }
        else // se o jogador estiver andando, ele se move mais devagar v_walk
        {
            andando = true;
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
        player_animation.AnimatePlayer("andando", andando);

        if (Input.GetKey(KeyCode.LeftShift) && andando)
        {
            correndo = true;
        }
        else
        {
            correndo = false;
        }
        player_animation.AnimatePlayer("correndo", correndo);
    }
}
