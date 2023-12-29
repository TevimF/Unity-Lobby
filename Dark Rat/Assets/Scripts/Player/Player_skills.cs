using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_skills : MonoBehaviour
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
    public bool atacando = false;
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
        atacando = player_animation.ta_rolando("ataque1") 
        || player_animation.ta_rolando("ataque2");
        Atacar();
    }
    public void Atacar()
    {
        if (Input.GetButtonDown("Fire1") && atacando){
            player_animation.AnimatePlayer("ataque2", true);
            atacando = true;
        }
        else if (Input.GetButtonDown("Fire1") && !atacando)
        {
            player_animation.AnimatePlayer("ataque1", true);
            atacando = true;
        }
        else {
            player_animation.AnimatePlayer("ataque1", false);
            player_animation.AnimatePlayer("ataque2", false);
        }
    }
        
}
