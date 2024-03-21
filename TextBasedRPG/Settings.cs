namespace TextBasedRPG
{
    internal static class Settings
    {
        // player settings
        public static int PlayerInitialHealth = 10;
        public static int PlayerInitialX = 10;
        public static int PlayerInitialY = 10;

        // enemy settings
        public static int NormalEnemyInitialHealth = 2;
        public static int ScaredEnemyInitialHealth = 2;
        public static int RandomEnemyInitialHealth = 1;

        // item settings
        public static int SwordDamageBonus = 1;
        public static int HealingPotionHealAmount = 3;
        public static int ShieldBonus = -1;

        // map settings
        public static char WallCharacter = '#';

        // avatar settings
        public static char PlayerAvatar = '@';
        public static char NormalEnemyAvatar = '$';
        public static char ScaredEnemyAvatar = 'S';
        public static char RandomEnemyAvatar = '%';
        public static char SwordAvatar = '/';
        public static char ShieldAvatar = 'O';
        public static char HealingPotionAvatar = '+';

    }
}
