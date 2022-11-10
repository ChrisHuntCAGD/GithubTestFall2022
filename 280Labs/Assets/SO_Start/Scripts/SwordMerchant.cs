using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordMerchant : MonoBehaviour
{
    //a reference to the text component of the name text gameObject
    [SerializeField]
    private Text swordName;

    //a reference to the Text component of the description gameObject
    [SerializeField]
    private Text description;

    //a reference to the Image component of the Sword Icon gameObject
    [SerializeField]
    private Image icon;

    //a refernce to the Text component of the Gold Cost gameObject
    [SerializeField]
    private Text goldCost;

    //a reference to the Text component of the Attack Cost gameObject
    [SerializeField]
    private Text attackCost;

    //display whateve SWordData S.O. that gets passed to us
    public void UpdateDisplayUI(SwordData swordData)
    {
        swordName.text = swordData.SwordName;
        description.text = swordData.Description;
        icon.sprite = swordData.Icon;
        goldCost.text = swordData.GoldCost.ToString();
        attackCost.text = swordData.AttackDamage.ToString();
    }
}
