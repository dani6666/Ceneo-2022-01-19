
using NSubstitute;
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
        private IAutomaticGearBox _automaticGearBox;
        private IEngineMonitoringSystem _engineMonitoringSystem;

        [SetUp]
        public void Setup()
        {
            _automaticGearBox = Substitute.For<IAutomaticGearBox>();
            _engineMonitoringSystem = Substitute.For<IEngineMonitoringSystem>();
        }
        [Test]
        public void HandleGas_Should_Change_GearUp_When_HighRPM()
        {
            int current = 1;
            _engineMonitoringSystem.GetCurrentRPM().ReturnsForAnyArgs(RpmType.HIGH);
            _automaticGearBox.GetGear().ReturnsForAnyArgs(current);
            AutomaticTransmissionController atc = new AutomaticTransmissionController(_automaticGearBox, _engineMonitoringSystem);

            atc.HandleGas(AccelerationType.RappidAcceleration);
            _automaticGearBox.Received(1).ChangeGear(current+1);
        }

        [Test]
        public void t2()
        {
            AutomaticTransmissionController atc = new AutomaticTransmissionController(null, null);
            atc.HandleGas(AccelerationType.RappidAcceleration);
        }
    }
}