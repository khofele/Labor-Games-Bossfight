using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //access to the CharacterMovement script
    protected CharacterMovement charMovement;
    //weapon stats
    private string weaponType = ""; //type of weapon
    private float weaponMinDmg = 0f; //minimum damage the weapon makes

    // Start is called before the first frame update
    void Start()
    {
        charMovement = gameObject.GetComponentInParent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //--------------------------GETTER FOR DRAGON & CHAR-----------------------

    //Setter for the weapon values
    //TODO SetValues() - Call von Men� zum Setzen der Werte? (Call des jew. Waffenskripts zum Setzen der Werte)
    //TODO SetValues() - Methode �berhaupt ben�tigt??? oder setzt es das automatisch durch Vererbung?
    public void SetValues(string weaponTypeValue, float weaponMinDmgValue)
    {
        weaponType = weaponTypeValue;
        weaponMinDmg = weaponMinDmgValue;
    }
    public string GetWeaponType()
    {
        return weaponType;
    }

    public float GetWeaponMinDmg()
    {
        //determine weaponMinDmg regarding the characters attack power
        weaponMinDmg = weaponMinDmg + charMovement.GetAttackPower();
        return weaponMinDmg;
    }
}
