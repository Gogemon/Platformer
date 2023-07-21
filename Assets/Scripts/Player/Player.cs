using UnityEngine;

[RequireComponent(typeof(BackgroundController))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _money;

    public int Money { get { return _money; } }

    public void TakeMoney(int money)
    {
        _money += money;
    }
}
