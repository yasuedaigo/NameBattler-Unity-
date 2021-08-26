using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AllChara;
using MakeChara;
using SQLManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MakeCharaResult
{
    public class MakeCharaResultController : MonoBehaviour
    {
        MakeCharaResultViewManager makeCharaResultViewManager;
        IRepository repo;

        public void Start()
        {
            makeCharaResultViewManager = this.GetComponent<MakeCharaResultViewManager>();
            repo = new CharacterRepository();
        }

        public bool charaNumberIsFull()
        {
            return repo.charaNumberIsFull();
        }

        public bool canNotAddName(string useName)
        {
            return repo.canNotAddName(useName);
        }

        public void addmyTeamChara(PlayerDTO playerDTO)
        {
            repo.addmyTeamChara (playerDTO);
        }

        public int getMaxCharaNumber()
        {
            return repo.getMaxCharaNumber();
        }
    }
}
