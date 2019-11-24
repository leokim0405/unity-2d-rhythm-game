using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    private FirebaseAuth auth;

    public InputField emailInputField;
    public InputField passwordInputField;

    public Text messageUI;
    // Start is called before the first frame update

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        messageUI.text = "";
    }

    public void Login()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(
            task =>
            {
                if (task.IsCompleted && !task.IsCanceled && !task.IsFaulted)
                {
                    PlayerInformation.auth = auth;
                    Debug.Log("Login success");
                    SceneManager.LoadScene("SongSelectScene");
                }
                else
                {
                    Debug.Log("Login failed");
                    messageUI.text = "계정을 다시 확인해 주세요";
                }
            }
            );
    }

    public void GoToJoin()
    {
        SceneManager.LoadScene("JoinScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
