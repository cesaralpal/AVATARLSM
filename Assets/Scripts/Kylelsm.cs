using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// Press the space key in Play Mode to switch to the Bounce state.

public class Kylelsm : MonoBehaviour
{
    public Animator anim;
    public bool get;

    void Start()
    {
        Debug.Log("inicie el script");

        anim = GetComponent<Animator>();
        StartCoroutine(GetRequest());

        //InvokeRepeating("GetRequest",0.1f,1f);

    }

    private void Awake()
    {
      // StartCoroutine(GetRequest());

    }

    void Update()
    {
       // StartCoroutine(GetRequest());

    }

    IEnumerator Movimientos(string[] movimientos)
    {

        Debug.Log(movimientos);

        if (movimientos != null)
        {
            Debug.Log("Soy diferente de nulo");

            for (int i = 0; i <= movimientos.Length; i++)
            {
                Debug.Log("longitu de movimientos" + movimientos.Length);
                Debug.Log("numero de ciclo: " + i);

                if (i != 0)
                {
                    Debug.Log("Soy diferente de 0");

                    if (movimientos[i - 1] != movimientos[i])
                    {
                        Debug.Log("soy difente de la primera:" + movimientos[i]);

                        
                        yield return StartCoroutine(AvatarMov(movimientos[i]));


                    }

                    else
                    {
                        Debug.Log("voy a enviar default");

                        StartCoroutine(AvatarMov("default"));

                    }

                }
                else
                {
                    yield return StartCoroutine(AvatarMov(movimientos[i]));


                }



            }
        }

        else {
            StartCoroutine(GetRequest());
            yield return 0;
        }
    }

     IEnumerator AvatarMov(string mov)
    {
        Debug.Log("entre al if con:" + mov);

        if (mov =="cama")
        {
            if (null != anim)
            {


                // play Bounce but start at a quarter of the way though
                anim.Play("Armature|Hola", 0, 0.0f);

                
            }
        }

        if (mov == "suave")
        {
            if (null != anim)
            {
                // play Bounce but start at a quarter of the way though
                anim.Play("WalkRM", 0, 0.25f);
            }
        }

        else if (Input.GetKeyDown(KeyCode.B))
        {
            if (null != anim)
            {
                // play Bounce but start at a quarter of the way though
                anim.Play("buenas tardes", 0, 0.25f);
                // StartCoroutine(GetRequest());
            }
        }

        else if (mov == "default")
        {
            if (null != anim)
            {
                // play Bounce but start at a quarter of the way though
                anim.Play("buenas tardes", 0, 0.25f);
                //StartCoroutine(GetRequest());
            }
        }

        else {
            StartCoroutine(GetRequest());
            yield return null;
        }


    }



    IEnumerator GetRequest()
    {
        Debug.Log("entre al request");
            using (UnityWebRequest webRequest = UnityWebRequest.Get("http://40.86.95.152:5000/traduccion"))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

            //string[] pages = "http://40.86.95.152:5000".Split('/');
            //int page = pages.Length - 1;
             AvatarWords words = JsonUtility.FromJson<AvatarWords>(webRequest.downloadHandler.text);
           // AvatarWords objects = JsonHelper.getJsonArray<AvatarWords>(webRequest.downloadHandler.text);



            if (webRequest.isNetworkError)
                {
                   // Debug.Log(pages[page] + ": Error: " + webRequest.error);
                }
                else
                {
                Debug.Log("entre al get y este es el arreglo" + words.traduccion.Length);
                yield return StartCoroutine(Movimientos(words.traduccion));


                // SSTools.ShowMessage(myCodeClass.mensaje[0], SSTools.Position.bottom, SSTools.Time.threeSecond);

                // Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }

 
}