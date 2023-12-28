using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    #region Variáveis
    //objetos
    protected GameObject inimigo;
    Animator inimigo_animation;
    SpriteRenderer inimigo_sprite;
    Rigidbody rb;

    //movimentação
    protected float v_walk;
    protected bool andando = false;

    //combate
    public int vida_maxima;
    protected int vida_atual;
    protected int dano;
    protected bool atacando = false;

    //status
    protected bool ferido = false;
    protected bool morto = false;
    protected bool atordoado = false;

    #endregion
    #region Start
    // Start is called before the first frame update
    void Start()
    {
        // Pegar o componente Rigidbody do inimigo
        rb = GetComponent<Rigidbody>();
        // o gameObject do inimigo é declarado na classe filha
        // Pegar o componente Animator do inimigo
        inimigo_animation = GetComponent<Animator>();
    }
    #endregion
    #region Métodos
    void FixedUpdate()
    {
        Movimentar();
    }

    void Update()
    {
        Status();
        Animar();
        Combate();
    }
    #endregion
    #region Funções
    public void Status()
    {
        // morto ou vivo
        if (vida_atual >= 0)
        {
            morto = false;
        }
        else
        {
            morto = true;
        }
        // ferido ou não
        if (vida_atual < vida_maxima)
        {
            ferido = true;
        }
        else
        {
            ferido = false;
        }
    }

    public void Movimentar()
    {
        if (!morto)
        {
            //movimentação do inimigo
        }
        Animar();
    }
    public void Animar()
    {
        // animação do inimigo
    }

    public void Combate()
    {
        //combate do inimigo, ataque e defesa
    }

    public void TomarDano(int dano)
    {
        vida_atual -= dano;
        if (vida_atual <= 0)
        {
            morto = true;
        }
        else
        {
            ferido = true;
        }
    }
    public void Morrer()
    {
        Destroy(this.gameObject);
    }
    #endregion
}
