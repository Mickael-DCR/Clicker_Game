using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceReader : MonoBehaviour
{
    [SerializeField] private WeightedList<Resource> _resourceList;
    [SerializeField] private Image _resourceImage;
    [SerializeField] private Image _hpImage;
    [SerializeField] private TextMeshProUGUI _resourceAmountOnKill;
    [SerializeField] private TextMeshProUGUI _resourceName;
    [SerializeField] private TextMeshProUGUI _resourceHP;
    [SerializeField] private Image _rarityIndicator;
    private Resource _currentResource;
    private float _currentHP;
    void Start()
    {
        ReadResource(_resourceList.GetRandomElement());
    }

    private void ReadResource(Resource newResource)
    {
        _currentResource = newResource;
        _currentHP = _currentResource.ResourceHP;
        _resourceName.text = _currentResource.Rarity.ToString("") + " " + _currentResource.ResourceName;
        _resourceAmountOnKill.text="On kill : "+_currentResource.AmountOnKill.ToString("0000")+" Ores";
        _resourceHP.text= "HP : "+ _currentHP.ToString("0000") + " / "+_currentResource.ResourceHP.ToString("0000");
        _resourceImage.sprite = _currentResource.Sprite;
        switch (_currentResource.Rarity)
        {
            case Rarity.Common:
                _rarityIndicator.color = new Color32(85, 79, 79, 255);
                break;
            case Rarity.Uncommon:
                _rarityIndicator.color = new Color32(33, 132, 0, 255);
                break;
            case Rarity.Rare:
                _rarityIndicator.color = new Color32(7, 11, 67, 255);
                break;
            case Rarity.Legendary:
                _rarityIndicator.color = new Color32(137, 108, 7, 255);
                break;
        }
    }
    
    public void MineResource()
    {
        ResourceManager.Instance.UpdateIronOre(1);
        _currentHP -= ResourceManager.Instance.GetClickPower();
        _resourceHP.text= "HP : "+ _currentHP.ToString("0000") + " / "+_currentResource.ResourceHP.ToString("0000");
        _hpImage.fillAmount = _currentHP / _currentResource.ResourceHP;
        
        if( _currentHP <= 0 )
        {
            ResourceManager.Instance.UpdateIronOre(_currentResource.AmountOnKill);
            ReadResource(_resourceList.GetRandomElement());
        }
    }
    
}
