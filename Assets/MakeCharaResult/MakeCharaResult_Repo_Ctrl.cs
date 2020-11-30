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
    public class MakeCharaResult_Repo_Ctrl : MonoBehaviour
    {
        MakePlayerManager makePlayerManager;

        IRepository Repo;

        void Start()
        {
            makePlayerManager = this.GetComponent<MakePlayerManager>();
            Repo = new CharacterRepository();
        }

        public bool canAddCharaNumber()
        {
            return Repo.canAddCharaNumber();
        }

        public bool canAddCharaName(string usename)
        {
            return Repo.canAddCharaName(usename);
        }

        public void addmyTeamData(PlayerDTO playerDTO)
        {
            Repo.addmyTeamData (playerDTO);
        }
    }
}
