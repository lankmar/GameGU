namespace ShooterGame
{
    public interface ICharacter : IHealth
    {      
        bool isActive { get; }

        void SetActive(bool value);
        void Kill();

    }
}