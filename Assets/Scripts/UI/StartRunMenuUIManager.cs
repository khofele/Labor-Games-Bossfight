using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartRunMenuUIManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private SkillpointManager skillpointManager = null;
    [SerializeField] private AttributeManager attributeManager = null;
    [SerializeField] private ItemManager itemManager = null;

    [Header("Buttons")]
    [SerializeField] private Button btnBackToMainMenu = null;
    [SerializeField] private Button btnStartRun = null;
    [SerializeField] private Button btnAddVitality = null;
    [SerializeField] private Button btnRemoveVitality = null;
    [SerializeField] private Button btnAddEndurance = null;
    [SerializeField] private Button btnRemoveEndurance = null;
    [SerializeField] private Button btnAddStrength = null;
    [SerializeField] private Button btnRemoveStrength = null;
    [SerializeField] private Button btnAddPhysicalStrength = null;
    [SerializeField] private Button btnRemovePhysicalStrength = null;

    [Header("Stats")]
    [SerializeField] private GameObject textfieldVitality = null;
    [SerializeField] private GameObject textfieldEndurance = null;
    [SerializeField] private GameObject textfieldStrength = null;
    [SerializeField] private GameObject textfieldPhysicalStrength = null;
    [SerializeField] private TextMeshProUGUI txtSkillPoints = null;
    [SerializeField] private TextMeshProUGUI txtVitality = null;
    [SerializeField] private TextMeshProUGUI txtEndurance = null;
    [SerializeField] private TextMeshProUGUI txtStrength = null;
    [SerializeField] private TextMeshProUGUI txtPhysicalStrength = null;

    [Header("Attributes")]
    [SerializeField] private TextMeshProUGUI txtHealth = null;
    [SerializeField] private TextMeshProUGUI txtStamina = null;
    [SerializeField] private TextMeshProUGUI txtStaminaReg = null;
    [SerializeField] private TextMeshProUGUI txtCarryingCapacity = null;
    [SerializeField] private TextMeshProUGUI txtResistance = null;
    [SerializeField] private TextMeshProUGUI txtDefense = null;
    [SerializeField] private TextMeshProUGUI txtAttackPower = null;

    [Header("Equipment")]
    [SerializeField] private TextMeshProUGUI txtCarryingCapacityEquipment = null;
    [SerializeField] private TextMeshProUGUI txtPotionCount = null;
    [SerializeField] private Image imgEquippedWeapon = null;
    [SerializeField] private Image imgEquippedArmor = null;

    [Header("Items")]
    [SerializeField] private Button btnShortSword = null;
    [SerializeField] private Button btnLongSword = null;
    [SerializeField] private Button btnLance = null;
    [SerializeField] private Button btnHammer = null;
    [SerializeField] private Button btnDagger = null;
    [SerializeField] private Button btnClothArmor = null;
    [SerializeField] private Button btnLeatherArmor = null;
    [SerializeField] private Button btnIronArmor = null;
    [SerializeField] private Button btnPlateArmor = null;

    [Header("Player")]
    [SerializeField] private TextMeshProUGUI txtPlayerName = null;

    private float weight = 0f;
    private float armorWeight = 0f;
    private float weaponWeight = 0f;

    private void Start()
    {
        // manager
        attributeManager = FindObjectOfType<AttributeManager>();
        attributeManager.ResetAllAttributes();
        itemManager = FindObjectOfType<ItemManager>();
        itemManager.ResetWeaponAndArmor();
        skillpointManager = FindObjectOfType<SkillpointManager>();
        skillpointManager.ResetAllSkillpoints();

        // buttons
        btnBackToMainMenu.onClick.AddListener(BackToMainMenu);
        btnStartRun.onClick.AddListener(StartGame);
        btnStartRun.interactable = false;

        // stat buttons
        btnAddVitality.onClick.AddListener(skillpointManager.AddVitality);
        btnRemoveVitality.onClick.AddListener(skillpointManager.RemoveVitality);
        btnAddEndurance.onClick.AddListener(skillpointManager.AddEndurance);
        btnRemoveEndurance.onClick.AddListener(skillpointManager.RemoveEndurance);
        btnAddStrength.onClick.AddListener(skillpointManager.AddStrength);
        btnRemoveStrength.onClick.AddListener(skillpointManager.RemoveStrength);
        btnAddPhysicalStrength.onClick.AddListener(skillpointManager.AddPhysicalStrength);
        btnRemovePhysicalStrength.onClick.AddListener(skillpointManager.RemovePhysicalStrength);

        // armor buttons
        btnClothArmor.onClick.AddListener(itemManager.SetClothArmor);
        btnLeatherArmor.onClick.AddListener(itemManager.SetLeatherArmor);
        btnIronArmor.onClick.AddListener(itemManager.SetIronArmor);
        btnPlateArmor.onClick.AddListener(itemManager.SetPlateArmor);

        // weapon buttons
        btnShortSword.onClick.AddListener(itemManager.SetShortSword);
        btnLongSword.onClick.AddListener(itemManager.SetLongSword);
        btnHammer.onClick.AddListener(itemManager.SetHammer);
        btnLance.onClick.AddListener(itemManager.SetLance);
        btnDagger.onClick.AddListener(itemManager.SetDagger);

        //menu descriptions
        btnShortSword.GetComponent<SimpleTooltip>().InfoLeft = itemManager.ShortSwordDescription;
        btnLongSword.GetComponent<SimpleTooltip>().InfoLeft = itemManager.LongSwordDescription;
        btnHammer.GetComponent<SimpleTooltip>().InfoLeft = itemManager.HammerDescription;
        btnLance.GetComponent<SimpleTooltip>().InfoLeft = itemManager.LanceDescription;
        btnDagger.GetComponent<SimpleTooltip>().InfoLeft = itemManager.DaggerDescription;
        btnClothArmor.GetComponent<SimpleTooltip>().InfoLeft = itemManager.ClothArmorDescription;
        btnLeatherArmor.GetComponent<SimpleTooltip>().InfoLeft = itemManager.LeatherArmorDescription;
        btnIronArmor.GetComponent<SimpleTooltip>().InfoLeft = itemManager.IronArmorDescription;
        btnPlateArmor.GetComponent<SimpleTooltip>().InfoLeft = itemManager.PlateArmorDescription;
        textfieldVitality.gameObject.GetComponent<SimpleTooltip>().InfoLeft = skillpointManager.VitalityDescription;
        textfieldEndurance.gameObject.GetComponent<SimpleTooltip>().InfoLeft = skillpointManager.EnduranceDescription;
        textfieldStrength.gameObject.GetComponent<SimpleTooltip>().InfoLeft = skillpointManager.StrengthDescription;
        textfieldPhysicalStrength.gameObject.GetComponent<SimpleTooltip>().InfoLeft = skillpointManager.PhysicalStrengthDescription;

        txtPlayerName.text = "Godwin the Brave";
        txtPotionCount.text = itemManager.PotionCount.ToString();
    }

    private void Update()
    {
        // Stats
        txtSkillPoints.text = skillpointManager.Skillpoints.ToString() + "/" + skillpointManager.MaxSkillpoints;
        txtVitality.text = skillpointManager.Vitality.ToString();
        txtEndurance.text = skillpointManager.Endurance.ToString();
        txtStrength.text = skillpointManager.Strength.ToString();
        txtPhysicalStrength.text = skillpointManager.PhysicalStrength.ToString();

        // Attributes
        txtHealth.text = attributeManager.Health.ToString();
        txtStamina.text = attributeManager.Stamina.ToString();
        txtStaminaReg.text = attributeManager.StaminaReg.ToString();
        txtCarryingCapacity.text = attributeManager.CarryingCapacity.ToString();
        txtResistance.text = attributeManager.Resistance.ToString();
        txtDefense.text = attributeManager.Defense.ToString();
        txtAttackPower.text = attributeManager.AttackPower.ToString();

        // Equipment
        if(itemManager.CurrentArmor != null )
        {
            armorWeight = itemManager.CurrentArmor.GetArmorWeight();
        }

        if (itemManager.CurrentWeapon != null)
        {
            weaponWeight = itemManager.CurrentWeapon.GetWeaponWeight();
        }

        weight = armorWeight + weaponWeight;
        txtCarryingCapacityEquipment.text = weight.ToString() + "/" + attributeManager.CarryingCapacity;

        if (weight <= attributeManager.CarryingCapacity && itemManager.CurrentArmor != null && itemManager.CurrentWeapon != null)
        {
            btnStartRun.interactable = true;
            txtCarryingCapacityEquipment.color = Color.white;
        }
        else if (weight > attributeManager.CarryingCapacity)
        {
            btnStartRun.interactable = false;
            txtCarryingCapacityEquipment.color = Color.red;
        }
        else
        {
            txtCarryingCapacityEquipment.color = Color.white;
        }
    }

    //--------------------------BUTTON METHODS-----------------------

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    //--------------------------SET EQUIPMENT METHODS-----------------------

    public void SetShortSwordImage()
    {
        imgEquippedWeapon.sprite = btnShortSword.image.sprite;
        imgEquippedWeapon.color = Color.white;
        imgEquippedWeapon.gameObject.GetComponent<SimpleTooltip>().InfoLeft = itemManager.ShortSwordDescription;
    }

    public void SetLongSwordImage()
    {
        imgEquippedWeapon.sprite = btnLongSword.image.sprite;
        imgEquippedWeapon.color = Color.white;
        imgEquippedWeapon.gameObject.GetComponent<SimpleTooltip>().InfoLeft = itemManager.LongSwordDescription;
    }

    public void SetHammerImage()
    {
        imgEquippedWeapon.sprite = btnHammer.image.sprite;
        imgEquippedWeapon.color = Color.white;
        imgEquippedWeapon.gameObject.GetComponent<SimpleTooltip>().InfoLeft = itemManager.HammerDescription;
    }

    public void SetDaggerImage()
    {
        imgEquippedWeapon.sprite = btnDagger.image.sprite;
        imgEquippedWeapon.color = Color.white;
        imgEquippedWeapon.gameObject.GetComponent<SimpleTooltip>().InfoLeft = itemManager.DaggerDescription;
    }

    public void SetLanceImage()
    {
        imgEquippedWeapon.sprite = btnLance.image.sprite;
        imgEquippedWeapon.color = Color.white;
        imgEquippedWeapon.gameObject.GetComponent<SimpleTooltip>().InfoLeft = itemManager.LanceDescription;
    }

    public void SetClothArmorImage()
    {
        imgEquippedArmor.sprite = btnClothArmor.image.sprite;
        imgEquippedArmor.color = Color.white;
        imgEquippedArmor.gameObject.GetComponent<SimpleTooltip>().InfoLeft = itemManager.ClothArmorDescription;
    }

    public void SetLeatherArmorImage()
    {
        imgEquippedArmor.sprite = btnLeatherArmor.image.sprite;
        imgEquippedArmor.color = Color.white;
        imgEquippedArmor.gameObject.GetComponent<SimpleTooltip>().InfoLeft = itemManager.LeatherArmorDescription;
    }

    public void SetIronArmorImage()
    {
        imgEquippedArmor.sprite = btnIronArmor.image.sprite; 
        imgEquippedArmor.color = Color.white;
        imgEquippedArmor.gameObject.GetComponent<SimpleTooltip>().InfoLeft = itemManager.IronArmorDescription;
    }

    public void SetPlateArmorImage()
    {
        imgEquippedArmor.sprite = btnPlateArmor.image.sprite;
        imgEquippedArmor.color = Color.white;
        imgEquippedArmor.gameObject.GetComponent<SimpleTooltip>().InfoLeft = itemManager.PlateArmorDescription;
    }
}
