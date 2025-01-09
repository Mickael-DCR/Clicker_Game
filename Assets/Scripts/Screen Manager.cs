using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _shopOpenButton;
    [SerializeField] private GameObject _shopCloseButton;

    public void OpenShop()
    {
        _shopPanel.SetActive(true);
        _shopOpenButton.SetActive(false);
        _shopCloseButton.SetActive(true);
    }

    public void CloseShop()
    {
        _shopOpenButton.SetActive(true);       
        _shopCloseButton.SetActive(false);
        _shopPanel.SetActive(false);
    }
}
