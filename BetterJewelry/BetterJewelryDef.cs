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
using LBoL.Base.Extensions;

namespace BetterJewelry
{
    [OverwriteVanilla]
    public sealed class ArtificialJewelleryDefinition : CardTemplate
    {
        public override IdContainer GetId()
        {
            return nameof(LBoL.EntityLib.Cards.Other.Adventure.ArtificialJewellery);
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
              Id: "ArtificialJewellery",
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
              Rarity: Rarity.Rare,
              Type: CardType.Skill,
              TargetType: TargetType.Self,
              Colors: new List<ManaColor>() { },
              IsXCost: false,
              Cost: new ManaGroup() { Any = 1 },
              UpgradedCost: null,
              MoneyCost: null,
              Damage: null,
              UpgradedDamage: null,
              Block: null,
              UpgradedBlock: null,
              Shield: null,
              UpgradedShield: null,
              Value1: null,
              UpgradedValue1: null,
              Value2: null,
              UpgradedValue2: null,
              Mana: new ManaGroup() { Philosophy = 2 },
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
              UpgradedKeywords: Keyword.None,
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

        [EntityLogic(typeof(ArtificialJewelleryDefinition))]
        [UsedImplicitly]
        public sealed class ArtificialJewellery : Card
        {
            protected override IEnumerable<BattleAction> Actions(UnitSelector selector, ManaGroup consumingMana, Interaction precondition)
            {
                if (this.IsUpgraded)
                {
                    yield return new GainManaAction(base.Mana);
                }
                else
                {
                    ManaGroup value = ManaGroup.Single(ManaColors.Colors.Sample(base.GameRun.BattleRng));
                    yield return new GainManaAction(value);
                    value = ManaGroup.Single(ManaColors.Colors.Sample(base.GameRun.BattleRng));
                    yield return new GainManaAction(value);
                }
                yield break;

            }
        }
    }


}
