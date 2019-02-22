using System.Collections.Generic;
using UnityEngine;

namespace ShooterGame
{
    public class Respawner : BaseController
    {
        public List<Kit> GetKitList { get; } = new List<Kit>();
        public List<Mina> GetMinaList { get; } = new List<Mina>();

        #region Kit
        public void InitKit(int countKit)
        {
            for (var index = 0; index < countKit; index++)
            {
                var tempKit = Kit.Instantiate(Main.Instance.RefKitPrefab,
                    Patrol.GenericPoint(Main.Instance.Player),
                    Quaternion.identity);

                AddKitToList(tempKit);
            }
        }

        private void AddKitToList(Kit kit)
        {
            if (!GetKitList.Contains(kit))
            {
                GetKitList.Add(kit);
            }
        }
        public void RemoveKitToList(Kit kit)
        {
            if (GetKitList.Contains(kit))
            {
                GetKitList.Remove(kit);
            }
        }
        #endregion

        public void InitMina(int countMina)
        {
            for (var index = 0; index < countMina; index++)
            {
                var tempMina = Mina.Instantiate(Main.Instance.RefMinaPrefab,
                    Patrol.GenericPoint(Main.Instance.Player),
                    Quaternion.identity);

                AddMinaToList(tempMina);
            }
        }

        private void AddMinaToList(Mina mina)
        {
            if (!GetMinaList.Contains(mina))
            {
                GetMinaList.Add(mina);
            }
        }
        public void RemoveBotToList(Mina mina)
        {
            if (GetMinaList.Contains(mina))
            {
                GetMinaList.Remove(mina);
            }
        }


        public override void OnUpdate()
        {
            
        }
    }
}