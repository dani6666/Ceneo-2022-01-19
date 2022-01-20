using System;
using NUnit.Framework.Constraints;

namespace GearBox.Mocks
{
  public class AutomaticTransmissionController
  {
    private readonly IAutomaticGearBox _automaticGearBox;
    private readonly IEngineMonitoringSystem _engineMonitoringSystem;

    public AutomaticTransmissionController(IAutomaticGearBox automaticGearBox, IEngineMonitoringSystem engineMonitoringSystem)
    {
      _automaticGearBox = automaticGearBox;
      _engineMonitoringSystem = engineMonitoringSystem;
    }

    public void HandleGas(AccelerationType acceleration)
    {
      if (acceleration == AccelerationType.RappidAcceleration)
      {
        _automaticGearBox.ChangeGear(2);
        _automaticGearBox.GetGear();

        _engineMonitoringSystem.GetCurrentRPM();

        throw new NotImplementedException();
      }
      else
      {
        throw new NotImplementedException();
      }
    }
  }
}