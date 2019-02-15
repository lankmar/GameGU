
namespace ShooterGame
{
    public sealed class Rifle : Weapon
    {
        public void Start()
        {
            Clip.CountAmmunition = 40;
        }

        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            if (Ammunition)
            {
                InvokeRepeating(nameof(AutomaticTurn),0.02f,0);
                Invoke(nameof(ReadyShoot), _rechergeTime);

            }
        }

        public void AutomaticTurn()
        {
            var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);// Pool object
            temAmmunition.AddForce(_barrel.forward * _force);
            Clip.CountAmmunition--;
            if(Clip.CountAmmunition%3 == 0)
            {
            _isReady = false;
            Invoke(nameof(ReadyShoot), _rechergeTime);
                CancelInvoke(nameof(AutomaticTurn));
            }
        }

    }
}