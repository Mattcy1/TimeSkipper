using BTD_Mod_Helper;
using Timeskipper;
using MelonLoader;

using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using UnityEngine;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using System.Collections.Generic;
using static MelonLoader.MelonLogger;
using static UnityEngine.UIElements.StylePropertyAnimationSystem;
using Il2CppAssets.Scripts.Models.Towers;

[assembly: MelonInfo(typeof(TimeSkipper1.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace TimeSkipper1
{
    public class Main : BloonsTD6Mod
    {
        public override void OnAbilityCast(Ability ability)
        {
            if (ability.abilityModel.name.Contains("SkipMinus1"))
            {
                int roundToSkipTo = InGame.instance.bridge.GetCurrentRound() - 1;
                InGame.instance.bridge.SetRound(roundToSkipTo);
                InGame.instance.bridge.StartRound();
            }
            if (ability.abilityModel.name.Contains("Skip1"))
            {
                int round = 1;
                for (int i = 0; i < round; i++)
                {
                    InGame.instance.bridge.SetRound(InGame.instance.bridge.GetCurrentRound() + 1);
                    //InGame.instance.bridge.StartRound();
                }
                InGame.instance.bridge.StartRound();
            }
            if (ability.abilityModel.name.Contains("Skip10"))
            {
                int round = 9;
                for (int i = 0; i < round; i++)
                {
                    InGame.instance.bridge.SetRound(InGame.instance.bridge.GetCurrentRound() + 1);
                    //InGame.instance.bridge.StartRound();
                }
                InGame.instance.bridge.StartRound();
            }
            if (ability.abilityModel.name.Contains("Skip100"))
            {
                int round = 90;
                for (int i = 0; i < round; i++)
                {
                    InGame.instance.bridge.SetRound(InGame.instance.bridge.GetCurrentRound() + 1);
                    //InGame.instance.bridge.StartRound();
                }
                InGame.instance.bridge.StartRound();
            }
            if (ability.abilityModel.name.Contains("SkipCustom"))
            {
                Il2CppSystem.Action<int> wantedRound = (Il2CppSystem.Action<int>)delegate (int Value)
                {
                    if (Value > 0)
                    {
                        InGame.instance.bridge.SetRound(Value - 1);
                        InGame.instance.bridge.StartRound();
                    }
                };

                PopupScreen.instance.ShowSetValuePopup("Round",
                    "What would you like to set the round to?", wantedRound, 3);
            }
        }
    }
}

