using Photon.Pun;
using UnityEngine;

namespace MarsFPSKit
{
    namespace ZombieWaveSurvival
    {
        [CreateAssetMenu(menuName = "MarsFPSKit/Addons/Zombie Wave Survival/Drops/Instant Kill")]
        /// <summary>
        /// Instantly kills all zombies that are alive right now
        /// </summary>
        public class Kit_PvE_ZombieWaveSurvival_DropInstantKill : Kit_PvE_ZombieWaveSurvival_DropBase
        {
            public override void DropPickedUp(Kit_IngameMain main, int id)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    //Sound
                    base.DropPickedUp(main, id);

                    //Find all zombies
                    Kit_PvE_ZombieWaveSurvival_ZombieAI[] zombies = FindObjectsOfType<Kit_PvE_ZombieWaveSurvival_ZombieAI>();

                    for (int i = 0; i < zombies.Length; i++)
                    {
                        //Kill all of them
                        zombies[i].InstaKill();
                    }
                }
            }
        }
    }
}