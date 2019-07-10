using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;


public class RegistroAlumno : MonoBehaviour
{

    public GameObject email;
    public GameObject nameA;
    public GameObject apellidoM;
    public GameObject apellidoP;


    public GameObject registro;
    public Button btnRegistro;

    private string Email;
    private string Name;
    private string ApellidoP;
    private string ApellidoM;

    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


    // Start is called before the first frame update
    void Start()
    {
        btnRegistro = registro.GetComponent<Button>();
        btnRegistro.onClick.AddListener(validaRegistro);

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void validaRegistro()
    {
        Email = email.GetComponent<InputField>().text;
        Name = nameA.GetComponent<InputField>().text;
        ApellidoM = apellidoM.GetComponent<InputField>().text;
        ApellidoP = apellidoP.GetComponent<InputField>().text;

        if (validateEmail(Email) && Name!="" && ApellidoM!="" && ApellidoP!="")
        {
            StartCoroutine(Upload(Email,Name,ApellidoP,ApellidoM));
        }
        else
        {

            SSTools.ShowMessage("Ningún campo puede estar vacio o escribe un correo válido", SSTools.Position.bottom, SSTools.Time.threeSecond);

        }
    }
    IEnumerator Upload(string Email,string name, string apellidoP, string apellidoM)
    {

        WWWForm form = new WWWForm();
        form.AddField("nombre", name);
        form.AddField("apellidoP", apellidoP);
        form.AddField("apellidoM", apellidoM);
        form.AddField("correo", Email);

        UnityWebRequest www = UnityWebRequest.Post("http://137.135.88.10:5000/registroAlumno", form);

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

                SceneManager.LoadScene("StudentCode");
            }
            else
            {
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

