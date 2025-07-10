


internal class Item
{
    public char ItemRarity { get; set; }             // 아이템 희귀도
    public string ItemName { get; set; }             //아이템 이름
    public string ItemAbilityType { get; set; }      //아이템 능력 종류
    public string ItemEffectValue { get; set; }     //아이템 효과 수치
    public string ItemDescription { get; set; }     //아이템 설명


    //생성자
    public Item(char rarity, string name, string abilityType, string effectValue, string description)
    {
        ItemRarity = rarity;
        ItemName = name;
        ItemAbilityType = abilityType;
        ItemEffectValue = effectValue;
        ItemDescription = description;
    }

}