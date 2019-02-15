namespace ShooterGame
{
    public interface IHealth
    {
        int MaxHealth { get; set; }
        int CurrentHealth { get; }

        bool Regeneration { get; set; }
        
    }
}