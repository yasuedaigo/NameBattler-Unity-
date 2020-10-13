using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MakeParty;

public class debugaaaa : MonoBehaviour
{
    public Text aaatext;
    // Start is called before the first frame update
    void Start()
    {
        aaatext.text = MakePartyBattleStart.playerintlist.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
