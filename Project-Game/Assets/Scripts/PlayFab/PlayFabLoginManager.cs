using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayFabLoginManager : MonoBehaviour
{
    const string LAST_EMAIL_KEY = "LAST_EMAIL", LAST_PASSWORD_KEY = "LAST_PASSWORD";

    [Header("Login Feedback UI:")]
    [SerializeField] GameObject loginSuccessObject;
    [SerializeField] GameObject loginErrorObject;

    #region Register
    [Header("Register UI:")]
    [SerializeField] TMP_InputField registerEmail;
    [SerializeField] TMP_InputField registerUsername;
    [SerializeField] TMP_InputField registerPassword;

    public void OnRegisterPressed()
    {
        Register(registerEmail.text, registerUsername.text, registerPassword.text);
    }

    public void Register(string email, string username, string password)
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest()
        {
            Email = email,
            DisplayName = username,
            Password = password,
            RequireBothUsernameAndEmail = false
        },
        successResult => Login(email, password),
        PlayFabFailure);
    }
    #endregion

    #region Login
    [Header("Login UI:")]
    [SerializeField] TMP_InputField loginEmail;
    [SerializeField] TMP_InputField loginPassword;

    public void OnLoginPressed()
    {
        Login(loginEmail.text, loginPassword.text);
    }

    public void Login(string email, string password)
    {
        PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest()
        {
            Email = email,
            Password = password,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams()
            {
                GetPlayerProfile = true
            }
        },
        successResult =>
        {
            PlayerPrefs.SetString(LAST_EMAIL_KEY, email);
            PlayerPrefs.SetString(LAST_PASSWORD_KEY, password);
            PlayerPrefs.SetString("Username", successResult.InfoResultPayload.PlayerProfile.DisplayName);

            Debug.Log("Successfully Logged In User: " + PlayerPrefs.GetString("Username"));

            loginSuccessObject.SetActive(true);
            StartCoroutine(LoadMainMenuAfterDelay());
        },
        PlayFabFailure);
    }
    #endregion

    IEnumerator LoadMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1); // Assicurati che la scena 1 sia il Main Menu
    }

    IEnumerator ShowLoginError()
    {
        loginErrorObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        loginErrorObject.SetActive(false);
    }

    public void PlayFabFailure(PlayFabError error)
    {
        Debug.Log(error.Error + " : " + error.GenerateErrorReport());
        StartCoroutine(ShowLoginError());
    }
}