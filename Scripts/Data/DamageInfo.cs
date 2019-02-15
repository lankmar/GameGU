using UnityEngine;


namespace ShooterGame
{
    public sealed class DamageInfo
    {
        public float damage { get; private set; }
        public Transform source { get; private set; }
        public ICharacter owner { get; private set; }
        public EDamageType type { get; private set; }


        
        public DamageInfo()
        {
            SetInfo(0f, null, null, EDamageType.Unknown);
        }
        
        public DamageInfo(float damage, Transform source, ICharacter owner, EDamageType type = EDamageType.Unknown)
        {
            SetInfo(damage, source, owner, type);
        }

        
        public DamageInfo GetItByInfo(float damage, Transform source, ICharacter owner, EDamageType type = EDamageType.Unknown)
        {
            SetInfo(damage, source, owner, type);
            return this;
        }

        
        public void SetInfo(float damage, Transform source, ICharacter owner, EDamageType type = EDamageType.Unknown)
        {
            this.damage = damage;
            this.source = source;
            this.owner = owner;
            this.type = type;
        }
    };
}