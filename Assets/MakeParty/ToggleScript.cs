using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MakeParty
{
    public class ToggleScript : MonoBehaviour
    {
        ContentManager contentmanager;

        void Start()
        {
            contentmanager =
                GameObject.Find("Content").GetComponent<ContentManager>();
        }

        public void makeButtonText()
        {
            contentmanager.makeButtonText();
        }
    }
}
