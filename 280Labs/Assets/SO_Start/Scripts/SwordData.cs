using UnityEngine;

[CreateAssetMenu(fileName = "NewSwordData", menuName = "Sword Data", order = 51)]
public class SwordData : ScriptableObject
{
    [SerializeField]
    private string swordName;
    [SerializeField]
    private string description;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int attackDamage;
    [SerializeField]
    private int goldCost;

    public string SwordName
    {
        get { return swordName; }
    }
    public string Description
    {
        get { return description; }
    }
    public Sprite Icon
    {
        get { return icon; }
    }
    public int AttackDamage
    {
        get { return attackDamage; }
    }
    public int GoldCost
    {
        get { return goldCost; }
    }
}
