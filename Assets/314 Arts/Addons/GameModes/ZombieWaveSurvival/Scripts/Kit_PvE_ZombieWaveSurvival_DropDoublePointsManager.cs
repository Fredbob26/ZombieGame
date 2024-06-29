using Photon.Pun;
using UnityEngine;

namespace MarsFPSKit
{
    namespace ZombieWaveSurvival
    {
        public class Kit_PvE_ZombieWaveSurvival_DropDoublePointsManager : MonoBehaviourPun, IPunObservable
        {
            /// <summary>
            /// There should only be one of these at all times
            /// </summary>
            public static Kit_PvE_ZombieWaveSurvival_DropDoublePointsManager instance;
            [HideInInspector]
            /// <summary>
            /// Until which <see cref="PhotonNetwork.Time"/> should we live?
            /// </summary>
            public double liveUntil;

            private void Start()
            {
                instance = this;

                //Set initial time
                liveUntil = PhotonNetwork.Time + (float)photonView.InstantiationData[0];
            }

            private void Update()
            {
                if (photonView.IsMine)
                {
                    if (PhotonNetwork.Time >= liveUntil)
                    {
                        PhotonNetwork.Destroy(gameObject);
                    }
                }
            }

            void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
            {
                if (stream.IsWriting)
                {
                    stream.SendNext(liveUntil);
                }
                else
                {
                    liveUntil = (double)stream.ReceiveNext();
                }
            }
        }
    }
}