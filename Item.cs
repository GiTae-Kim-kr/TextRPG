


internal class Item
{
    public bool IsItemWear { get; set; }               //아이템 착용여부
    public string ItemRarity { get; set; }             // 아이템 희귀도
    public string ItemName { get; set; }             //아이템 이름
    public string ItemAbilityType { get; set; }      //아이템 능력 종류
    public string ItemEffectValue { get; set; }     //아이템 효과 수치
    public string ItemDescription { get; set; }     //아이템 설명
    public int ItemPrice { get; set; }
    public bool IsPurchased { get; set; }           // 아이템 구매 여부

    //생성자
    public Item( string rarity, string name, string abilityType, string effectValue, string description, int itemPrice)
    {
        ItemRarity = rarity;
        ItemName = name;
        ItemAbilityType = abilityType;
        ItemEffectValue = effectValue;
        ItemDescription = description;
        ItemPrice = itemPrice;
        IsPurchased = false;
    }


    //레어리티
    //언커먼 : 1~5 종합수치
    //커먼 : 6~10
    //레어 : 11~15
    //유니크 : 16~25 
}