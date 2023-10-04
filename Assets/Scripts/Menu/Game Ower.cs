using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOwer : MonoBehaviour
{
    [SerializeField] private GameObject _gameOwerMenu;

    private Image _backGround;

    private void Start()
    {
        _backGround = _gameOwerMenu.GetComponent<Image>();
    }

    public void PlayerDead()
    {
        _gameOwerMenu.SetActive(true);
        StartCoroutine(ChangeFoneColor());

    }

    public void OnClickRestartButton()
    {
    }

    private IEnumerator ChangeFoneColor()
    {
        float targetAlpha = 1f;
        float speedChange = 5;

        while (true)
        {
            float alpha = Mathf.Lerp(_backGround.color.a, targetAlpha, speedChange * Time.deltaTime);

            Color newColor = _backGround.color;
            newColor.a = alpha;
            _backGround.color = newColor;

            yield return null;
        }
    }
}
