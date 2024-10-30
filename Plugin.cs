using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace PlugenName
{
    [BepInPlugin("com.David_Loves_JellyCar_Worlds.PlugenName", "PlugenName", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigFile config;
        public static ConfigEntry<bool> innerPushEnabled;
        public static ConfigEntry<bool> ShedEnabled;
        public static ConfigEntry<int> PushProity;
        public static ConfigEntry<int> EnterProity;
        public static ConfigEntry<int> EatProity;
        public static ConfigEntry<int> PossessProity;
        private void Awake()
        {
            config = Config;
            innerPushEnabled = config.Bind("Settings", "InnerPushEnabled", true, "is inner push enabled");
            ShedEnabled = config.Bind("Settings", "ShedEnabled", false, "is exsturde ennabled");
            PushProity = config.Bind("Settings", "PushProity", 1, "value 1-4. if outside of this range it removes it from the attempt order. represents the order of them in priority. if 2 proitys have the same value it doesnt work correctly ");
            EnterProity = config.Bind("Settings", "PushEnterProityProity", 2, "value 1-4. if outside of this range it removes it from the attempt order. represents the order of them in priority. if 2 proitys have the same value it doesnt work correctly");
            EatProity = config.Bind("Settings", "EatProity", 3, "value 1-4. if outside of this range it removes it from the attempt order. represents the order of them in priority. if 2 proitys have the same value it doesnt work correctly.");
            PossessProity = config.Bind("Settings", "PossessProity", 4, "value 1-4. if outside of this range it removes it from the attempt order. represents the order of them in priority. if 2 proitys have the same value it doesnt work correctly");
            Logger.LogInfo("Plugin PlugenName is loaded!");

            Harmony harmony = new Harmony("com.David_Loves_JellyCar_Worlds.PlugenName");

            Logger.LogInfo("harmany created");
            harmony.PatchAll();
            Logger.LogInfo("PlugenName Patch Compleate!");
        }


    [HarmonyPatch(typeof(LoadLevel))]
    public class myPatches
    {
        [HarmonyPatch("Load")]
        [HarmonyPrefix]
        private static bool FuncName_PlugenName_Plug(LoadLevel __instance, string data)
        {
                World.levels.Clear();
                World.blocks.Clear();
                World.floors.Clear();
                World.dummyBlock.OuterLevel = null;
                World.fastTravelFloors.Clear();
                World.playerBlocks.Clear();
                Draw.FocusBlock = null;
                Draw.MultiplePlayerFocusBlock = null;
                Draw.MultiplePlayerFocusBlockForScreenshot = null;
                Draw.infPossessableHack = false;
                Draw.receptionPerformanceHack = false;
                Draw.infExitPreviews.Clear();
                Draw.infEnterVoidBandaid = false;
                Break.floorToMove = null;
                Particle.lastFrameFocusLevel = null;
                Particle.lastFocusLevel = null;
                UndoManager.Clear();
                World.MoveCount = 0;
                World.MovedSinceLevelLoad = false;
                //proity logic
                World.attemptOrder.Clear();
                if (PushProity.Value == 1)
                {
                    World.attemptOrder.Add(World.Attempt.Push);
                }
                if (EnterProity.Value == 1)
                {
                    World.attemptOrder.Add(World.Attempt.Enter);
                }
                if (EatProity.Value == 1)
                {
                    World.attemptOrder.Add(World.Attempt.Eat);
                }
                if (PossessProity.Value == 1)
                {
                    World.attemptOrder.Add(World.Attempt.Possess);
                }
                if (PushProity.Value == 2)
                {
                    World.attemptOrder.Add(World.Attempt.Push);
                }
                if (EnterProity.Value == 2)
                {
                    World.attemptOrder.Add(World.Attempt.Enter);
                }
                if (EatProity.Value == 2)
                {
                    World.attemptOrder.Add(World.Attempt.Eat);
                }
                if (PossessProity.Value == 2)
                {
                    World.attemptOrder.Add(World.Attempt.Possess);
                }
                if (PushProity.Value == 3)
                {
                    World.attemptOrder.Add(World.Attempt.Push);
                }
                if (EnterProity.Value == 3)
                {
                    World.attemptOrder.Add(World.Attempt.Enter);
                }
                if (EatProity.Value == 3)
                {
                    World.attemptOrder.Add(World.Attempt.Eat);
                }
                if (PossessProity.Value == 3)
                {
                    World.attemptOrder.Add(World.Attempt.Possess);
                }
                if (PushProity.Value == 4)
                {
                    World.attemptOrder.Add(World.Attempt.Push);
                }
                if (EnterProity.Value == 4)
                {
                    World.attemptOrder.Add(World.Attempt.Enter);
                }
                if (EatProity.Value == 4)
                {
                    World.attemptOrder.Add(World.Attempt.Eat);
                }
                if (PossessProity.Value == 4)
                {
                    World.attemptOrder.Add(World.Attempt.Possess);
                }

                World.shedEnabled = ShedEnabled.Value;
                World.innerPushEnabled = innerPushEnabled.Value;
                World.WentToInfZone = false;
                World.ResetInspect();
                World.ResetWinState();
                World.ResetMultiplePlayersState();
                World.FirstLevelSinceStartup = false;
                Block.DebugIDCounter = 0;
                if (World.OnMobilePlatform())
                {
                    TouchControls.ClearAndReloadButtons();
                }
                TouchControls.buttons.Clear();
                TouchControls.DemoEndAnimT = 0f;
                World.unlocking = false;
                World.celebration = false;
                World.celebrationT = -1.25f;
                World.celebrationPlayedStartSound = false;
                World.celebrationLevel = null;
                World.celebrationNumLevels = 0;
                LoadLevel.header = true;
                LoadLevel.blockStack = new Stack<Block>();
                LoadLevel.levelIDs = new Dictionary<int, Level>();
                LoadLevel.refLines = new Queue<LoadLevel.RefLine>();
                LoadLevel.customLevelPalette = -1;
                World.customLevelMusic = -1;
                LoadLevel.allWon = SaveFile.AllWon(SaveFile.Current);
                Draw.DrawStyle = Draw.DS.NORMAL;
                string[] array = data.Split(new char[]
                {
            '\n'
                });
                List<string[]> list = new List<string[]>();
                foreach (string text in array)
                {
                    var text2 = text.TrimEnd(new char[]
                    {
                '\n'
                    });
                    text2 = text2.TrimEnd(new char[]
                    {
                '\r'
                    });
                    if (text2.Length <= 0 || text2[0] != '@')
                    {
                        list.Add(text2.Split(new char[]
                        {
                    ' '
                        }));
                    }
                }
                LoadLevel.SetRandomization(list);
                for (int j = 0; j < list.Count; j++)
                {
                    if (LoadLevel.ParseLine(list[j]))
                    {
                        World.GoToHub();
                        return false;
                    }
                }
                while (LoadLevel.refLines.Count > 0)
                {
                    LoadLevel.ProcessRefLine(LoadLevel.refLines.Dequeue());
                }
                World.ComputeBlockLists();
                List<Block> list2 = World.FindPlayerBlocks();
                LoadLevel.CheckDesignMistakes(list2);
                foreach (Level level in World.levels)
                {
                    LoadLevel.MaybeFillDonut(level);
                }
                LoadLevel.CreateInfExitZones();
                if (World.InHub())
                {
                    LoadLevel.DoHubModifications();
                    Hub.PositionPlayerOnHubStart(list2[0]);
                    Draw.receptionPerformanceHack = (World.FindPlayerBlock().OuterLevel.hubAreaName == "Area_Reception");
                }
                World.ComputeBlockLists();
                World.UpdateButtonsPressed();
                World.UpdateCoveringButtonSounds(false);
                Movement.DetectInfExitPreviews(list2[0]);
                Autotile.DoAutotile();
                foreach (Level level2 in World.levels)
                {
                    LoadLevel.ComputeLevelBorders(level2);
                }
                if (World.currentLevelName == "palettes")
                {
                    Draw.Palette = 0;
                    LoadLevel.ComputeBorderColors();
                }
                else if (LoadLevel.randomize)
                {
                    int num;
                    for (num = Random.Range(0, 10); num == 5; num = Random.Range(0, 10))
                    {
                    }
                    LoadLevel.ApplyPalette(num);
                }
                else if (World.currentLevelName == "custom_level")
                {
                    if (LoadLevel.customLevelPalette >= 0)
                    {
                        LoadLevel.ApplyPalette(LoadLevel.customLevelPalette);
                    }
                    else
                    {
                        Draw.Palette = 0;
                        LoadLevel.ComputeBorderColors();
                    }
                }
                else
                {
                    LoadLevel.ApplyPalette(Hub.GetScenePalette(World.currentLevelName));
                }
                Draw.HueShift = (World.currentLevelName == "hue_shift");
                Draw.hueOffsetT = 8.8f;
                Draw.UpdateHueShift();
                Particle.PreWarm();
                if (World.InHub())
                {
                    Block exitBlock = list2[0].OuterLevel.GetExitBlock();
                    if (exitBlock.OuterLevel != null)
                    {
                        Particle.lastFrameFocusLevel = exitBlock.OuterLevel;
                    }
                }
                if (!World.InHub())
                {
                    World.RecentPuzzle = World.currentLevelName;
                }
                if (World.InHub())
                {
                    World.FirstFrameInHub = true;
                }
                Draw.FlipH = false;
                Draw.ZoomOutAnimFocusBlock = World.FindPlayerBlock().OuterLevel.GetExitBlock();
                Draw.PerpetualZoomIn = (World.currentLevelName == "zoom_in_anim");
                Draw.NumZoomOuts = 0;
                Draw.UpdateCameraMode();
                if (Draw.CameraMode == Draw.CM.PerpetualZoomOut)
                {
                    Draw.PerpetualZoomOutPickNewBlock();
                }
                Draw.ZoomOutAnimT = 9f;
                if (Draw.PerpetualZoomIn)
                {
                    Draw.ZoomOutAnimT = 7f;
                }
                Draw.ResetCameraOffset();
                Draw.TitleStuck = true;
                Draw.TitleT = 0f;
                World.TookScreenshot = false;
                World.ControlsFadeT = 0f;
                if (World.currentLevelName == "possess_ii_block_v2")
                {
                    Draw.infPossessableHack = true;
                }
                World.levelJustWon = null;
                if (World.ScreenshottingBlocks)
                {
                    World.blocks.Sort((Block a, Block b) => LoadLevel.ScreenshottingBlocksCompare(a, b));
                }
                return false;
            }
        }

    }
}