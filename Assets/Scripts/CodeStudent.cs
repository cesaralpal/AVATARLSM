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
    public GameObject edtEmail;

    public GameObject btnLog;

    public Button btnIngresar;

    private string Codigo;
    private string Email;

    public const string MatchEmailPattern =
     @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


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
        Email = edtEmail.GetComponent<InputField>().text;

        if (Codigo == "" || Email == "")
        {
            SSTools.ShowMessage("No dejes ningún campo vació", SSTools.Position.bottom, SSTools.Time.threeSecond);

        }
        else if (validateEmail(Email) && Codigo != "") {

            PlayerPrefs.SetString("codigo", Codigo);
            PlayerPrefs.SetString("email", Email);
            StartCoroutine(Upload(Codigo, Email));

        }
        else SSTools.ShowMessage("Escribe un correo válido", SSTools.Position.bottom, SSTools.Time.threeSecond); 
    }
    IEnumerator Upload(string Codigo, string Email)
    {
        WWWForm form = new WWWForm();
        form.AddField("codigo", Codigo);
        form.AddField("tipo", "alumno");
        form.AddField("accion", "entrar");
        form.AddField("correo", Email);

        UnityWebRequest www = UnityWebRequest.Post("http://137.135.88.10:5000/clase", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            CodeResponse myCodeClass = JsonUtility.FromJson<CodeResponse>(www.downloadHandler.text);
            Debug.Log(www.downloadHandler.text);

            if (myCodeClass.mensaje == "Bienvenido")
            {
                SceneManager.LoadScene("Avatar");
            }
            else {
                SSTools.ShowMessage("Tu código no esta asociado a ningun maestro",SSTools.Position.bottom,SSTools.Time.threeSecond);

            }
        }
    }

    public static bool validateEmail(string email)
    {
        if (email != null)
            return Regex.IsMatch(email, MatchEmailPattern);
        else
            return false;
    }

}