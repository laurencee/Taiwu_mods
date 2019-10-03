using Harmony12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityModManagerNet;

namespace CharacterFloatInfo
{
    public class SpecialSocial
    {
        public string GetStr()
        {
            return "test successful";
        }
        List<string> socialWords = new List<string> { };

        public string GetActorName(int id, bool realName = false, bool baseName = false)
        {
            return DateFile.instance.GetActorName(id, realName, baseName);
        }

        //人物在组织中等级ID
        public static int GetGangLevelId(int id)
        {
            int num2 = int.Parse(DateFile.instance.GetActorDate(id, 19, false));
            int num3 = int.Parse(DateFile.instance.GetActorDate(id, 20, false));
            int gangValueId = DateFile.instance.GetGangValueId(num2, num3);
            return gangValueId;
        }

        //获取父母所在组织等级
        public string GetParentGangLevel(int actorId)
        {
            return "alive";
        }
        //获取父母存活情况
        public string GetParentAlive(int actorId)
        {
            List<int> list = new List<int>(DateFile.instance.GetActorSocial(actorId, 303, true, false));//包含已过世
            List<int> list2 = new List<int>(DateFile.instance.GetActorSocial(actorId, 303, false, false));
            int count = list.Count;
            int count2 = list2.Count;
            switch (count)
            {
                case 0:
                    return "no parents";
                    //break;
                case 1:
                    return "father unknown";
                    //break;
                case 2:
                    switch (count2)
                    {
                        case 0:
                            return "both parents dead";
                            //break;
                        case 1:
                            return "Single parent";
                            //break;
                        case 2:
                            return "both parents alive";
                            //break;
                    }
                    break;
                case 3:
                    return "parents remarried";
                    //break;
            }
            return "";
        }


        //TODO.添加数列，将关系描述放入，并设置对应颜色品级

        //分析父母情况
        public string AnalyzeParent(int actorId)
        {
            //string text = "";
            List<int> list = new List<int>(DateFile.instance.GetActorSocial(actorId, 303, true, false));
            int count = list.Count;

            //text += getParentAlive(actorId);
            socialWords.Add(GetParentAlive(actorId));

            for (int i = 0; i < count; i++)
            {
                int nid = list[i];
                int gangLv = GetGangLevelId(nid);
                if (gangLv % 10 <= 3)
                {
                    socialWords.Add("Children of high ranks");
                    break;
                }
            }
            return string.Join(", ", socialWords.ToArray());
        }


        public void TestAll(int actorId)
        {
            DateFile df = DateFile.instance;
            //DateFile.instance.GetActorSocial(id, 310, false, false).Count
            Main.Logger.Log("---------------------------------------------------");
            for (int i = 0; i < 12; i++)
            {
                int typ = 301 + i;
                if (true)
                {
                    if (df.HaveLifeDate(actorId, typ))
                    {
                        List<int> list = new List<int>(df.GetActorSocial(actorId, typ, true, false));
                        for (int j = 0; j < list.Count; j++)
                        {
                            int aId = list[j];
                            Main.Logger.Log(string.Format("ShowAcotrSocial:Index:{0},Key:{1},Value:{2},Name:{3}", typ, j, aId, this.GetActorName(aId)));
                        }
                    }
                }
            }
        }

        //301莫逆之交 302兄弟姐妹 303亲生父母 304义父义母 305授业恩师 306两情相悦
        //307恩深意重 308义结金兰 309配偶 310子嗣 312倾心爱慕 少311，推测为嫡系传人
        public string AnalyzeSocial(int actorId)
        {
            //DateFile df = DateFile.instance;
            //DateFile.instance.GetActorSocial(id, 310, false, false).Count
            Main.Logger.Log("---------------------------------------------------");
            return this.AnalyzeParent(actorId);
        }
    }
}