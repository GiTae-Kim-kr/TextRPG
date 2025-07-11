

class Player
{
    string PlayerName = "000";
    int PlayerLevel = 1;  //초기 레벨1
    string PlayerJob = "무전직자";
    float AttackPower = 10.0f;  //총 공격력 초기값
    float ProtectPower = 5.0f;  //총 방어력 초기값
    int PlayerHealthGage = 100;  //초기 체력 100
    int PlayerCurrentHealth = 100; // 현재 체력
    int Money = 1500;      //초기 골드 1500

    float BaseAttackP = 10.0f;   // 기본 공격력
    float BaseProtectP = 5.0f; // 기본 방어력

    public Player(int playerLevel, string playerJob, float attackPower, float protectedPower, int playerHealthGage, int money)
    {
        PlayerLevel = playerLevel;
        PlayerJob = playerJob;
        AttackPower = attackPower;
        ProtectPower = protectedPower;
        PlayerHealthGage = playerHealthGage;
        Money = money;
    }

    // 프로퍼티
    public string PName { get { return PlayerName; } set { PlayerName = value; } }
    public int PLevel { get { return PlayerLevel; } set { PlayerLevel = value; } }
    public string PJob { get { return PlayerJob; } set { PlayerJob = value; } } // 플레이어 직업 읽고 값 넣을 수 있게.
    public float AttackP { get { return AttackPower; } set { AttackPower = value; } }
    public float ProtectP { get { return ProtectPower; } set { ProtectPower = value; } }
    public int PHealthG { get { return PlayerHealthGage; } set { PlayerHealthGage = value; } }
    public int PHealthC { get { return PlayerCurrentHealth; } set { PlayerCurrentHealth = value; } }
    public int PMoney { get { return Money; } set { Money = value; } }
    public float PBaseAP { get { return BaseAttackP; } set { BaseAttackP = value; } }
    public float PBasePP { get { return BaseProtectP; } set { BaseProtectP = value; } }
}