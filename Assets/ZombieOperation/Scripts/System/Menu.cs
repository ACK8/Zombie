using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : SingletonMonoBehaviour<Menu>
{
    [SerializeField]
    private GameObject[] nemuPanel;
    [SerializeField]
    private float offset = 2.0f;
    [SerializeField]
    private string titleSceneName = null;

    private GameObject vrCamEye;

    void Start()
    {
        vrCamEye = GameObject.Find("Camera (eye)");

        MenuSetActive(false);
    }

    void Update()
    {
        if (!vrCamEye)
        {
            Debug.LogError("vrCamEyeが見つかりません");
        }
    }

    public void IsDisplayed(bool f)
    {
        if (f)
        {
            Vector3 d = vrCamEye.transform.forward;
            d.y = 0.0f;
            d.Normalize();

            MenuSetActive(true);

            transform.position = vrCamEye.transform.position + d * offset;
            transform.rotation = vrCamEye.transform.rotation;
            transform.LookAt(vrCamEye.transform);

            Pauser.Pause();
        }
        else
        {
            MenuSetActive(false);
            Pauser.Resume();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void BackToTitle()
    {
        print("BackToTitle");
        SceneManager.LoadScene(titleSceneName);
    }

    void MenuSetActive(bool f)
    {
        foreach (GameObject nemu in nemuPanel)
        {
            nemu.SetActive(f);
        }
    }
}
