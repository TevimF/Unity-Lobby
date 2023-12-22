using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variáveis
    public float velocidade = 5f;
    public float limiteXMin = -9.5f; // Defina o limite mínimo em X
    public float limiteXMax = 9.5f;  // Defina o limite máximo em X
    public float limiteZMin = -9.5f; // Defina o limite mínimo em Z
    public float limiteZMax = 9.5f;  // Defina o limite máximo em Z

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

        // Limita o jogador à área específica
        LimitarPosicao();
    }

    private void LimitarPosicao()
    {
        // Obtém a posição atual do jogador
        Vector3 posicaoAtual = transform.position;

        // Limita as coordenadas x e z dentro da área específica
        float xLimitado = Mathf.Clamp(posicaoAtual.x, limiteXMin, limiteXMax);
        float zLimitado = Mathf.Clamp(posicaoAtual.z, limiteZMin, limiteZMax);

        // Define a nova posição limitada
        transform.position = new Vector3(xLimitado, posicaoAtual.y, zLimitado);
    }

    #endregion
}
