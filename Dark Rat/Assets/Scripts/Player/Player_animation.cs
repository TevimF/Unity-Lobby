using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animation : MonoBehaviour
{
    private const bool Value = true;
    #region Variáveis
    public SpriteRenderer player_sprite;
    public Animator player_animator;
    public Player_movement player_movement;
    public Player_actions player_skills;
    public bool atacando = false;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        player_animator = GetComponent<Animator>();
        player_movement = GetComponent<Player_movement>();
        player_sprite = GameObject.Find("Sprite").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }
    void Flip()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            atacando = TaRolando("ataque1");
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

    public void AnimatePlayer(string animation)
    {
        if (TaRolando(animation))
        {
            return;
        }
        switch (animation)
        {
            case "idle":
                player_animator.SetTrigger("idle");
                break;
            case "parado":
                player_animator.SetBool("andando", false);
                player_animator.SetFloat("v_run", 1);
                break;
            case "andando":
                player_animator.SetBool("andando", true);
                player_animator.SetFloat("v_run", 1);
                break;
            case "correndo": // anda mais rápido
                player_animator.SetBool("andando", true);
                player_animator.SetFloat("v_run", (float)player_movement.Boost());
                break;
            case "ataque1":
                player_animator.SetTrigger("ataque1");
                break;
            case "ataque2":
                player_animator.SetTrigger("ataque2");
                break;
            case "shield":
                player_animator.SetTrigger("shield");
                break;
            case "dano":
                player_animator.SetTrigger("ferido");
                break;
            case "morrer":
                player_animator.SetBool("morto", true);
                break;
            default:
                Debug.LogError("Animation" + animation + "not found");
                break;
        }
    }
    public bool TaRolando(string animation)
    {
        switch (animation)
        {
            case "parado":
                return player_animator.GetBool("andando") == false;
            case "andando":
                return player_animator.GetCurrentAnimatorStateInfo(0).IsName("RatWalk")
                && player_animator.GetFloat("v_run") == 1;
            case "correndo":
                return player_animator.GetCurrentAnimatorStateInfo(0).IsName("RatRun");
            case "ataque1":
                return player_animator.GetCurrentAnimatorStateInfo(0).IsName("RatAttack");
            case "ataque2":
                return player_animator.GetCurrentAnimatorStateInfo(0).IsName("RatAttack2");
            case "shield":
                return player_animator.GetCurrentAnimatorStateInfo(0).IsName("RatShield");
            case "idle":
                return player_animator.GetCurrentAnimatorStateInfo(0).IsName("RatIdle");
            case "dano":
                return player_animator.GetCurrentAnimatorStateInfo(0).IsName("RatDamage");
            case "morrer":
                return player_animator.GetCurrentAnimatorStateInfo(0).IsName("RatDeath");
            default:
                Debug.LogError("Animation " + animation + " not found");
                return false;
        }
    }
}
