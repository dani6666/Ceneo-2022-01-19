using Moq;
using NUnit.Framework;

namespace GearBox.Mocks
{
  [TestFixture]
  public class _Test
  {
    // Mock initialize
    // Mock<IEngineMonitoringSystem> _engineMonitoringSystemStub = new Mock<IEngineMonitoringSystem>();

    // Stub
    // _engineMonitoringSystemStub.Setup(f => f.GetCurrentRPM()).Returns(RpmType.LOW);

    // Mock - verify section
    // _automaticGearBoxMock.Verify(f => f.ChangeGear(1), Times.Once);
    [Test]
    public void t1()
    {
      AutomaticTransmissionController atc = new AutomaticTransmissionController(null, null);
      atc.HandleGas(AccelerationType.NormalAcceleration);
    }

    [Test]
    public void t2()
    {
      AutomaticTransmissionController atc = new AutomaticTransmissionController(null, null);
      atc.HandleGas(AccelerationType.RappidAcceleration);
    }
  }
}