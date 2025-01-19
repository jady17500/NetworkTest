using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class UIManager : MonoBehaviour
{

    public GameObject owner;
    public Image healthBarImage;
    public List<GameObject> modes;
    public TextMeshProUGUI deathText;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetOwner(GameObject newOwner)
    {
        owner = newOwner;
    }

    public void SetHealth(float newHealth)
    {
        healthBarImage.fillAmount = newHealth;
        print("Health Changed");
    }

    public void SwitchMode(int mode)
    {
        foreach (var uiMode in modes)
        {
           uiMode.SetActive(false); 
        }
        
        modes[mode].SetActive(true);
    }

    public void UpdateDeathText(int time)
    {
        deathText.text = time.ToString();
    }
    
    
}
