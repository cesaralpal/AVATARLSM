using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class LoginTeacher: MonoBehaviour
{

    public GameObject email;
    public GameObject login;
    public Button logTeacher;
    private string Email;

    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


    // Start is called before the first frame update
    void Start()
    {
        logTeacher = login.GetComponent<Button>();
        logTeacher.onClick.AddListener(validateLogin);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void validateLogin()
    {
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

        UnityWebRequest www = UnityWebRequest.Post("http://137.135.88.10:5000/codigo", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            MyCodeClass myCodeClass = JsonUtility.FromJson<MyCodeClass>(www.downloadHandler.text);
            Debug.Log(www.downloadHandler.text);

            if (www.downloadHandler.isDone) {
                PlayerPrefs.SetString("codigo",myCodeClass.codigo);
                SceneManager.LoadScene("Voice");
            }
            else
            {
                Debug.Log("false");

                SSTools.ShowMessage("Upps hubo un error", SSTools.Position.bottom, SSTools.Time.twoSecond);

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



