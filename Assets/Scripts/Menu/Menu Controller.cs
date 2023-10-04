using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _mainScene;
    [SerializeField] private GameObject _aboutAuthorsScene;

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickAboutAuthorsButton()
    {
        bool isMainSceneActive = _mainScene.activeSelf;

        _mainScene.SetActive(!isMainSceneActive);
        _aboutAuthorsScene.SetActive(isMainSceneActive);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
