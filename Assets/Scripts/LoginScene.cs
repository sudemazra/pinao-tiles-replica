using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class LoginScene : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public Button loginButton;
    public TextMeshProUGUI feedbackText;

    void Start()
    {
        loginButton.onClick.AddListener(OnLoginButtonClicked);
    }
    void LoginButton()
    {
        SceneManager.LoadScene(1);
    }
    void OnLoginButtonClicked()
    {
        string username = usernameInput.text;
        if (string.IsNullOrEmpty(username))
        {
            feedbackText.text = "Lütfen bir kullanýcý adý girin!";
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", username); // Adý saklayýn
            // Kullanýcý adý baþarýlý þekilde alýndý. Burada veritabanýna baðlanabiliriz.
            feedbackText.text = "Hoþgeldin, " + username;
            // Burada skoru veritabanýna ekleyebiliriz.
            Invoke("LoginButton", 2);
        }
    }
}

