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
    public AnimatorClipInfo[] m_CurrentClipInfo;
    float m_CurrentClipLength;
    public string codigo;
    public string email;
    Dictionary<string, string> animLSM = new Dictionary<string, string>();
    public GameObject btnEnd;
    public Button btnTerminar;

    void Start()
    {

        if (PlayerPrefs.GetString("codigo") != null)
        {
            codigo = PlayerPrefs.GetString("codigo");
        }
        if (PlayerPrefs.GetString("email") != null)
        {
            email = PlayerPrefs.GetString("email");
        }
        btnTerminar = btnEnd.GetComponent<Button>();
        btnTerminar.onClick.AddListener(EndClass);
        anim = gameObject.GetComponent<Animator>();
        m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
        StartCoroutine(SolicitarTraduccion());
    }

    private void Awake()
    {
        animLSM.Add("a", "letra_a");
        animLSM.Add("b", "letra_b");
        animLSM.Add("c", "letra_c");
        animLSM.Add("d", "letra_d");
        animLSM.Add("e", "letra_e");
        animLSM.Add("f", "letra_f");
        animLSM.Add("g", "letra_g");
        animLSM.Add("h", "letra_h");
        animLSM.Add("i", "letra_i");
        animLSM.Add("j", "letra_j");
        animLSM.Add("k", "letra_k");
        animLSM.Add("l", "letra_l");
        animLSM.Add("m", "letra_m");
        animLSM.Add("n", "letra_n");
        animLSM.Add("o", "letra_o");
        animLSM.Add("p", "letra_p");
        animLSM.Add("q", "letra_q");
        animLSM.Add("r", "letra_r");
        animLSM.Add("s", "letra_s");
        animLSM.Add("t", "letra_t");
        animLSM.Add("u", "letra_u");
        animLSM.Add("v", "letra_v");
        animLSM.Add("w", "letra_w");
        animLSM.Add("x", "letra_x");
        animLSM.Add("y", "letra_y");
        animLSM.Add("z", "letra_z");



        animLSM.Add("hola", "Hola");
        animLSM.Add("como_estar", "comoestas");
        animLSM.Add("historia", "historia");
        animLSM.Add("hoy", "hoy");
        animLSM.Add("clase", "clase");
        animLSM.Add("que", "que");
        animLSM.Add("qué", "que");

        animLSM.Add("guerra", "guerra");
        animLSM.Add("independencia", "independencia");
        animLSM.Add("niño", "niño");
        animLSM.Add("mujer", "mujer");
        animLSM.Add("méxico", "mexico");
        animLSM.Add("hidalgo", "hidalgo");
        animLSM.Add("allende", "allende");
        animLSM.Add("Allende", "allende");
        animLSM.Add("hombre", "hombre");
        animLSM.Add("estudiar", "estudiar");
        animLSM.Add("hacer", "hacer");
        animLSM.Add("tema", "tema");
        animLSM.Add("preguntar", "preguntar");
        animLSM.Add("esclavo", "esclavo");
        animLSM.Add("esclavizar", "esclavo");
        animLSM.Add("esclavitud", "esclavo");

        animLSM.Add("inicio", "empezar");
        animLSM.Add("iniciar", "empezar");
        animLSM.Add("ir_a_iniciar", "empezar");
        animLSM.Add("comenzar", "empezar");
        animLSM.Add("empezar", "empezar");

        animLSM.Add("libro", "libro");
        animLSM.Add("abrir_libro", "libro");
        animLSM.Add("video", "video ");
        animLSM.Add("no", "no");
        animLSM.Add("cuál", "cual");
        animLSM.Add("español", "españoles");
        animLSM.Add("llegar", "llegar");
        animLSM.Add("oprimir", "oprimir");
        animLSM.Add("indigena", "indigena");

        animLSM.Add("atrapar", "atrapar");
        animLSM.Add("página", "página");
        animLSM.Add("salvar", "");
        animLSM.Add("participar", "participar");
        animLSM.Add("participación", "participar");
        animLSM.Add("pensar", "pensar");
        animLSM.Add("ideal", "pensar");
        animLSM.Add("tener", "tener");

        animLSM.Add("pensando", "pensar");
        animLSM.Add("mucho", "mucho");
        animLSM.Add("leer", "leer");
        animLSM.Add("adios", "adios");
        animLSM.Add("buenas_noches", "buenasNoches");
        animLSM.Add("buenos_días", "buenosDias");
        animLSM.Add("buenas_tardes", "buenasTardes");
        animLSM.Add("escribir", "escribir");
        animLSM.Add("explicar", "explicar");
        animLSM.Add("pasado", "pasado");
        animLSM.Add("anterior", "pasado");

        animLSM.Add("porque", "porque");
        animLSM.Add("ver", "ver");
        animLSM.Add("observar", "ver");
        animLSM.Add("después", "despues");
        animLSM.Add("luego", "despues");
        animLSM.Add("nuestro", "nuestro");
        animLSM.Add("pizarrón", "pizarrón");
        animLSM.Add("poner", "poner");
        animLSM.Add("recordar", "recordar");
        animLSM.Add("elegir", "elegir");
        animLSM.Add("cara", "cara");
        animLSM.Add("rostro", "cara");
        animLSM.Add("profesor", "maestro");
        animLSM.Add("maestro", "maestro");
        animLSM.Add("lengua_senas", "lenguaSenas");
        animLSM.Add("yo", "yo");
        animLSM.Add("num_ocho", "num_ocho");
        animLSM.Add("num_nueve", "num_nueve");
        animLSM.Add("num_sesenta", "num_sesenta");
        animLSM.Add("num_setenta", "num_setenta");
        animLSM.Add("num_cien", "num_cien");
        animLSM.Add("gracias", "gracias");



        animLSM.Add("sin traduccion", "sin traduccion");

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
        if (movimientos != null && movimientos.Length > 0)
        {          
                for (int i = 0; i <= movimientos.Length - 1; i++)
                {

                    if (i != 0)
                    {
                        yield return StartCoroutine(AvatarMov(movimientos[i]));
                }
                    else
                    {
                        yield return StartCoroutine(AvatarMov(movimientos[i]));
                    }
                }
            Debug.Log("sali del for");
            StartCoroutine(SolicitarTraduccion());
        }

        else
        {
            anim.Play("sin traduccion");
            StartCoroutine(SolicitarTraduccion());

        }
    }

    IEnumerator AvatarMov(string mov)
    {
        Debug.Log("entre al if con:" + mov);
        if (mov != null && anim != null )
        {
            Debug.Log("entre avatarMov");

            string animName = "";
            if (animLSM.TryGetValue(mov, out animName))
            {
                anim.Play(animName, 0,0f);
                yield return 0;
                m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                yield return new WaitForSeconds(m_CurrentClipInfo[0].clip.length);


            }
            else 
            {
                yield return 0;
                m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);
                float tiempo = this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime;

                if (tiempo > 0.95f)
                {
                    anim.Play("sin traduccion");
                    m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);

                    yield return new WaitForSeconds(m_CurrentClipInfo.Length);
                }
                else
                {
                    yield return 0;

                }
            }
         

        }
      
    }


    IEnumerator SolicitarTraduccion()
    {
        Debug.Log("solicitando traduccion");

        WWWForm form = new WWWForm();
        form.AddField("codigo", codigo);
        form.AddField("correo", email);
        UnityWebRequest webRequest = UnityWebRequest.Post("http://40.117.101.140:5000/recibirTraduccion", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            //Se toma este array para pruebas sin el servidor
            //las palabras del array deben estar en el diccionario
            //cada Palabra esta asociada a un anim
            string[] prueba = { "yo","maestro","lengua_senas","num_cien","num_ocho","num_nueve","num_sesenta","num_setenta"};
            yield return StartCoroutine(Movimientos(prueba));

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
        SSTools.ShowMessage("Nos vemos", SSTools.Position.bottom, SSTools.Time.twoSecond);

        UnityWebRequest www = UnityWebRequest.Post("http://40.117.101.140:5000/clase", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            SSTools.ShowMessage(www.error, SSTools.Position.bottom, SSTools.Time.twoSecond);
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
                SSTools.ShowMessage("Upps hubo un error", SSTools.Position.bottom, SSTools.Time.twoSecond);
            }
        }
    }
}