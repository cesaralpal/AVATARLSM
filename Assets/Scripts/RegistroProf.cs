using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;


public class RegistroProf : MonoBehaviour
{

    public GameObject email;
    public GameObject login;
    public Button btnRegistro;
    private string Email;
    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


    // Start is called before the first frame update
    void Start()
    {
        btnRegistro = login.GetComponent<Button>();
        btnRegistro.onClick.AddListener(validateLogin);

    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    private void validateLogin() {
        Email = email.GetComponent<InputField>().text;

        if (validateEmail(Email))
        {
            StartCoroutine(Upload(Email));
        }
        else {

            SSTools.ShowMessage("Ingresa un correo válido", SSTools.Position.bottom, SSTools.Time.twoSecond);

        }
    }
    IEnumerator Upload(string Email)
    {

        WWWForm form = new WWWForm();
        form.AddField("correo", Email);
        UnityWebRequest www = UnityWebRequest.Post("http://137.135.88.10:5000/registroProfesor", form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            SSTools.ShowMessage(www.error, SSTools.Position.bottom, SSTools.Time.oneSecond);

            Debug.Log(www.error);
        }
        else
        {

            RegistroResponse myCodeClass = JsonUtility.FromJson<RegistroResponse>(www.downloadHandler.text);
            Debug.Log(www.downloadHandler.text);

            if (myCodeClass.mensaje == "Registro exitoso")
            {
                SSTools.ShowMessage("Cambiar scene", SSTools.Position.bottom, SSTools.Time.oneSecond);

                SceneManager.LoadScene("LoginTeacher");
            }
            else {
                SSTools.ShowMessage("Algo salió mal", SSTools.Position.bottom, SSTools.Time.threeSecond);
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
