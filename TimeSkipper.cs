using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using MelonLoader;
using Timeskipper;
using Main = TimeSkipper.Main;

[assembly: MelonInfo(typeof(Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace TimeSkipper
{
    public class Main : BloonsTD6Mod
    {
        public override void OnTowerSelected(Tower tower)
        {
            if (tower.towerModel.baseId == ModContent.TowerID<TimeSkipperTower>())
            {
                SkipperUI.CreatePanel();
            }
        }
            
        public override void OnTowerDeselected(Tower tower)
        {
            if (tower.towerModel.baseId == ModContent.TowerID<TimeSkipperTower>())
            {
                if (SkipperUI._instance != null)
                {
                    SkipperUI._instance.Close();
                }
            }
        }
    }
}
public class Skip : ModTowerSet
{
    public override string DisplayName => "Skip";
    public override bool AllowInRestrictedModes => true;
    public override int GetTowerSetIndex(System.Collections.Generic.List<TowerSet> towerSets) => towerSets.IndexOf(TowerSet.Support) + 1;
}
public class TimeSkipperTower : ModTower<Skip>
{
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 0;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;
    public override string Description => "Ever tired of waiting for round to pass? just skip them!";
    public override string Icon => "Icon";
    public override string DisplayName => "Time Skipper";
    public override string Portrait => "Icon";
    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        {
            towerModel.ApplyDisplay<TimeSkipperArt>();
            towerModel.range = 0;
            towerModel.footprint = Game.instance.model.GetTowerFromId("DartMonkey").footprint;
            towerModel.dontDisplayUpgrades = true;
            towerModel.RemoveBehavior<AttackModel>();
        }
    }
    public override int ShopTowerCount => 1;
}


public class TimeSkipperArt : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;
    public override Il2CppAssets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 0, 100);
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "2DDisplay");
        node.transform.GetChild(0).transform.localScale *= 0.7f;
    }
}
