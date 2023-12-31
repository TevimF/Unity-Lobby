using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_actions : MonoBehaviour
{
    #region Variáveis
    // objetos
    public Player_animation player_animation;
    public Player_movement player_movement;
    public GameObject player;
    public Vector3 mira;
    public GameObject mira_objeto;
    // vida
    public int vida_maxima = 5;
    int vida_atual = 1;

    // combate
    public bool atacando_anim = false;
    public int dano = 2;
    public float range = 0.7f;
    #endregion
    void Start()
    {
        // inicializando o player
        vida_atual = vida_maxima;
        // inicializando a mira
        mira_objeto = GameObject.Find("mira");
        // inicializando os componentes
        player = GameObject.Find("Player");
        // inicializando os scripts
        player_animation = player.GetComponent<Player_animation>();
    }
    void Update()
    {
        atacando_anim = player_animation.TaRolando("ataque1") 
        || player_animation.TaRolando("ataque2");
        Atacar();
        Status();
    }
    public void Atacar()
    {
        bool attack = Input.GetButtonDown("Fire1");
        if (attack && !atacando_anim){
            player_animation.AnimatePlayer("ataque1");
        }
        else if (attack && atacando_anim){
            player_animation.AnimatePlayer("ataque2");
        }
        
        bool block = Input.GetButtonDown("Fire2");
        if (block){
            player_animation.AnimatePlayer("shield");
        }
    }
    public void Status()
    {
        if (vida_atual <= 0)
        {
            player_animation.AnimatePlayer("morrer");
        }

    }
    public void TomarDano(int dano)
    {
        vida_atual -= dano;
        player_animation.AnimatePlayer("dano");
    }
}
