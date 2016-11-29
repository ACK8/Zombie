using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private string titleSceneName = null;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SelectMenu(string name)
    {
        switch (name)
        {
            case "Restart":
                Restart();
                break;

            case "BackToTitle":
                BackToTitle();
                break;

            default:
                break;
        }
    }

    void Restart()
    {
        print("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void BackToTitle()
    {
        print("BackToTitle");
        SceneManager.LoadScene(titleSceneName);
    }
}
