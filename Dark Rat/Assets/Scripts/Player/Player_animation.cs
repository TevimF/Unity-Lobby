using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animation : MonoBehaviour
{
    #region Variáveis
    public SpriteRenderer player_sprite;
    public Animator playeranimation;
    public Player_movement player_movement;
    public Player_skills player_skills;
    public bool atacando = false;
    public bool correndo = false;
    public bool andando = false;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        playeranimation = GetComponent<Animator>();
        player_sprite = GameObject.Find("Sprite").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        flip();
        atacando = playeranimation.GetCurrentAnimatorStateInfo(0).IsName("RatAttack")
        || playeranimation.GetCurrentAnimatorStateInfo(0).IsName("RatAttack2");
    }
    void flip()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (!atacando) // ele nao pode andar e atacar ao mesmo tempo
            {
                // virar o sprite
                if (Input.GetAxis("Horizontal") > 0)
                {
                    player_sprite.flipX = false;
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    player_sprite.flipX = true;
                }
            }
        }
    }

    public void AnimatePlayer(string animation, bool value)
    {
        playeranimation.speed = 1;
        switch (animation, value)
        {
            case ("andando", true || false):
                playeranimation.SetBool("andando", value);
                andando = value;
                break;
            case ("correndo", true|| false):
                playeranimation.SetBool("correndo", value);
                correndo = value;
                playeranimation.speed = (player_movement.v_run / player_movement.v_walk);
                break;
            case ("ataque1", true):
                playeranimation.SetInteger("ataque", 1);
                break;
                case ("ataque1", false):
                playeranimation.SetInteger("ataque", 0);
                break;
            case ("ataque2", true):
                playeranimation.SetInteger("ataque", 2);
                break;
                case ("ataque2", false):
                playeranimation.SetInteger("ataque", 0);
                break;
            default:
                playeranimation.SetBool("andando", false);
                playeranimation.SetBool("correndo", false);
                playeranimation.SetInteger("ataque", 0);
                break;
        }
    }
    public bool ta_rolando(string animation)
    {
        switch (animation)
        {
            case "andando":
                return playeranimation.GetCurrentAnimatorStateInfo(0).IsName("RatWalk");
            case "correndo":
                return playeranimation.GetCurrentAnimatorStateInfo(0).IsName("RatRun");
            case "ataque1":
                return playeranimation.GetCurrentAnimatorStateInfo(0).IsName("RatAttack");
            case "ataque2":
                return playeranimation.GetCurrentAnimatorStateInfo(0).IsName("RatAttack2");
            default:
                return false;
        }
    }

}
