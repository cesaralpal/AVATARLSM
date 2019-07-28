using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReceiveResult : MonoBehaviour {

    public string codigo;
    private string oracion;

    public GameObject btnEnd;
    public Button btnTerminar;

    // Use this for initialization
    void Start () {
        btnTerminar = btnEnd.GetComponent<Button>();
        btnTerminar.onClick.AddListener(EndClass);

        if (PlayerPrefs.GetString("codigo") != null) {
            GameObject.Find("codigo").GetComponent<Text>().text = PlayerPrefs.GetString("codigo");
            codigo = PlayerPrefs.GetString("codigo");

        }

        else GameObject.Find("codigo").GetComponent<Text>().text = "Hubo un problema";
    }
	
    void onActivityResult(string recognizedText){
        char[] delimiterChars = {'~'};
        string[] result = recognizedText.Split(delimiterChars);

        //You can get the number of results with result.Length
        //And access a particular result with result[i] where i is an int
        //I have just assigned the best result to UI text
        GameObject.Find("Text").GetComponent<Text>().text = result[0];
        StartCoroutine(Upload(codigo,result[0]));

        SSTools.ShowMessage(result[0] + codigo, SSTools.Position.bottom, SSTools.Time.twoSecond);

    }

    // Update is called once per frame
    void Update () {
		
	}
    void EndClass()
    {
        StartCoroutine(TerminarClase(codigo));
    }

    IEnumerator Upload(string codigo,string oracion)
    {
        WWWForm form = new WWWForm();
        form.AddField("codigo", codigo);
        form.AddField("oracion", oracion);
        SSTools.ShowMessage("entre al resquest", SSTools.Position.bottom, SSTools.Time.twoSecond);


        UnityWebRequest www = UnityWebRequest.Post("http://40.117.101.140:5000/enviarTraduccion", form);
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

                //SceneManager.LoadScene("Voice");
            }
            else
            {
                Debug.Log("false");

                SSTools.ShowMessage("Upps hubo un error", SSTools.Position.bottom, SSTools.Time.twoSecond);

            }
        }
    }

    IEnumerator TerminarClase(string codigo)
    {
        WWWForm form = new WWWForm();
        form.AddField("codigo", codigo);
        form.AddField("tipo", "profesor");
        form.AddField("accion", "terminar");
        form.AddField("correo", "loquesea");
        SSTools.ShowMessage("Nos vemos", SSTools.Position.bottom, SSTools.Time.twoSecond);

        UnityWebRequest www = UnityWebRequest.Post("http://40.117.101.140:5000/clase", form);
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
