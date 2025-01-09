using UnityEngine;
using TMPro;
public class ScreenManager : MonoBehaviour
{
    [Header("Shop Management")]
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _shopOpenButton;
    [SerializeField] private GameObject _shopCloseButton;
    [SerializeField] private TextMeshProUGUI _sellButtonText;
    [Header("Mine Management")]
    [SerializeField] private GameObject _minePanel;
    [SerializeField] private GameObject _mineOpenButton;
    [SerializeField] private GameObject _mineCloseButton;

    public void OpenShop()
    {
        _shopPanel.SetActive(true);
        _shopOpenButton.SetActive(false);
        _shopCloseButton.SetActive(true);
        _sellButtonText.text = "SELL UP TO " +
                               (ResourceManager.Instance.GetClickPower() +
                                ResourceManager.Instance.GetIronOreIncrease()).ToString("0000") 
                               + " SWORDS";

    }

    public void CloseShop()
    {
        _shopOpenButton.SetActive(true);       
        _shopCloseButton.SetActive(false);
        _shopPanel.SetActive(false);
    }

    public void OpenMine()
    {
        _mineOpenButton.SetActive(false);
        _mineCloseButton.SetActive(true);
        _minePanel.SetActive(true);
    }

    public void CloseMine()
    {
        _mineOpenButton.SetActive(true);
        _mineCloseButton.SetActive(false);
        _minePanel.SetActive(false);
    }
}
