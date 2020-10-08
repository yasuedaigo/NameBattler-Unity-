using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using BattleScene.Chara;
using BattleScene;

namespace BattleScene.Tactics
{

public class BattleSceneManager : MonoBehaviour
{
   public GameObject parentobject;
   public GameObject battleobject;
   public GameObject tacticsobject;
   public GameObject nextturnbutton;
   public GameObject resultbutton;

   public ITactics choicetactics;

   void Start(){
      
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

}

}