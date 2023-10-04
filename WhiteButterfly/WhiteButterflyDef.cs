using LBoL.Base;
using LBoL.ConfigData;
using LBoL.Core.Cards;
using LBoL.Core.Battle.BattleActions;
using LBoL.EntityLib.EnemyUnits.Normal;
using LBoLEntitySideloader;
using LBoLEntitySideloader.Attributes;
using LBoLEntitySideloader.Entities;
using LBoLEntitySideloader.Resource;
using MonoMod.RuntimeDetour.Platforms;
using System;
using System.Collections.Generic;
using System.Text;
using LBoL.Core.Battle;
using LBoL.Core;
using LBoL.Core.StatusEffects;
using JetBrains.Annotations;

namespace WhiteButterfly
{
    [OverwriteVanilla]
    public sealed class YuyukoSingDefinition : CardTemplate
    {
        public override IdContainer GetId()
        {
            return nameof(LBoL.EntityLib.Cards.Neutral.Green.YuyukoSing);
        }

        [DontOverwrite]
        public override CardImages LoadCardImages()
        {
            return null;
        }

        public override LocalizationOption LoadLocalization()
        {
            var loc = new GlobalLocalization(BepinexPlugin.embeddedSource);
            loc.LocalizationFiles.AddLocaleFile(LBoL.Core.Locale.En, "CardsEn.yaml");
            return loc;
        }

        public override CardConfig MakeConfig()
        {
            var cardConfig = new CardConfig(
              Index: BepinexPlugin.sequenceTable.Next(typeof(CardConfig)),
              Id: "YuyukoSing",
              Order: 10,
              AutoPerform: true,
              Perform: new string[0][],
              GunName: "Simple1",
              GunNameBurst: "Simple1",
              DebugLevel: 0,
              Revealable: false,
              IsPooled: true,
              HideMesuem: false,
              IsUpgradable: true,
              Rarity: Rarity.Common,
              Type: CardType.Attack,
              TargetType: TargetType.SingleEnemy,
              Colors: new List<ManaColor>() { ManaColor.White },
              IsXCost: false,
              Cost: new ManaGroup() { Any = 2, White = 1 },
              UpgradedCost: null,
              MoneyCost: null,
              Damage: 18,
              UpgradedDamage: 24,
              Block: null,
              UpgradedBlock: null,
              Shield: null,
              UpgradedShield: null,
              Value1: null,
              UpgradedValue1: null,
              Value2: null,
              UpgradedValue2: null,
              Mana: null,
              UpgradedMana: null,
              Scry: null,
              UpgradedScry: null,
              ToolPlayableTimes: null,

              Loyalty: null,
                UpgradedLoyalty: null,
                PassiveCost: null,
                UpgradedPassiveCost: null,
                ActiveCost: null,
                UpgradedActiveCost: null,
                UltimateCost: null,
                UpgradedUltimateCost: null,

              Keywords: Keyword.None,
              UpgradedKeywords: Keyword.Accuracy,
              EmptyDescription: false,
              RelativeKeyword: Keyword.None,
              UpgradedRelativeKeyword: Keyword.None,

              RelativeEffects: new List<string>() { },
              UpgradedRelativeEffects: new List<string>() { },
              RelativeCards: new List<string>() { },
              UpgradedRelativeCards: new List<string>() { },
              Owner: null,
              Unfinished: false,
              Illustrator: null,
              SubIllustrator: new List<string>() { }
           );

            return cardConfig;
        }

        [EntityLogic(typeof(YuyukoSingDefinition))]
        [UsedImplicitly]
        public sealed class YuyukoSing : Card
        {
            // Token: 0x17000116 RID: 278
            // (get) Token: 0x06000A0E RID: 2574 RVA: 0x000145E0 File Offset: 0x000127E0
            public override bool CanUpgrade
            {
                get
                {
                    int? upgradeCounter = base.UpgradeCounter;
                    int num = 99;
                    return upgradeCounter.GetValueOrDefault() < num & upgradeCounter != null;
                }
            }

            // Token: 0x17000117 RID: 279
            // (get) Token: 0x06000A0F RID: 2575 RVA: 0x0001460C File Offset: 0x0001280C
            public override bool IsUpgraded
            {
                get
                {
                    return base.UpgradeCounter > 0;
                }
            }

            // Token: 0x06000A10 RID: 2576 RVA: 0x00014635 File Offset: 0x00012835
            public override void Initialize()
            {
                base.Initialize();
                base.UpgradeCounter = new int?(0);
            }

            // Token: 0x06000A11 RID: 2577 RVA: 0x0001464C File Offset: 0x0001284C
            public override void Upgrade()
            {
                int? upgradeCounter = base.UpgradeCounter + 1;
                base.UpgradeCounter = upgradeCounter;
                base.ProcessKeywordUpgrade();
                base.CostChangeInUpgrading();
                this.NotifyChanged();
            }

            // Token: 0x17000118 RID: 280
            // (get) Token: 0x06000A12 RID: 2578 RVA: 0x0001469C File Offset: 0x0001289C
            public override int AdditionalDamage
            {
                get
                {
                    if (!(base.UpgradeCounter > 0))
                    {
                        return 0;
                    }
                    return (base.UpgradeCounter.Value + 5) * base.UpgradeCounter.Value;
                }
            }


        }
    }


}
