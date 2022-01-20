
using NSubstitute;
using NUnit.Framework;

namespace GearBox.Mocks
{
    [TestFixture]
    public class AutomaticTransmissionControllerTest
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
        [TestCase(RpmType.HIGH, AccelerationType.RappidAcceleration, 1)]
        [TestCase(RpmType.HIGH, AccelerationType.RappidAcceleration, 3)]
        [TestCase(RpmType.HIGH, AccelerationType.NormalAcceleration, 1)]
        [TestCase(RpmType.HIGH, AccelerationType.NormalAcceleration, 3)]
        [TestCase(RpmType.NORMAL, AccelerationType.NormalAcceleration, 3)]
        [TestCase(RpmType.NORMAL, AccelerationType.NormalAcceleration, 4)]
        public void HandleGas_Should_Change_GearUp(RpmType rpmType, AccelerationType accelerationType, int currentGear)
        {
            _engineMonitoringSystem.GetCurrentRPM().ReturnsForAnyArgs(rpmType);
            _automaticGearBox.GetGear().ReturnsForAnyArgs(currentGear);
            AutomaticTransmissionController atc = new AutomaticTransmissionController(_automaticGearBox, _engineMonitoringSystem);

            atc.HandleGas(accelerationType);
            _automaticGearBox.Received(1).ChangeGear(currentGear + 1);
        }

        [Test]
        [TestCase(RpmType.LOW, AccelerationType.NormalAcceleration, 1)]
        [TestCase(RpmType.LOW, AccelerationType.NormalAcceleration, 3)]
        [TestCase(RpmType.NORMAL, AccelerationType.RappidAcceleration, 3)]
        [TestCase(RpmType.NORMAL, AccelerationType.RappidAcceleration, 4)]
        public void HandleGas_ShouldNot_ChangeGear(RpmType rpmType, AccelerationType accelerationType, int currentGear)
        {
            _engineMonitoringSystem.GetCurrentRPM().ReturnsForAnyArgs(rpmType);
            _automaticGearBox.GetGear().ReturnsForAnyArgs(currentGear);
            AutomaticTransmissionController atc = new AutomaticTransmissionController(_automaticGearBox, _engineMonitoringSystem);

            atc.HandleGas(accelerationType);

            _automaticGearBox.DidNotReceiveWithAnyArgs().ChangeGear(default);
        }

        [Test]
        [TestCase(RpmType.LOW, AccelerationType.RappidAcceleration, 2)]
        [TestCase(RpmType.LOW, AccelerationType.RappidAcceleration, 3)]
        public void HandleGas_Should_Change_GearDown(RpmType rpmType, AccelerationType accelerationType, int currentGear)
        {
            _engineMonitoringSystem.GetCurrentRPM().ReturnsForAnyArgs(rpmType);
            _automaticGearBox.GetGear().ReturnsForAnyArgs(currentGear);
            AutomaticTransmissionController atc = new AutomaticTransmissionController(_automaticGearBox, _engineMonitoringSystem);

            atc.HandleGas(accelerationType);

            _automaticGearBox.Received(1).ChangeGear(currentGear - 1);
        }
    }
}