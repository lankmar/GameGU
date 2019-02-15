namespace ShooterGame
{
    public sealed class Pistole : Weapon
    {
        public void Start()
        {
            _rechergeTime = 0.5f;
            Clip.CountAmmunition = 7;
        }

        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            if (Ammunition)
            {
                var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);// Pool object
                temAmmunition.AddForce(_barrel.forward * _force);
                Clip.CountAmmunition--;
                _isReady = false;
                Invoke(nameof(ReadyShoot), _rechergeTime);
            }
        }
    }
}