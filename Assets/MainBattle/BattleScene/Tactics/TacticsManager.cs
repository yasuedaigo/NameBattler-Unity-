using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BattleScene;
using BattleScene.Chara;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.Tactics
{
    public class TacticsManager : MonoBehaviour
    {
        public ITactics choiceTactics;

        public ToggleGroup toggleGroup;

        public Toggle attacktactics;

        public Toggle defensetactics;

        public Toggle balancetactics;

        void Start()
        {
            choiceTactics = new AttackTactics();
        }

        public void AttackTacticsToggle()
        {
            if (attacktactics.isOn) choiceTactics = new AttackTactics();
        }

        public void DefenceTacticsToggle()
        {
            if (defensetactics.isOn) choiceTactics = new DefenceTactics();
        }

        public void BalanceTacticsToggle()
        {
            if (balancetactics.isOn) choiceTactics = new BalanceTactics();
        }
    }
}
