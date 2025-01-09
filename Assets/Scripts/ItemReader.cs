using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemReader : MonoBehaviour
{
    [SerializeField]private Item _item;
    
    [Header("Display Settings")]
    [SerializeField]private Image _iconOfItems;
    [SerializeField]private TextMeshProUGUI _nameOfItems;
    [SerializeField]private TextMeshProUGUI _numberOfItemsText;
    [SerializeField]private int _numberOfItems;
    [SerializeField]private TextMeshProUGUI _DescriptionOfItems;
    [SerializeField]private TextMeshProUGUI _buttonText;
    
    [Header("Button Settings")]
    [SerializeField] private int _price;
    [SerializeField] private Image _itemImage;
    [SerializeField] private bool _isFirstPurchase;
    private Button _button;
    
    private void Awake()
    {
        _button = GetComponentInChildren<Button>();
    }
    void Start()
    {
        _button.interactable = false;
        _iconOfItems.sprite = _item.Icon;
        _nameOfItems.text= _item.ItemName;
        _numberOfItems =0;
        _numberOfItemsText.text = "x" +_numberOfItems.ToString("0");
        _DescriptionOfItems.text = _item.Description;
        _buttonText.text = _price.ToString();
    }
    
    void Update()
    {
        // Makes the button interactable only if the player has enough money
        if (_button.interactable != true && ResourceManager.Instance.GetMoney()!=0 && ResourceManager.Instance.GetMoney() >= _price)
        {
            _button.interactable = true;
        }
        else if (ResourceManager.Instance.GetMoney() < _price)
        {
            _button.interactable = false;
        }
    }

    private void RefreshItemDisplay()
    {
        _numberOfItemsText.text = "x" +_numberOfItems.ToString();
        _buttonText.text = _price.ToString();
    }
    //Manages the purchase/upgrade of items in the shop
    public void Upgrade()
    {
        //Remove the money
        ResourceManager.Instance.UpdateMoney(-_price);
        // adds +1 item
        _numberOfItems ++;
        // increment price depending on rarity
        switch (_item.Rarity)
        {
            case Rarity.Common:
                _price += _item.Price * _numberOfItems * 9/7;
                break;
            case Rarity.Uncommon:
                _price += _item.Price * _numberOfItems * 12/7;
                break;
            case Rarity.Rare:
                _price += _item.Price * _numberOfItems * 3;
                break;
            case Rarity.Legendary:
                _price += _item.Price * _numberOfItems * 7;
                break;
        }
        
        //Display item
        RefreshItemDisplay();
        if (_isFirstPurchase)
        {
            _itemImage.color = new Color(1f, 1f, 1f, 1f);
            _isFirstPurchase = false;
        }
        
        //Increments or multiplies the rewards depending on
        //the type of resource, type of upgrade (+,*) and auto click (true,false)
        //
        switch (_item.ResourceType)
            {
                case TypeOfResource.IronOre:
                    if (_item.UpgradeType == TypeOfUpgrade.Incremental)
                    {
                        ResourceManager.Instance.SetIronOreIncrease(ResourceManager.Instance.GetIronOreIncrease() +
                                                                    _item.UpgradePower);
                    }
                    else
                    {
                        ResourceManager.Instance.SetIronOreIncrease(ResourceManager.Instance.GetIronOreIncrease() *
                                                                    _item.UpgradePower);
                    }

                    break;
                case TypeOfResource.Iron:
                    if (_item.UpgradeType == TypeOfUpgrade.Incremental)
                    {
                        ResourceManager.Instance.SetIronIncrease(ResourceManager.Instance.GetIronIncrease() +
                                                                 _item.UpgradePower);
                    }
                    else
                    {
                        ResourceManager.Instance.SetIronIncrease(ResourceManager.Instance.GetIronIncrease() *
                                                                 _item.UpgradePower);
                    }

                    break;
                case TypeOfResource.Sword:
                    if (_item.UpgradeType == TypeOfUpgrade.Incremental)
                    {
                        ResourceManager.Instance.SetSwordIncrease(ResourceManager.Instance.GetSwordIncrease() +
                                                                  _item.UpgradePower);
                    }
                    else
                    {
                        ResourceManager.Instance.SetSwordIncrease(ResourceManager.Instance.GetSwordIncrease() *
                                                                  _item.UpgradePower);
                    }

                    break;
                case TypeOfResource.Money:
                    if (_item.UpgradeType == TypeOfUpgrade.Incremental)
                    {
                        ResourceManager.Instance.SetMoneyIncrease(ResourceManager.Instance.GetMoneyIncrease() +
                                                                  _item.UpgradePower);
                    }
                    else
                    {
                        ResourceManager.Instance.SetMoneyIncrease(ResourceManager.Instance.GetMoneyIncrease() *
                                                                  _item.UpgradePower);
                    }
                    break;
                case TypeOfResource.All :
                    if (_item.UpgradeType == TypeOfUpgrade.Incremental)
                    {
                        if (_item.AutoClick)
                        {
                            ResourceManager.Instance.SetAutoClickPower(ResourceManager.Instance.GetAutoClickPower()+_item.UpgradePower);
                        }
                        else
                        {
                            ResourceManager.Instance.SetClickPower(ResourceManager.Instance.GetClickPower()+_item.UpgradePower);
                        }
                    }
                    else
                    {
                        if (_item.AutoClick)
                        {
                            ResourceManager.Instance.SetAutoClickPower(ResourceManager.Instance.GetAutoClickPower()*_item.UpgradePower);
                        }
                        else
                        {
                            ResourceManager.Instance.SetClickPower(ResourceManager.Instance.GetClickPower()*_item.UpgradePower);
                        }
                    }
                    break;
                case TypeOfResource.Bonus :
                    if (_item.UpgradeType == TypeOfUpgrade.Incremental)
                    {
                        if (_item.AutoClick)
                        {
                            ResourceManager.Instance.SetAutoClickPowerMultiplier(ResourceManager.Instance.GetAutoClickPowerMultiplier()+_item.UpgradePower);
                        }
                        else
                        {
                            ResourceManager.Instance.SetClickPowerMultiplier(ResourceManager.Instance.GetClickPowerMultiplier()+_item.UpgradePower);
                        }
                    }
                    else
                    {
                        if (_item.AutoClick)
                        {
                            ResourceManager.Instance.SetAutoClickPowerMultiplier(ResourceManager.Instance.GetAutoClickPowerMultiplier()*_item.UpgradePower);
                        }
                        else
                        {
                            ResourceManager.Instance.SetClickPowerMultiplier(ResourceManager.Instance.GetClickPowerMultiplier()*_item.UpgradePower);
                        }
                    }
                    break;
            }
    }
}
