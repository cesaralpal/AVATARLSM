using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveResult : MonoBehaviour {

    public string codigo;
    private string oracion;


    // Use this for initialization
    void Start () {
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

    IEnumerator Upload(string codigo,string oracion)
    {
        WWWForm form = new WWWForm();
        form.AddField("codigo", codigo);
        form.AddField("oracion", oracion);
        SSTools.ShowMessage("entre al resquest", SSTools.Position.bottom, SSTools.Time.twoSecond);


        UnityWebRequest www = UnityWebRequest.Post("http://40.86.95.152:5000/traduccion", form);
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
}
