﻿using Harmony12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Litfal;

namespace SmartWear
{

    [HarmonyPatch(typeof(SkillBattleSystem), "ShowSkillBattleWindow")]
    public class SkillBattleSystem_ShowSkillBattleWindow_Patch
    {
        public static void Prefix()
        {
            if (!Main.Enabled) return;
            if (Main.settings.StartSkillBattleEquipGroupIndex >= 0)
            {
                if (Main.settings.EnabledLog)
                {
                    Main.Logger.Log($"Switching equipment: {Main.settings.StartSkillBattleEquipGroupIndex}");
                }
                ControlHelper.ChangeEquipGroup(Main.settings.StartSkillBattleEquipGroupIndex);
            }
        }

    }


    [HarmonyPatch(typeof(StartBattle), "ShowStartBattleWindow")]
    public class StartBattle_ShowStartBattleWindow_Patch
    {
        public static void Prefix()
        {
            if (!Main.Enabled) return;
            if (Main.settings.StartBattleGongFaIndex >= 0)
            {
                if (Main.settings.EnabledLog)
                {
                    Main.Logger.Log($"Switching method: {Main.settings.StartBattleGongFaIndex}");
                }
                ControlHelper.ChangeGongFa(Main.settings.StartBattleGongFaIndex);
            }
            if (Main.settings.StartBattleEquipGroupIndex >= 0)
            {
                if (Main.settings.EnabledLog)
                {
                    Main.Logger.Log($"Switching equipment: {Main.settings.StartBattleEquipGroupIndex}");
                }
                ControlHelper.ChangeEquipGroup(Main.settings.StartBattleEquipGroupIndex);
            }
        }
    }
}
