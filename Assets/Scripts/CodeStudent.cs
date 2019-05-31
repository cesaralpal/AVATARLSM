using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class CodeStudent : MonoBehaviour
{

    public GameObject edtCode;
    public GameObject btnLog;
    public Button btnIngresar;
    private string Codigo;

       // Start is called before the first frame update
    void Start()
    {
        btnIngresar = btnLog.GetComponent<Button>();
        btnIngresar.onClick.AddListener(validateLogin);

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void validateLogin()
    {
        Codigo = edtCode.GetComponent<InputField>().text;

        if (Codigo == "") {
            SSTools.ShowMessage("Por favor escribe un código", SSTools.Position.bottom, SSTools.Time.threeSecond);

        }
        else StartCoroutine(Upload(Codigo));
    }
    IEnumerator Upload(string Codigo)
    {
        WWWForm form = new WWWForm();
        form.AddField("codigo", Codigo);

        UnityWebRequest www = UnityWebRequest.Post("http://40.86.95.152:5000/entrarClase", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            CodeResponse myCodeClass = JsonUtility.FromJson<CodeResponse>(www.downloadHandler.text);
            Debug.Log(www.downloadHandler.text);

            if (myCodeClass.mensaje == "Correcto")
            {
                SceneManager.LoadScene("Avatar");
            }
            else {
                SSTools.ShowMessage("Tu código no esta asociado a ningun maestro",SSTools.Position.bottom,SSTools.Time.threeSecond);

            }
        }
    }


 
}