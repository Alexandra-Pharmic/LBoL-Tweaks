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

namespace BetterRabbitFoot
{
    [OverwriteVanilla]
    public sealed class RabbitFootDefinition : CardTemplate
    {
        public override IdContainer GetId()
        {
            return nameof(LBoL.EntityLib.Cards.Other.Adventure.RabbitFoot);
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
              Id: "RabbitFoot",
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
              Value1: 15,
              UpgradedValue1: 20,
              Value2: 1,
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

              Keywords: Keyword.Exile,
              UpgradedKeywords: Keyword.Exile,
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

        [EntityLogic(typeof(RabbitFootDefinition))]
        [UsedImplicitly]
        public sealed class RabbitFoot : Card
        {
            // Token: 0x060008CD RID: 2253 RVA: 0x00012C45 File Offset: 0x00010E45
            protected override IEnumerable<BattleAction> Actions(UnitSelector selector, ManaGroup consumingMana, Interaction precondition)
            {
                yield return new DrawManyCardAction(base.Value2);
                yield break;
            }

            protected override void OnEnterBattle(BattleController battle)
            {
                base.ReactBattleEvent<GameEventArgs>(base.Battle.BattleEnding, new EventSequencedReactor<GameEventArgs>(this.OnBattleEnding));
            }

            // Token: 0x060008CE RID: 2254 RVA: 0x00012C64 File Offset: 0x00010E64
            private IEnumerable<BattleAction> OnBattleEnding(GameEventArgs args)
            {
                switch (base.Zone)
                {
                    case CardZone.Draw:
                        yield return new GainMoneyAction(base.Value1, SpecialSourceType.DrawZone);
                        break;
                    case CardZone.Hand:
                        yield return new GainMoneyAction(base.Value1, SpecialSourceType.None);
                        break;
                    case CardZone.Discard:
                        yield return new GainMoneyAction(base.Value1, SpecialSourceType.DisCardZone);
                        break;
                }
                yield break;
            }

        }
    }


}