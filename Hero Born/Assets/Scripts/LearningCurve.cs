using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    public bool PureOfHeart = true;
    public bool HasSecretIncantation = false;
    public string RareItem = "Necronomicon";
    public int CurrentAge = 30;
    public int AddedAge = 1;
    public float Pi = 3.14f;
    public string FirstName = "Jeremiah";
    public bool IsAuthor = true;
    public int CurrentGold = 32;
    public bool hasDungeonKey = false;
    public string weaponType = "Sword Cane";
    string CharacterAction = "Attack";
    int DiceRoll = 7;
    int PlayerLives = 3;
    public Transform CamTransform;
    public GameObject DirectionLight;
    public Transform LightTransform;

    int[] topPlayerScores = { 713, 549, 984 };


    //  Start is called before the first frame update
    void Start()
    {
        if (!hasDungeonKey)
        {
            Debug.Log("You may not enter without the sacred key.");
        }
        if (weaponType != "Longsword")
        {
            Debug.Log("You don't appear to have the right type of weapon...");
        }

        int CharacterLevel = 32;
        int NextSkillLevel = GenerateCharacter("Spike", CharacterLevel);
        Debug.Log(NextSkillLevel);
        Debug.Log(GenerateCharacter("Faye", CharacterLevel));
        Thievery();

        OpenTreasureChamber();
        PrintCharacterAction();
        RollDice();

        List<string> QuestPartyMembers = new List<string>() { "Grim the Barbarian", "Merlin the Wise", "Sterling the Knight"};
        for (int i = 0; i < QuestPartyMembers.Count; i++)
        {
            Debug.LogFormat("Index: {0} - {1}", i, QuestPartyMembers[i]);
        }
        QuestPartyMembers.Add("Craven the Necromancer");
        QuestPartyMembers.Insert(1, "Tanis the Thief");
        QuestPartyMembers.RemoveAt(0);

        foreach (string partyMember in QuestPartyMembers)
        {
            Debug.LogFormat("{0} - Here!", partyMember);
        }

        Debug.LogFormat("Party Members: {0}", QuestPartyMembers.Count);

        Dictionary<string, int> ItemInventory = new Dictionary<string, int>()
    {
        { "Potion", 5 },
        { "Antidote", 7 },
        { "Aspirin", 1 }
    };
        int numberOfPotions = ItemInventory["Potion"];
        ItemInventory["Potion"] = 10;
        ItemInventory.Add("Throwing Knife", 3);
        ItemInventory["Bandage"] = 5;

        if (ItemInventory.ContainsKey("Aspirin"))
        {
            ItemInventory["Aspirin"] = 3;
        }

        Debug.LogFormat("Items: {0}", ItemInventory.Count);

        foreach (KeyValuePair<string, int> kvp in ItemInventory)
        {
            Debug.LogFormat("Item: {0} - {1}g", kvp.Key, kvp.Value);
        }

        HealthStatus();

        Character hero = new Character();
        Debug.LogFormat("Hero: {0} - {1} EXP", hero.name, hero.exp);
        hero.PrintStatsInfo();

        Character heroine = new Character("Agatha");
        Debug.LogFormat("Hero: {0} - {1} EXP", heroine.name, heroine.exp);       
        heroine.PrintStatsInfo();

        Weapon huntingBow = new Weapon("Hunting Bow", 105);
        Weapon warBow = huntingBow;
        warBow.name = "War Bow";
        warBow.damage = 155;
        huntingBow.PrintWeaponStats();
        warBow.PrintWeaponStats();

        Character hero2 = hero;
        hero2.name = "Sir Krane the Brave";
        hero2.PrintStatsInfo();
        hero.PrintStatsInfo();

        Paladin knight = new Paladin("Sigmund", huntingBow);
        knight.PrintStatsInfo();

        CamTransform = this.GetComponent<Transform>();
        Debug.Log(CamTransform.localPosition);

        //DirectionLight = GameObject.Find("Directional Light");
        LightTransform = DirectionLight.GetComponent<Transform>();
        Debug.Log(LightTransform.localPosition);

    }
    /// <summary>
    /// 
    /// </summary>
    public int GenerateCharacter(string name, int level)
    {
        Debug.LogFormat("Character: {0} – Level: {1}", name, level);
        return level += 5;
    }
    /// <summary>
    /// 
    /// </summary>
    public void PrintCharacterAction()
    {
        switch (CharacterAction)
        {
            case "Heal":
                Debug.Log("Potion sent.");
                break;
            case "Attack":
                Debug.Log("To arms!");
                break;
            default:
                Debug.Log("Shields up.");
                break;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    void ComputeAge()
    {
        Debug.Log($"A string can have variables like {FirstName} inserted directly!");
        Debug.Log(CurrentAge + AddedAge);
        Debug.LogFormat("Text goes here, add {0} and {1} as variable placeholders", CurrentAge, FirstName);
    }
    /// <summary>
    /// 
    /// </summary>
    public void Thievery()
    {
        if (CurrentGold > 50)
        {
            Debug.Log("You're rolling in it!");
        }
        else if (CurrentGold < 15)
        {
            Debug.Log("Not much there to steal...");
        }
        else
        {
            Debug.Log("Looks like your purse is in the sweet spot.");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public void OpenTreasureChamber()
    {
        if (PureOfHeart && RareItem == "Necronomicon")
        {
            if (!HasSecretIncantation)
            {
                Debug.Log("You have the spirit, but not the knowledge.");
            }
            else
            {
                Debug.Log("The treasure is yours, worthy hero!");
            }
        }
        else
        {
            Debug.Log("Come back when you have what it takes.");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public void RollDice()
    {
        switch (DiceRoll)
        {
            case 7:
            case 15:
                Debug.Log("Mediocre damage, not bad.");
                break;
            case 20:
                Debug.Log("Critical hit, the creature goes down!");
                break;
            default:
                Debug.Log("You completely missed and fell on your face.");
                break;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public void HealthStatus()
    {
        while (PlayerLives > 0)
        {
            Debug.Log("Still alive!");
            PlayerLives--;
        }
        Debug.Log("Player KO'd...");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}