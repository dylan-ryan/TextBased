namespace TextBasedRPG
{
    internal class HealthSystem
    {
        public int health;

        public HealthSystem(int health)
        {
            this.health = health;
        }
        public void TakeDamage(int hp)
        {
            health = health - hp;
        }

        public void Heal(int hp)
        {
            health += hp;
        }
    }
}
