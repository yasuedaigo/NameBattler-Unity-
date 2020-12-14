using System.Collections;
using System.Collections.Generic;
using BattleScene;
using BattleScene.Chara;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BattleScene.Tactics
{
    public class BattleSceneManager : MonoBehaviour
    {
        public GameObject parentobject;

        public GameObject battleobject;

        public GameObject tacticsobject;

        public GameObject nextturnbutton;

        public GameObject logpanel;

        public GameObject wintext;

        public GameObject losetext;

        public GameObject tacticsbutton;

        public GameObject resultobject;

        public GameObject nextbuttlebutton;

        public GameObject rechallengebutton;

        public GameObject scenefinishbutton;

        public ITactics choicetactics;

        void Start()
        {
        }

        public void MainBattleTactics()
        {
            battleobject.SetActive(false);
            tacticsobject.SetActive(true);
        }

        public void TacticsMainBattle()
        {
            battleobject.SetActive(true);
            tacticsobject.SetActive(false);
        }

        public void LoadWinScene()
        {
            wintext.SetActive(true);
            logpanel.SetActive(false);
            nextturnbutton.SetActive(false);
            tacticsbutton.SetActive(false);
            resultobject.SetActive(true);
        }

        public void LoadLoseScene()
        {
            losetext.SetActive(true);
            logpanel.SetActive(false);
            nextturnbutton.SetActive(false);
            tacticsbutton.SetActive(false);
            resultobject.SetActive(true);
        }

        public void pushrechallenge()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void pushfinish()
        {
            SceneManager.LoadScene("Title");
        }

        public void pushnextbattle()
        {
            SceneManager.LoadScene("MakeParty");
        }

        public void sceneBack()
        {
            SceneManager.LoadScene("BattleStart");
        }
    }
}
