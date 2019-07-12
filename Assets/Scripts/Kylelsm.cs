using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

// Press the space key in Play Mode to switch to the Bounce state.

public class Kylelsm : MonoBehaviour
{
    public Animator anim;
    public bool get;
    public AnimatorClipInfo[] m_CurrentClipInfo;

    float m_CurrentClipLength;
    public string codigo;
    public string email;


    public GameObject btnEnd;
    public Button btnTerminar;

    void Start()
    {

        if (PlayerPrefs.GetString("codigo") != null)
        {
            codigo = PlayerPrefs.GetString("codigo");
            Debug.Log(codigo);

        }
        if (PlayerPrefs.GetString("email") != null)
        {
            email = PlayerPrefs.GetString("email");
            Debug.Log(email);

        }
        btnTerminar = btnEnd.GetComponent<Button>();
        btnTerminar.onClick.AddListener(EndClass);
        anim = GetComponent<Animator>();
        m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
        StartCoroutine(SolicitarTraduccion());
    }

    private void Awake()
    {

    }

    void Update()
    {

    }
    void EndClass()
    {
        StartCoroutine(TerminarClase(codigo, email));
    }

    IEnumerator Movimientos(string[] movimientos)
    {
        Debug.Log(movimientos);
        if (movimientos != null)
        {
            if (movimientos.Length > 0)
            {
                Debug.Log("Soy diferente de nulo");
                for (int i = 0; i <= movimientos.Length - 1; i++)
                {
                    Debug.Log("longitu de movimientos" + movimientos.Length);
                    Debug.Log("numero de ciclo: " + i);

                    if (i != 0)
                    {
                        Debug.Log("Soy diferente de 0");
                        if (movimientos[i] != movimientos[i - 1])
                        {
                            Debug.Log("soy difente de la primera:" + movimientos[i]);
                            yield return StartCoroutine(AvatarMov(movimientos[i]));
                            Debug.Log("espere al if");
                        }
                        else
                        {
                            Debug.Log("voy a enviar default");
                            StartCoroutine(AvatarMov("default"));
                            yield return StartCoroutine(AvatarMov(movimientos[i]));
                        }
                    }
                    else
                    {
                        yield return StartCoroutine(AvatarMov(movimientos[i]));
                        Debug.Log("espere al if");
                    }
                 }
               StartCoroutine(SolicitarTraduccion());
            }
        }
        else
        {
            StartCoroutine(SolicitarTraduccion());
        }
    }

    IEnumerator AvatarMov(string mov)
    {
        Debug.Log("entre al if con:" + mov);
        if (mov!=null)
        {
            mov = "n";
            if (mov == "hola")
            {
                if (null != anim)
                {
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    // play Bounce but start at a quarter of the way though
                    anim.Play("Hola", 0, 0f);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                }
            }
            else if (mov == "historia")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("historia", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);


                }

            }
            else if (mov == "como_estar" || mov == "cómo_estar")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("comoestas", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "que" || mov == "qué")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("que", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "hoy")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("hoy", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "explicar")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("explicar", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "clase")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("clase", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "guerra")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("guerra", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "independencia")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("independencia", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "tema")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("tema", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "niño")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("niño", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "mujer")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("mujer", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "mexico")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("mexico", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "hidalgo")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("hidalgo", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "allende")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("allende", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "hombre")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("hombre", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "estudiar")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("estudiar", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "hacer")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("hacer", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "que")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("que", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "tema")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("tema", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "preguntar")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("preguntar", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "esclavo"|| mov == "esclavitud"||mov=="esclavizar")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("esclavo", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "inicio"|| mov == "empezar"|| mov == "comenzar" || mov == "iniciar"|| mov=="ir_a_iniciar")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("empezar", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "libro" || mov == "abrir_libro")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("libro", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "clase")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("libro", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "video")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("video", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "no")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("no", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "cúal")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("cual", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "español" || mov=="españoles")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("español", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "llegar")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("llegar", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "oprimir")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("oprimir", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "indigena")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("indigena", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "atrapar")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("atrapar", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "salvar")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("salvar", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "pagina")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("pagina", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "participar"|| mov == "participación")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("participar", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "pensar" || mov == "pensando")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("pensar", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "mucho" || mov == "muchos")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("muchos", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "default")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("WalkRM", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "leer")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("leer", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "adios"|| mov=="hasta_luego")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("adios", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "buenas_noches")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("buenasNoches", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "buenas_tardes")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("buenasNoches", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "buenos_dias")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("buenosDias", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "escribir")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("escribir", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "explicar")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("explicar", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "pasado"||mov=="anterior")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("pasado", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "porque" || mov == "¿por_que?")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("porque", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "ver"||mov=="observar")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("ver", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "a")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("a", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "b")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("b", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "c")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("c", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "d")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("d", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "e")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("e", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "f")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("f", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "g")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("g", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "h")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("h", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "i")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("i", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "j")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("j", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "k")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("k", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "l")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("l", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "m")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("m", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "n")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("n", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "o")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("o", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "p")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("p", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "q")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("q", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "r")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("r", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "s")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("s", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "t")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("t", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "u")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("u", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "v")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("v", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "w")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("w", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "x")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("x", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "y")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("y", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "z")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("z", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "despues"||mov=="luego")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("despues", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }
            else if (mov == "nosotros")
            {
                if (null != anim)
                {
                    // play Bounce but start at a quarter of the way though
                    anim.Play("nosotros", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

                }
            }

            else if (mov == "sin traduccion")
            {
                if (null != anim)
                {

                    // play Bounce but start at a quarter of the way though
                    anim.Play("sin traduccion", 0, 0f);
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                    Debug.Log("salir");

                }
            }
        }
        else
        {
            StartCoroutine(SolicitarTraduccion());
            yield return 0;
        }
    }
    IEnumerator SolicitarTraduccion()
    {
        Debug.Log("solicitando traduccion");

        WWWForm form = new WWWForm();
        form.AddField("codigo", codigo);
        form.AddField("correo", email);
        UnityWebRequest webRequest = UnityWebRequest.Post("http://137.135.88.10:5000/recibirTraduccion", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
         
            yield return StartCoroutine(AvatarMov("n"));

            SSTools.ShowMessage(webRequest.error, SSTools.Position.bottom, SSTools.Time.twoSecond);

        }
        else
        {
            if (webRequest.downloadHandler.isDone)
            {
                AvatarWords words = JsonUtility.FromJson<AvatarWords>(webRequest.downloadHandler.text);
                yield return StartCoroutine(Movimientos(words.traduccion));
            }
        }
    }

    IEnumerator TerminarClase(string codigo, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("codigo", codigo);
        form.AddField("tipo", "alumno");
        form.AddField("accion", "salir");
        form.AddField("correo", email);
        SSTools.ShowMessage("entre al resquest", SSTools.Position.bottom, SSTools.Time.twoSecond);

        UnityWebRequest www = UnityWebRequest.Post("http://137.135.88.10:5000/clase", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            SSTools.ShowMessage(www.error, SSTools.Position.bottom, SSTools.Time.twoSecond);

            Debug.Log(www.error);
        }
        else
        {
            if (www.downloadHandler.isDone)
            {
                SSTools.ShowMessage(www.downloadHandler.text, SSTools.Position.bottom, SSTools.Time.twoSecond);
                SceneManager.LoadScene("MainScreen");
            }
            else
            {
                Debug.Log("false");
                SSTools.ShowMessage("Upps hubo un error", SSTools.Position.bottom, SSTools.Time.twoSecond);
            }
        }
    }
}