using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class characterHealth : MonoBehaviour {
    public Text myHealthText;
    public float currentHealth { get; set; }
public float MaxHealth { get; set; }


    public Slider healthbar;
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 100f;
        
        currentHealth = MaxHealth;
        
        healthbar.value = CalculateHealth();
        HealthText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(6);
            Debug.Log(currentHealth);
            HealthText();
        }
            
    }
    void DealDamage (float damageValue)
    {
        currentHealth -= damageValue;
        healthbar.value = CalculateHealth();

        if (currentHealth <= 0)
        Die();
    }

    float CalculateHealth()
    {
        return currentHealth / MaxHealth;
    }

    void Die()
    {
        currentHealth = 0;
        Debug.Log("You died.");
    }
    public void HealthText()
    {
       // myHealthText = GameObject.Find("Text").GetComponent<Text>();
        // here the variable myText reference to the game Object MainText

        myHealthText.text = currentHealth.ToString() + " / " + MaxHealth.ToString() + " Health";

    }
}

