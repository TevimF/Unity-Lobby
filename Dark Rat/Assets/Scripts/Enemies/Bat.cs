using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Inimigos 
{
    // Start is called before the first frame update
    void Start()
    {
        // inicializando os componetes do inimigo
        base.v_walk = 5f;
        base.vida_maxima = 3;
        base.vida_atual = vida_maxima;
        base.dano = 2;
        base.inimigo = GameObject.Find("Bat");
    }
    // Update is called once per frame
    void Update()
    { 
    }
}
