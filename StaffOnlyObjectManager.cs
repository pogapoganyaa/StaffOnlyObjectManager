using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace PogapogaGimmick
{
    public class StaffOnlyObjectManager : UdonSharpBehaviour
    {
        public string[] staffNames;
        public GameObject[] staffOnlyEnableObject;
        public GameObject[] staffOnlyDisableObject;

        void Start()
        {
            VRCPlayerApi playerApi = Networking.LocalPlayer;

            foreach (string name in staffNames)
            {
                // スタッフの処理
                if (playerApi.displayName == name)
                {
                    foreach (GameObject gameObject in staffOnlyEnableObject)
                    {
                        gameObject.SetActive(true);
                    }
                    foreach (GameObject gameObject in staffOnlyDisableObject)
                    {
                        gameObject.SetActive(false);
                    }
                    return;
                }
            }

            // スタッフ以外の処理
            foreach (GameObject gameObject in staffOnlyEnableObject)
            {
                gameObject.SetActive(false);
            }
            foreach (GameObject gameObject in staffOnlyDisableObject)
            {
                gameObject.SetActive(true);
            }
        }
    }
}

