using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetwotkUtility.Test.PingTest
{
    public class NetworkServiceTest
    {
        private readonly NetworkService _pingService;
        private readonly IDNS _dNS;

        public NetworkServiceTest()
        {


            _dNS = A.Fake<IDNS>();

            //SUT - system under test
            _pingService = new NetworkService(_dNS);
        }
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - varables, classes, mocks

            A.CallTo(()=>_dNS.SendDNS()).Returns(true);
            ///var pingService = new NetworkService();

            //Act - 

            var result = _pingService.SendPing();

            //Assert - 

            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Contain("Success", Exactly.Once());
            //result.Should().Be("Success: Ping Sent");
        }

        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        public void NetworkService_PingTimeout_resturnInt(int a,int b, int expected)
        {
            //Arrange

            ///var timeoutService = new NetworkService();

            //Act

            var result = _pingService.PingTimeout(a, b);

            //Assert

            result.Should().Be(expected);
            result.Should().BePositive();
        }

        [Fact]
        public void NetworkService_PingTimeout_ReturnDate()
        {
            //Arrange - varables, classes, mocks

            ///var pingService = new NetworkService();

            //Act - 

            var result = _pingService.LastPingDate();

            //Assert - 

            result.Should().HaveYear(2023);
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2050));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnObject()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1,
            };
            //Act

            var result =_pingService.GetPingOptions();

            //Assert : warning (comparing reference type)

            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnIEnuberable()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1,
            };
            //Act

            var result = _pingService.MostRecentPings();

            //Assert : warning (comparing reference type)

            result.Should().BeAssignableTo<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
            
        }
    }
}

