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

        public void loadTacticsScene()
        {
            battleobject.SetActive(false);
            tacticsobject.SetActive(true);
        }

        public void loadMainBattleScene()
        {
            battleobject.SetActive(true);
            tacticsobject.SetActive(false);
        }

        public void loadWinScene()
        {
            wintext.SetActive(true);
            logpanel.SetActive(false);
            nextturnbutton.SetActive(false);
            tacticsbutton.SetActive(false);
            resultobject.SetActive(true);
        }

        public void loadLoseScene()
        {
            losetext.SetActive(true);
            logpanel.SetActive(false);
            nextturnbutton.SetActive(false);
            tacticsbutton.SetActive(false);
            resultobject.SetActive(true);
        }

        public void reLoadActiveScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void onLoadTitle()
        {
            SceneManager.LoadScene("Title");
        }

        public void onLoadMakeParty()
        {
            SceneManager.LoadScene("MakeParty");
        }

        public void onLoadBattleStart()
        {
            SceneManager.LoadScene("BattleStart");
        }
    }
}
