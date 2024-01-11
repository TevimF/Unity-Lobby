using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.PackageManager;
#endif

public class Inimigos : MonoBehaviour
{
    #region Variáveis
    // Objetos
    public GameObject inimigo;
    Animator inimigo_animation;
    SpriteRenderer inimigo_sprite;
    Rigidbody rb;

    // Movimentação
    public float v_walk;
    protected bool andando = false;

    // Combate
    public int vida_maxima;
    protected int vida_atual;
    public int dano;
    protected bool atacando = false;

    // Status
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
        // Morto ou vivo
        if (vida_atual >= 0)
        {
            morto = false;
        }
        else
        {
            morto = true;
        }
        // Ferido ou não
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
            // Movimentação do inimigo
        }
        Animar();
    }

    public void Animar()
    {
        // Animação do inimigo
    }

    public void Combate()
    {
        // Combate do inimigo, ataque e defesa
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

#if UNITY_EDITOR
    // Código relacionado ao PackageManager aqui
#endif
}
