using Content.Server.AlertLevel;
using Content.Server.Station.Systems;
using Content.Shared.Voidstation.KeycardActivator;

namespace Content.Server.Voidstation.KeycardActivator;

public sealed class KeycardActivatorSystem : EntitySystem
{
    [Dependency] private readonly AlertLevelSystem _alertLevelSystem = default!;
    [Dependency] private readonly StationSystem _stationSystem = default!;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<KeycardActivatorComponent, CodeGammaEvent>(OnCodeGammaEvent);
    }

    private void OnCodeGammaEvent(Entity<KeycardActivatorComponent> entity, ref CodeGammaEvent args)
    {
        var stationUid = _stationSystem.GetOwningStation(entity);
        if (stationUid != null)
        {
            _alertLevelSystem.SetLevel(stationUid.Value, "gamma", true, true);
        }
    }
}