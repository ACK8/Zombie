using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : SingletonMonoBehaviour<Menu>
{
    [SerializeField]
    private string titleSceneName = null;

    private GameObject vrCamEye;

    void Start()
    {
        vrCamEye = GameObject.Find("Camera (eye)");
        gameObject.SetActive(false);
        
    }

    void Update()
    {
        if (!vrCamEye)
        {
            Debug.LogError("vrCamEyeがありません");
        }
    }

    public void IsDisplayed(bool f)
    {
        if (f)
        {
            Vector3 d = vrCamEye.transform.forward;
            d.y = 0.0f;
            d.Normalize();

            gameObject.SetActive(true);

            transform.position = vrCamEye.transform.position + d * 1.5f;
            transform.rotation = vrCamEye.transform.rotation;
            transform.LookAt(vrCamEye.transform);
        }
        else
        {
            gameObject.SetActive(false);
        }
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void BackToTitle()
    {
        print("BackToTitle");
        //SceneManager.LoadScene(titleSceneName);
    }
}
