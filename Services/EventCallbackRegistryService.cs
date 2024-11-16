using DemoFile.Game.Deadlock;

public class EventCallbackRegistryService
{
    private readonly LiveMatchEventStreamerService _eventStreamer;

    public EventCallbackRegistryService(LiveMatchEventStreamerService eventStreamer)
    {
        _eventStreamer = eventStreamer;
    }

    public void RegisterUserMessageEvents(string matchId, UserMessageEvents userMessageEvents)
    {
        SubscribeAndHandleEvent(ref userMessageEvents.Damage, nameof(userMessageEvents.Damage), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.MapPing, nameof(userMessageEvents.MapPing), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.TeamRewards, nameof(userMessageEvents.TeamRewards), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.TriggerDamageFlash, nameof(userMessageEvents.TriggerDamageFlash),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.AbilitiesChanged, nameof(userMessageEvents.AbilitiesChanged),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.RecentDamageSummary,
            nameof(userMessageEvents.RecentDamageSummary), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.SpectatorTeamChanged,
            nameof(userMessageEvents.SpectatorTeamChanged), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ChatWheel, nameof(userMessageEvents.ChatWheel), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.GoldHistory, nameof(userMessageEvents.GoldHistory), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ChatMsg, nameof(userMessageEvents.ChatMsg), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.QuickResponse, nameof(userMessageEvents.QuickResponse), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.PostMatchDetails, nameof(userMessageEvents.PostMatchDetails),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ChatEvent, nameof(userMessageEvents.ChatEvent), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.AbilityInterrupted, nameof(userMessageEvents.AbilityInterrupted),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.HeroKilled, nameof(userMessageEvents.HeroKilled), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ReturnIdol, nameof(userMessageEvents.ReturnIdol), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.SetClientCameraAngles,
            nameof(userMessageEvents.SetClientCameraAngles), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.MapLine, nameof(userMessageEvents.MapLine), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.BulletHit, nameof(userMessageEvents.BulletHit), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ObjectiveMask, nameof(userMessageEvents.ObjectiveMask), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ModifierApplied, nameof(userMessageEvents.ModifierApplied),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.CameraController, nameof(userMessageEvents.CameraController),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.AuraModifierApplied,
            nameof(userMessageEvents.AuraModifierApplied), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ObstructedShotFired,
            nameof(userMessageEvents.ObstructedShotFired), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.AbilityLateFailure, nameof(userMessageEvents.AbilityLateFailure),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.AbilityPing, nameof(userMessageEvents.AbilityPing), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.PostProcessingAnim, nameof(userMessageEvents.PostProcessingAnim),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.DeathReplayData, nameof(userMessageEvents.DeathReplayData),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.PlayerLifetimeStatInfo,
            nameof(userMessageEvents.PlayerLifetimeStatInfo), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ForceShopClosed, nameof(userMessageEvents.ForceShopClosed),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.StaminaDrained, nameof(userMessageEvents.StaminaDrained),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.AbilityNotify, nameof(userMessageEvents.AbilityNotify), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.GetDamageStatsResponse,
            nameof(userMessageEvents.GetDamageStatsResponse), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ParticipantStartSoundEvent,
            nameof(userMessageEvents.ParticipantStartSoundEvent), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ParticipantStopSoundEvent,
            nameof(userMessageEvents.ParticipantStopSoundEvent), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ParticipantStopSoundEventHash,
            nameof(userMessageEvents.ParticipantStopSoundEventHash), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ParticipantSetSoundEventParams,
            nameof(userMessageEvents.ParticipantSetSoundEventParams), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.ParticipantSetLibraryStackFields,
            nameof(userMessageEvents.ParticipantSetLibraryStackFields), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.CurrencyChanged, nameof(userMessageEvents.CurrencyChanged),
            matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.GameOver, nameof(userMessageEvents.GameOver), matchId);
        SubscribeAndHandleEvent(ref userMessageEvents.BossKilled, nameof(userMessageEvents.BossKilled), matchId);
    }

    public void RegisterSource1GameEvents(string matchId, Source1GameEvents source1Events)
    {
        SubscribeAndHandleEvent(ref source1Events.ServerSpawn, nameof(source1Events.ServerSpawn), matchId);
        SubscribeAndHandleEvent(ref source1Events.ServerPreShutdown, nameof(source1Events.ServerPreShutdown), matchId);
        SubscribeAndHandleEvent(ref source1Events.ServerShutdown, nameof(source1Events.ServerShutdown), matchId);
        SubscribeAndHandleEvent(ref source1Events.ServerMessage, nameof(source1Events.ServerMessage), matchId);
        SubscribeAndHandleEvent(ref source1Events.ServerCvar, nameof(source1Events.ServerCvar), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerActivate, nameof(source1Events.PlayerActivate), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerConnectFull, nameof(source1Events.PlayerConnectFull), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerFullUpdate, nameof(source1Events.PlayerFullUpdate), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerConnect, nameof(source1Events.PlayerConnect), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerDisconnect, nameof(source1Events.PlayerDisconnect), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerInfo, nameof(source1Events.PlayerInfo), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerSpawn, nameof(source1Events.PlayerSpawn), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerTeam, nameof(source1Events.PlayerTeam), matchId);
        SubscribeAndHandleEvent(ref source1Events.LocalPlayerTeam, nameof(source1Events.LocalPlayerTeam), matchId);
        SubscribeAndHandleEvent(ref source1Events.LocalPlayerControllerTeam,
            nameof(source1Events.LocalPlayerControllerTeam), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerChangename, nameof(source1Events.PlayerChangename), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerChat, nameof(source1Events.PlayerChat), matchId);
        SubscribeAndHandleEvent(ref source1Events.LocalPlayerPawnChanged, nameof(source1Events.LocalPlayerPawnChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.TeamplayBroadcastAudio, nameof(source1Events.TeamplayBroadcastAudio),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.FinaleStart, nameof(source1Events.FinaleStart), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerStatsUpdated, nameof(source1Events.PlayerStatsUpdated),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.UserDataDownloaded, nameof(source1Events.UserDataDownloaded),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.RagdollDissolved, nameof(source1Events.RagdollDissolved), matchId);
        SubscribeAndHandleEvent(ref source1Events.TeamInfo, nameof(source1Events.TeamInfo), matchId);
        SubscribeAndHandleEvent(ref source1Events.TeamScore, nameof(source1Events.TeamScore), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvCameraman, nameof(source1Events.HltvCameraman), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvChase, nameof(source1Events.HltvChase), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvRankCamera, nameof(source1Events.HltvRankCamera), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvRankEntity, nameof(source1Events.HltvRankEntity), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvFixed, nameof(source1Events.HltvFixed), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvMessage, nameof(source1Events.HltvMessage), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvStatus, nameof(source1Events.HltvStatus), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvTitle, nameof(source1Events.HltvTitle), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvChat, nameof(source1Events.HltvChat), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvVersioninfo, nameof(source1Events.HltvVersioninfo), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvReplay, nameof(source1Events.HltvReplay), matchId);
        SubscribeAndHandleEvent(ref source1Events.HltvReplayStatus, nameof(source1Events.HltvReplayStatus), matchId);
        SubscribeAndHandleEvent(ref source1Events.DemoStop, nameof(source1Events.DemoStop), matchId);
        SubscribeAndHandleEvent(ref source1Events.MapShutdown, nameof(source1Events.MapShutdown), matchId);
        SubscribeAndHandleEvent(ref source1Events.MapTransition, nameof(source1Events.MapTransition), matchId);
        SubscribeAndHandleEvent(ref source1Events.HostnameChanged, nameof(source1Events.HostnameChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.DifficultyChanged, nameof(source1Events.DifficultyChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.GameMessage, nameof(source1Events.GameMessage), matchId);
        SubscribeAndHandleEvent(ref source1Events.GameNewmap, nameof(source1Events.GameNewmap), matchId);
        SubscribeAndHandleEvent(ref source1Events.RoundStart, nameof(source1Events.RoundStart), matchId);
        SubscribeAndHandleEvent(ref source1Events.RoundEnd, nameof(source1Events.RoundEnd), matchId);
        SubscribeAndHandleEvent(ref source1Events.RoundStartPreEntity, nameof(source1Events.RoundStartPreEntity),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.RoundStartPostNav, nameof(source1Events.RoundStartPostNav), matchId);
        SubscribeAndHandleEvent(ref source1Events.RoundFreezeEnd, nameof(source1Events.RoundFreezeEnd), matchId);
        SubscribeAndHandleEvent(ref source1Events.TeamplayRoundStart, nameof(source1Events.TeamplayRoundStart),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerDeath, nameof(source1Events.PlayerDeath), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerFootstep, nameof(source1Events.PlayerFootstep), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerHintmessage, nameof(source1Events.PlayerHintmessage), matchId);
        SubscribeAndHandleEvent(ref source1Events.BreakBreakable, nameof(source1Events.BreakBreakable), matchId);
        SubscribeAndHandleEvent(ref source1Events.BrokenBreakable, nameof(source1Events.BrokenBreakable), matchId);
        SubscribeAndHandleEvent(ref source1Events.BreakProp, nameof(source1Events.BreakProp), matchId);
        SubscribeAndHandleEvent(ref source1Events.EntityKilled, nameof(source1Events.EntityKilled), matchId);
        SubscribeAndHandleEvent(ref source1Events.DoorClose, nameof(source1Events.DoorClose), matchId);
        SubscribeAndHandleEvent(ref source1Events.VoteStarted, nameof(source1Events.VoteStarted), matchId);
        SubscribeAndHandleEvent(ref source1Events.VoteFailed, nameof(source1Events.VoteFailed), matchId);
        SubscribeAndHandleEvent(ref source1Events.VotePassed, nameof(source1Events.VotePassed), matchId);
        SubscribeAndHandleEvent(ref source1Events.VoteChanged, nameof(source1Events.VoteChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.VoteCastYes, nameof(source1Events.VoteCastYes), matchId);
        SubscribeAndHandleEvent(ref source1Events.VoteCastNo, nameof(source1Events.VoteCastNo), matchId);
        SubscribeAndHandleEvent(ref source1Events.AchievementEvent, nameof(source1Events.AchievementEvent), matchId);
        SubscribeAndHandleEvent(ref source1Events.AchievementEarned, nameof(source1Events.AchievementEarned), matchId);
        SubscribeAndHandleEvent(ref source1Events.AchievementWriteFailed, nameof(source1Events.AchievementWriteFailed),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.BonusUpdated, nameof(source1Events.BonusUpdated), matchId);
        SubscribeAndHandleEvent(ref source1Events.SpecTargetUpdated, nameof(source1Events.SpecTargetUpdated), matchId);
        SubscribeAndHandleEvent(ref source1Events.SpecModeUpdated, nameof(source1Events.SpecModeUpdated), matchId);
        SubscribeAndHandleEvent(ref source1Events.EntityVisible, nameof(source1Events.EntityVisible), matchId);
        SubscribeAndHandleEvent(ref source1Events.GameinstructorDraw, nameof(source1Events.GameinstructorDraw),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.GameinstructorNodraw, nameof(source1Events.GameinstructorNodraw),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.FlareIgniteNpc, nameof(source1Events.FlareIgniteNpc), matchId);
        SubscribeAndHandleEvent(ref source1Events.HelicopterGrenadePuntMiss,
            nameof(source1Events.HelicopterGrenadePuntMiss), matchId);
        SubscribeAndHandleEvent(ref source1Events.PhysgunPickup, nameof(source1Events.PhysgunPickup), matchId);
        SubscribeAndHandleEvent(ref source1Events.InventoryUpdated, nameof(source1Events.InventoryUpdated), matchId);
        SubscribeAndHandleEvent(ref source1Events.CartUpdated, nameof(source1Events.CartUpdated), matchId);
        SubscribeAndHandleEvent(ref source1Events.StorePricesheetUpdated, nameof(source1Events.StorePricesheetUpdated),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.ItemSchemaInitialized, nameof(source1Events.ItemSchemaInitialized),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.DropRateModified, nameof(source1Events.DropRateModified), matchId);
        SubscribeAndHandleEvent(ref source1Events.EventTicketModified, nameof(source1Events.EventTicketModified),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.GcConnected, nameof(source1Events.GcConnected), matchId);
        SubscribeAndHandleEvent(ref source1Events.InstructorStartLesson, nameof(source1Events.InstructorStartLesson),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.InstructorCloseLesson, nameof(source1Events.InstructorCloseLesson),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.InstructorServerHintCreate,
            nameof(source1Events.InstructorServerHintCreate), matchId);
        SubscribeAndHandleEvent(ref source1Events.InstructorServerHintStop,
            nameof(source1Events.InstructorServerHintStop), matchId);
        SubscribeAndHandleEvent(ref source1Events.SetInstructorGroupEnabled,
            nameof(source1Events.SetInstructorGroupEnabled), matchId);
        SubscribeAndHandleEvent(ref source1Events.ClientsideLessonClosed, nameof(source1Events.ClientsideLessonClosed),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.DynamicShadowLightChanged,
            nameof(source1Events.DynamicShadowLightChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.GameuiActivated, nameof(source1Events.GameuiActivated), matchId);
        SubscribeAndHandleEvent(ref source1Events.GameuiHidden, nameof(source1Events.GameuiHidden), matchId);
        SubscribeAndHandleEvent(ref source1Events.GameuiFreeCursorChanged,
            nameof(source1Events.GameuiFreeCursorChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.SpectateFowViewTeamChanged,
            nameof(source1Events.SpectateFowViewTeamChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.ClientDisconnect, nameof(source1Events.ClientDisconnect), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerRespawned, nameof(source1Events.PlayerRespawned), matchId);
        SubscribeAndHandleEvent(ref source1Events.CitadelHintChanged, nameof(source1Events.CitadelHintChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.CitadeltvUnitEvent, nameof(source1Events.CitadeltvUnitEvent),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerBotReplace, nameof(source1Events.PlayerBotReplace), matchId);
        SubscribeAndHandleEvent(ref source1Events.BotPlayerReplace, nameof(source1Events.BotPlayerReplace), matchId);
        SubscribeAndHandleEvent(ref source1Events.WeaponReloadStarted, nameof(source1Events.WeaponReloadStarted),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.WeaponReloadComplete, nameof(source1Events.WeaponReloadComplete),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.WeaponZoomStarted, nameof(source1Events.WeaponZoomStarted), matchId);
        SubscribeAndHandleEvent(ref source1Events.MatchClock, nameof(source1Events.MatchClock), matchId);
        SubscribeAndHandleEvent(ref source1Events.ItemPickup, nameof(source1Events.ItemPickup), matchId);
        SubscribeAndHandleEvent(ref source1Events.GrenadeBounce, nameof(source1Events.GrenadeBounce), matchId);
        SubscribeAndHandleEvent(ref source1Events.GameStateChanged, nameof(source1Events.GameStateChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.HeroAssignedLaneChanged,
            nameof(source1Events.HeroAssignedLaneChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.HeroDraftOrderChanged, nameof(source1Events.HeroDraftOrderChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerDamageIncreased, nameof(source1Events.PlayerDamageIncreased),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerMaxhealthIncreased,
            nameof(source1Events.PlayerMaxhealthIncreased), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerAmmoIncreased, nameof(source1Events.PlayerAmmoIncreased),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerAmmoFull, nameof(source1Events.PlayerAmmoFull), matchId);
        SubscribeAndHandleEvent(ref source1Events.ClientPlayerCurrencyChange,
            nameof(source1Events.ClientPlayerCurrencyChange), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerUsedAbility, nameof(source1Events.PlayerUsedAbility), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerUsedItem, nameof(source1Events.PlayerUsedItem), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerRezIncoming, nameof(source1Events.PlayerRezIncoming), matchId);
        SubscribeAndHandleEvent(ref source1Events.NonPlayerUsedAbility, nameof(source1Events.NonPlayerUsedAbility),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.LocalPlayerUnitStatesChanged,
            nameof(source1Events.LocalPlayerUnitStatesChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerItemsChanged, nameof(source1Events.PlayerItemsChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerItemPriceChanged, nameof(source1Events.PlayerItemPriceChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerAbilityUpgradeSellPriceChanged,
            nameof(source1Events.PlayerAbilityUpgradeSellPriceChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerRespawnTimeChanged,
            nameof(source1Events.PlayerRespawnTimeChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.LocalPlayerAbilitiesVdataChanged,
            nameof(source1Events.LocalPlayerAbilitiesVdataChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.LocalPlayerWeaponsChanged,
            nameof(source1Events.LocalPlayerWeaponsChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerAbilityUpgraded, nameof(source1Events.PlayerAbilityUpgraded),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.LocalPlayerAbilityCooldownEndChanged,
            nameof(source1Events.LocalPlayerAbilityCooldownEndChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerDataAbilitiesChanged,
            nameof(source1Events.PlayerDataAbilitiesChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerAbilityBonusCounterChanged,
            nameof(source1Events.PlayerAbilityBonusCounterChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerModifiersChanged, nameof(source1Events.PlayerModifiersChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerOpenedItemShop, nameof(source1Events.PlayerOpenedItemShop),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.ToolsContentChanged, nameof(source1Events.ToolsContentChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerShopZoneChanged, nameof(source1Events.PlayerShopZoneChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerHealed, nameof(source1Events.PlayerHealed), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerHealPrevented, nameof(source1Events.PlayerHealPrevented),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerGivenShield, nameof(source1Events.PlayerGivenShield), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerWeaponSwitched, nameof(source1Events.PlayerWeaponSwitched),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerHeroChanged, nameof(source1Events.PlayerHeroChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerDraftingChanged, nameof(source1Events.PlayerDraftingChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerGuidedSandboxStarted,
            nameof(source1Events.PlayerGuidedSandboxStarted), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerLaneChallengeStarted,
            nameof(source1Events.PlayerLaneChallengeStarted), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerLaneChallengeEnded,
            nameof(source1Events.PlayerLaneChallengeEnded), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerOpenedHeroSelect, nameof(source1Events.PlayerOpenedHeroSelect),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerHeroReset, nameof(source1Events.PlayerHeroReset), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerInfoIndividualUpdated,
            nameof(source1Events.PlayerInfoIndividualUpdated), matchId);
        SubscribeAndHandleEvent(ref source1Events.PersonaUpdated, nameof(source1Events.PersonaUpdated), matchId);
        SubscribeAndHandleEvent(ref source1Events.ItemFileReloaded, nameof(source1Events.ItemFileReloaded), matchId);
        SubscribeAndHandleEvent(ref source1Events.PartyUpdated, nameof(source1Events.PartyUpdated), matchId);
        SubscribeAndHandleEvent(ref source1Events.AbilityCastSucceeded, nameof(source1Events.AbilityCastSucceeded),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.AbilityCastFailed, nameof(source1Events.AbilityCastFailed), matchId);
        SubscribeAndHandleEvent(ref source1Events.ReloadFailedNoAmmo, nameof(source1Events.ReloadFailedNoAmmo),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.BrokeEnemyShield, nameof(source1Events.BrokeEnemyShield), matchId);
        SubscribeAndHandleEvent(ref source1Events.AbilityAdded, nameof(source1Events.AbilityAdded), matchId);
        SubscribeAndHandleEvent(ref source1Events.AbilityRemoved, nameof(source1Events.AbilityRemoved), matchId);
        SubscribeAndHandleEvent(ref source1Events.AbilityLevelChanged, nameof(source1Events.AbilityLevelChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerLevelChanged, nameof(source1Events.PlayerLevelChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.CurrencyMissed, nameof(source1Events.CurrencyMissed), matchId);
        SubscribeAndHandleEvent(ref source1Events.CurrencyDenied, nameof(source1Events.CurrencyDenied), matchId);
        SubscribeAndHandleEvent(ref source1Events.CurrencyClaimedDisplay, nameof(source1Events.CurrencyClaimedDisplay),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.LocalPlayerShotHit, nameof(source1Events.LocalPlayerShotHit),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.ZiplinePlayerAttached, nameof(source1Events.ZiplinePlayerAttached),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.ZiplinePlayerDetached, nameof(source1Events.ZiplinePlayerDetached),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.ClientPlayerHeroChanged,
            nameof(source1Events.ClientPlayerHeroChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.CrateSpawn, nameof(source1Events.CrateSpawn), matchId);
        SubscribeAndHandleEvent(ref source1Events.CrateSpawnNotification, nameof(source1Events.CrateSpawnNotification),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.CitadelPauseEvent, nameof(source1Events.CitadelPauseEvent), matchId);
        SubscribeAndHandleEvent(ref source1Events.CitadelPregameTimer, nameof(source1Events.CitadelPregameTimer),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.BreakPieceSpawned, nameof(source1Events.BreakPieceSpawned), matchId);
        SubscribeAndHandleEvent(ref source1Events.SandboxPlayerMoved, nameof(source1Events.SandboxPlayerMoved),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.LaneTestStateUpdated, nameof(source1Events.LaneTestStateUpdated),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerClosedItemShop, nameof(source1Events.PlayerClosedItemShop),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.SpectateHomeTeamChanged,
            nameof(source1Events.SpectateHomeTeamChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.PlayerStatsChanged, nameof(source1Events.PlayerStatsChanged),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.TitanTransformingStart, nameof(source1Events.TitanTransformingStart),
            matchId);
        SubscribeAndHandleEvent(ref source1Events.TitanTransformingComplete,
            nameof(source1Events.TitanTransformingComplete), matchId);
        SubscribeAndHandleEvent(ref source1Events.KeybindChanged, nameof(source1Events.KeybindChanged), matchId);
        SubscribeAndHandleEvent(ref source1Events.QuickCastModeChanged, nameof(source1Events.QuickCastModeChanged),
            matchId);
    }

    public void RegisterGameEvents(string matchId, GameEvents gameEvents)
    {
        SubscribeAndHandleEvent(ref gameEvents.FireBullets, nameof(gameEvents.FireBullets), matchId);
        SubscribeAndHandleEvent(ref gameEvents.PlayerAnimEvent, nameof(gameEvents.PlayerAnimEvent), matchId);
        SubscribeAndHandleEvent(ref gameEvents.ParticleSystemManager, nameof(gameEvents.ParticleSystemManager),
            matchId);
        SubscribeAndHandleEvent(ref gameEvents.ScreenTextPretty, nameof(gameEvents.ScreenTextPretty), matchId);
        SubscribeAndHandleEvent(ref gameEvents.ServerRequestedTracer, nameof(gameEvents.ServerRequestedTracer),
            matchId);
        SubscribeAndHandleEvent(ref gameEvents.BulletImpact, nameof(gameEvents.BulletImpact), matchId);
        SubscribeAndHandleEvent(ref gameEvents.EnableSatVolumesEvent, nameof(gameEvents.EnableSatVolumesEvent),
            matchId);
        SubscribeAndHandleEvent(ref gameEvents.PlaceSatVolumeEvent, nameof(gameEvents.PlaceSatVolumeEvent), matchId);
        SubscribeAndHandleEvent(ref gameEvents.DisableSatVolumesEvent, nameof(gameEvents.DisableSatVolumesEvent),
            matchId);
        SubscribeAndHandleEvent(ref gameEvents.RemoveSatVolumeEvent, nameof(gameEvents.RemoveSatVolumeEvent), matchId);
    }

    // TODO: Make sure this is disposed of when streaming ends.
    private void SubscribeAndHandleEvent<T>(ref Action<T>? gameEvent, string eventName, string matchId)
    {
        gameEvent += e =>
        {
            _ = Task.Run(async () =>
            {
                try
                {
                    await _eventStreamer.SendEventAsync(
                        e,
                        matchId,
                        eventName,
                        eventObj =>
                        {
                            if (eventObj is Source1PlayerDeathEvent data)
                            {
                                return new
                                {
                                    // TODO: Decide on fields to capture
                                    GameEventName = data.GameEventName,
                                    Bounty = data.Bounty,
                                    Attacker = new
                                    {
                                        Name = data.Attacker?.PlayerName
                                    },
                                    Assister1 = new
                                    {
                                        Name = data.Assister1controller?.PlayerName,
                                    },
                                    Assister2 = new
                                    {
                                        Name = data.Assister2controller?.PlayerName,
                                    },
                                };
                            }

                            return eventObj;
                        });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending event '{eventName}': {ex}");
                }
            }, default);
        };
    }
}