using System.Collections;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    private int _ironOre;
    private int _iron;
    private int _money;
    private int _sword;
    
    [Header("Clicks")]
    [SerializeField] private int _clickPower;
    [SerializeField] private int _clickPowerMultiplier;
    [Header("AutoClicks")]
    [SerializeField] private float _autoClickDelay;
    [SerializeField] private int _autoClickPower;
    [SerializeField] private int _autoClickPowerMultiplier;
    [Header("Resource Specifics")]
    [SerializeField] private int _ironOreIncrease;
    [SerializeField] private int _ironIncrease;
    [SerializeField] private int _swordIncrease;
    [SerializeField] private int _moneyIncrease;
    [Header("Activate Auto Clicks")]
    public bool AutoIronOre;
    public bool AutoIron;
    public bool AutoSword;
    public bool AutoMoney;
    [Header("Resources")] 
    [SerializeField] private TextMeshProUGUI _moneyCounter;
    [SerializeField] private TextMeshProUGUI _ironOreCounter;
    [SerializeField] private TextMeshProUGUI _ironCounter;
    [SerializeField] private TextMeshProUGUI _swordCounter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(AutoClicks());
    }
    
    // GETTER
    //
    public int GetMoney()
    {
        return _money;
    }

    public int GetIronOreIncrease()
    {
        return _ironOreIncrease;
    }

    public int GetIronIncrease()
    {
        return _ironIncrease;
    }

    public int GetSwordIncrease()
    {
        return _swordIncrease;
    }

    public int GetMoneyIncrease()
    {
        return _moneyIncrease;
    }

    public int GetClickPower()
    {
        return _clickPower;
    }

    public int GetClickPowerMultiplier()
    {
        return _clickPowerMultiplier;
    }

    public int GetAutoClickPower()
    {
        return _autoClickPower;
    }

    public int GetAutoClickPowerMultiplier()
    {
        return _autoClickPowerMultiplier;
    }
    
    // SETTERS
    //
    public void SetClickPowerMultiplier(int power)
    {
        _clickPowerMultiplier = power;
    }
    public void SetClickPower(int power)
    {
        _clickPower = power;
    }

    public void SetAutoClickPowerMultiplier(int power)
    {
        _autoClickPowerMultiplier = power;
    }
    public void SetAutoClickPower(int power)
    {
        _autoClickPower = power;
    }
    public void SetAutoClickDelay(float delay)
    {
        _autoClickDelay = delay;
    }

    public void SetIronOreIncrease(int amount)
    {
        _ironOreIncrease = amount;
    }

    public void SetIronIncrease(int amount)
    {
        _ironIncrease = amount;
    }

    public void SetSwordIncrease(int amount)
    {
        _swordIncrease = amount;
    }

    public void SetMoneyIncrease(int amount)
    {
        _moneyIncrease = amount;
    }
    
    //Updates IronOre Counter on event
    //
    public void UpdateIronOre(int increase)
    {
        //Checks if it was trigger by :
        //Upgrade/Purchase
        if (increase < 0)
            _ironOre += increase;
        //Player click
        else _ironOre += (_ironOreIncrease + _clickPower)*_clickPowerMultiplier;
        //Updates display
        _ironOreCounter.text = "Iron ore : " + _ironOre.ToString("0");
    }
    
    //Updates Iron Counter
    //
    public void UpdateIron(int increase)
    {
        //Checks if it was trigger by :
        //Upgrade/Purchase
        if (increase < 0)
        {
            _iron += increase;
        }
        //Player click
        else
        {
            //If player has enough ores to smelt
            if (_ironOre >= _ironIncrease + _clickPower)
            {                
                //increases smelted iron by amount*multiplier (multiplier is free iron)
                _iron += (_ironIncrease + _clickPower)*_clickPowerMultiplier;
                //decreases the ore by amount
                _ironOre -= _ironIncrease + _clickPower;   
            }
            // if player has less than amount but 1 or more ore(s)
            else if (_ironOre >= 1 && _ironOre < _ironIncrease + _clickPower)
            {
                //smelts all remaining ores
                _iron+= _ironOre * _clickPowerMultiplier;
                _ironOre=0;
            }
        }
        //Updates display
        _ironCounter.text = "Iron Bars : " + _iron.ToString("0");
        _ironOreCounter.text = "Iron ore : " + _ironOre.ToString("0");
    }

    
    //Updates Sword Counter on event
    //
    public void UpdateSword(int increase)
    {
        //Checks if it was trigger by :
        //Upgrade/Purchase
        if (increase < 0)
            _sword += increase;
        //Player click
        else
        {
            //If player has enough ores to smelt
            if (_iron >= _swordIncrease + _clickPower)
            {                
                //increases smelted iron by amount*multiplier (multiplier is free iron)
                _sword += _swordIncrease + _clickPower*_clickPowerMultiplier;
                //decreases the ore by amount
                _iron -= _swordIncrease + _clickPower;   
            }
            // if player has less than amount but 1 or more ore(s)
            else if (_iron >= 1 && _iron < _swordIncrease + _clickPower)
            {
                //smelts all remaining ores
                _sword+= _iron * _clickPowerMultiplier;
                _iron=0;
            }
        }
        //Updates display
        _swordCounter.text = "Swords : " + _sword.ToString("0");
        _ironCounter.text = "Iron Bars : " + _iron.ToString("0");
    }
    //Updates Money Counter on event
    //
    public void UpdateMoney(int increase)
    {
        //Checks if it was trigger by :
        //Upgrade/Purchase
        if (increase < 0)
            _money += increase;
        //Player click
        else
        {
            //If player has enough swords to sell
            if (_sword >= _moneyIncrease + _clickPower)
            {                
                //increases smelted iron by amount*multiplier (multiplier is free money)
                _money += _moneyIncrease + _clickPower*_clickPowerMultiplier;
                //decreases the ore by amount
                _sword -= _moneyIncrease + _clickPower;   
            }
            // if player has less than amount but 1 or more ore(s)
            else if (_sword >= 1 && _sword < _moneyIncrease + _clickPower)
            {
                //smelts all remaining ores
                _money+= _sword * _clickPowerMultiplier;
                _sword=0;
            }
        }
        //Updates display
        _moneyCounter.text = "Money : " + _money.ToString("0");
        _swordCounter.text = "Swords : " + _sword.ToString("0");
    }

    

    private IEnumerator AutoClicks()
    {
        while (true)
        {
            if (AutoIron)
            {
                //If player has enough ores to smelt
                if (_ironOre >= _ironIncrease + _autoClickPower)
                {
                    //increases smelted iron by amount*multiplier (multiplier is free iron)
                    _iron += (_ironIncrease + _autoClickPower) * _autoClickPowerMultiplier;
                    //decreases the ore by amount
                    _ironOre -= _ironIncrease + _autoClickPower;
                }
                // if player has less than amount but 1 or more ore(s)
                else if (_ironOre >= 1 && _ironOre < _ironIncrease + _autoClickPower)
                {
                    //smelts all remaining ores
                    _iron += _ironOre * _autoClickPowerMultiplier;
                    _ironOre = 0;
                }

                _ironCounter.text = "Iron Bars : " + _iron.ToString("0");
                _ironOreCounter.text = "Iron ore : " + _ironOre.ToString("0");
            }

            if (AutoSword)
            {
                //If player has enough ingot to forge
                if (_iron >= _swordIncrease + _autoClickPower)
                {
                    //increases forged swords by amount*multiplier (multiplier makes free swords)
                    _sword +=(_swordIncrease + _autoClickPower) * _autoClickPowerMultiplier;
                    //decreases the iron by amount
                    _iron -= _swordIncrease + _autoClickPower;
                }
                // if player has less than amount but 1 or more ingot(s)
                else if (_iron >= 1 && _iron <_swordIncrease + _autoClickPower)
                {
                    //smelts all remaining ores
                    _sword += _iron * _autoClickPowerMultiplier;
                    _iron = 0;
                }

                _swordCounter.text = "Swords : " + _sword.ToString("0");
                _ironCounter.text = "Iron Bars : " + _iron.ToString("0");
            }

            if (AutoMoney)
            {
                //If player has enough swords to sell
                if (_sword >=_moneyIncrease + _autoClickPower)
                {
                    //increases money by amount*multiplier (multiplier makes free money hehe)
                    _money +=(_moneyIncrease + _autoClickPower) * _autoClickPowerMultiplier;
                    //decreases the ore by amount
                    _sword -= _moneyIncrease + _autoClickPower;
                }
                // if player has less than amount but 1 or more sword(s)
                else if (_sword >= 1 && _sword <_moneyIncrease + _autoClickPower)
                {
                    //sells all remaining swords
                    _money += _sword * _autoClickPowerMultiplier;
                    _sword = 0;
                }

                _moneyCounter.text = "Money : " + _money.ToString("0");
                _swordCounter.text = "Swords : " + _sword.ToString("0");
            }

            if (AutoIronOre)
            {
                _ironOre += (_ironOreIncrease + _autoClickPower) * _autoClickPowerMultiplier;
                _ironOreCounter.text = "Iron ore : " + _ironOre.ToString("0");
            }
            yield return new WaitForSecondsRealtime(_autoClickDelay);
        }
    }
}

