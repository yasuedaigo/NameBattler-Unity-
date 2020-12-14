using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MakeParty
{
    public class PlayerToggleScript : MonoBehaviour
    {
        MakePartyViewManager MakePartyViewManager;

        void Start()
        {
            MakePartyViewManager =
                GameObject.Find("Content").GetComponent<MakePartyViewManager>();
        }

        public void controllStartButton()
        {
            MakePartyViewManager.changeStartButtonText();
            MakePartyViewManager.controllStartButtonActive();
        }
    }
}
