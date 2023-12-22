using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variáveis
    public float velocidade = 5f;
    private Rigidbody rb;
    #endregion

    #region Métodos Unity
    private void Start()
    {
        // Inicializa o Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Movimenta o jogador
        MoverJogador();
    }
    #endregion

    #region Métodos Privados

    private void MoverJogador()
    {
        // Lógica para movimentar o jogador com base nos controles
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        transform.Translate(movimento * velocidade * Time.deltaTime);
    }

    #endregion
}
