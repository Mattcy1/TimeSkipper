using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace TimeSkipper
{
    [RegisterTypeInIl2Cpp(false)]
    public class SkipperUI : MonoBehaviour
    {
        public static SkipperUI? _instance;
        
        public void Close()
        {
            if (gameObject)
            {
                gameObject.Destroy();
            }
        }

        public static void CreatePanel()
        {
            if (InGame.instance == null) return;
            
            RectTransform rect = InGame.instance.uiRect;
            var panel = rect.gameObject.AddModHelperPanel(new("Panel_", 0, 0, 1250, 1000), VanillaSprites.MainBGPanelBlue);
            _instance = panel.AddComponent<SkipperUI>();
            var SkipMinus1 = panel.AddImage(new("SkipMinus1_", -400, 250, 250), ModContent.GetSpriteReference<Main>("TimeSkip--1").GetGUID());
            var Skip1 = panel.AddImage(new("Skip1_", -400 + 400, 250, 250), ModContent.GetSpriteReference<Main>("TimeSkip-1").GetGUID());
            var Skip10 = panel.AddImage(new("Skip10_", -400 + 800, 250, 250), ModContent.GetSpriteReference<Main>("TimeSkip-10").GetGUID());
            var Skip100 = panel.AddImage(new("Skip1_", -400, -250, 250), ModContent.GetSpriteReference<Main>("TimeSkip-100").GetGUID());
            var Skip1000 = panel.AddImage(new("Skip1_", -400 + 400, -250, 250), ModContent.GetSpriteReference<Main>("TimeSkip-1000").GetGUID());
            var SkipCustom = panel.AddImage(new("Skip10_", -400 + 800, -250, 250), ModContent.GetSpriteReference<Main>("TimeSkip-Custom").GetGUID());
            var SkipMinus1B = panel.AddButton(new("Button_", -400, 125, 300, 150), VanillaSprites.GreenBtnLong, new System.Action(() =>
            {
                int roundToSkipTo = InGame.instance.bridge.GetCurrentRound() - 1;
                InGame.instance.bridge.SetRound(roundToSkipTo);
                InGame.instance.bridge.StartRound();
            }));
            SkipMinus1B.AddText(new("Title_", 0, 0, 300, 150), "SKIP -1", 70);
            var Skip1B = panel.AddButton(new("Button_", 0, 125, 300, 150), VanillaSprites.GreenBtnLong, new System.Action(() =>
            {
                int round = 1;
                for (int i = 0; i < round; i++)
                {
                    InGame.instance.bridge.SetRound(InGame.instance.bridge.GetCurrentRound() + 1);
                }
                InGame.instance.bridge.StartRound();
            }));
            Skip1B.AddText(new("Title_", 0, 0, 300, 150), "SKIP 1", 70);
            var Skip10B = panel.AddButton(new("Button_", 400, 125, 300, 150), VanillaSprites.GreenBtnLong, new System.Action(() =>
            {
                int round = 10;
                for (int i = 0; i < round; i++)
                {
                    InGame.instance.bridge.SetRound(InGame.instance.bridge.GetCurrentRound() + 1);
                }
                InGame.instance.bridge.StartRound();
            }));
            Skip10B.AddText(new("Title_", 0, 0, 300, 150), "SKIP 10", 70);
            var Skip100B = panel.AddButton(new("Button_", -400, -375, 300, 150), VanillaSprites.GreenBtnLong, new System.Action(() =>
            {
                int round = 100;
                for (int i = 0; i < round; i++)
                {
                    InGame.instance.bridge.SetRound(InGame.instance.bridge.GetCurrentRound() + 1);
                }
                InGame.instance.bridge.StartRound();
            }));
            Skip100B.AddText(new("Title_", 0, 0, 300, 150), "SKIP 100", 70);
            var Skip1000B = panel.AddButton(new("Button_", 0, -375, 300, 150), VanillaSprites.GreenBtnLong, new System.Action(() =>
            {
                int round = 1000;
                for (int i = 0; i < round; i++)
                {
                    InGame.instance.bridge.SetRound(InGame.instance.bridge.GetCurrentRound() + 1);
                }
                InGame.instance.bridge.StartRound();
            }));
            Skip1000B.AddText(new("Title_", 0, 0, 300, 150), "SKIP 1000", 70);
            var SkipCustomB = panel.AddButton(new("Button_", 400, -375, 300, 150), VanillaSprites.GreenBtnLong, new System.Action(() =>
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
            }));
            SkipCustomB.AddText(new("Title_", 0, 0, 300, 150), "SKIP CUSTOM", 70);
        }
    }
}
