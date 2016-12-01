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
    private bool _isDisplayed = false;

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

    //メニュー表示の切り替え
    public void SwitchDisplay()
    {
        _isDisplayed = !_isDisplayed;
        if (_isDisplayed)
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

    public void PointMenu(string name)
    {
        switch (name)
        {
            case "Restart":
                Show_ScaleTo(nemuPanel[0], 0.1f);

                break;

            case "BackToTitle":
                Show_ScaleTo(nemuPanel[1], 0.1f);

                break;

            default:
                foreach (GameObject obj in nemuPanel)
                    Hide_ScaleTo(obj, 0.1f);
                break;
        }
    }

    //項目の選択
    public void SelectMenu(string name)
    {
        switch (name)
        {
            case "Restart":
                Restart();
                SwitchDisplay();
                break;

            case "BackToTitle":
                BackToTitle();
                SwitchDisplay();
                break;

            default:
                break;
        }
    }

    public bool isDisplayed
    {
        get { return _isDisplayed; }
    }

    void MenuSetActive(bool f)
    {
        foreach (GameObject nemu in nemuPanel)
        {
            nemu.SetActive(f);
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

    void Show_ScaleTo(GameObject obj, float time)
    {
        Hashtable hash = new Hashtable();
        hash.Add("x", 1.0f);
        hash.Add("z", 1.0f);
        hash.Add("time", time);
        hash.Add("ignoretimescale", true);
        hash.Add("easeType", iTween.EaseType.easeInOutSine);
        iTween.ScaleTo(obj.gameObject, hash);
    }

    void Hide_ScaleTo(GameObject obj, float time)
    {
        Hashtable hash = new Hashtable();
        hash.Add("x", 0.0f);
        hash.Add("z", 0.0f);
        hash.Add("time", time);
        hash.Add("ignoretimescale", true);
        hash.Add("easeType", iTween.EaseType.easeInOutSine);
        iTween.ScaleTo(obj.gameObject, hash);
    }
}
