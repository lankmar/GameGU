namespace ShooterGame
{
    public interface IDamage
    {
        bool isAlive { get; }

        bool isPlayer { get; }
        bool isNPC { get; }

    }
}