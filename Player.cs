

class Player
{
    string PlayerName = "000";
    int PlayerLevel = 0;  //초기 레벨0
    string PlayerJob = "무전직자";
    int AttackPower = 10;  //초기 공격력 10
    int ProtectPower = 5;  //초기 방어력 5
    int PlayerHealthGage = 100;  //초기 체력 100
    int Money = 1500;      //초기 골드 1500

    public Player(int playerLevel, string playerJob, int attackPower, int protectedPower, int playerHealthGage, int money)
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
    public int AttackP { get { return AttackPower; } set { AttackPower = value; } }
    public int ProtectP { get { return ProtectPower; } set { ProtectPower = value; } }
    public int PHealthG { get { return PlayerHealthGage; } set { PlayerHealthGage = value; } }
    public int PMoney { get { return Money; } set { Money = value; } }
}