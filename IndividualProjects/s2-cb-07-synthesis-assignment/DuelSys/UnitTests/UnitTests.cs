using LogicLayer;
using LogicLayer.CustomExceptions;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        TestData test = new TestData();
        Mock<IMatchService> mockMatchAdmin = new Mock<IMatchService>();
        Mock<ITournamentService> mockTournament = new Mock<ITournamentService>();
        Mock<IUserService> mockUser = new Mock<IUserService>();

        [TestMethod]
        public void GenerateMatchesDoubleRoundRobin_Works()
        {
            //arrange
            Tournament t = test.GetTournamentWithUsers();
            int usersCount = t.Users.Count;
            int expectedMatchesGeneratedDoubleRoundRobin = usersCount * (usersCount - 1);
            GenerateMatchesDoubleRoundRobin generateMatchesDoubleRoundRobin = new GenerateMatchesDoubleRoundRobin();
            //act
            var generatematches = generateMatchesDoubleRoundRobin.GenerateMatches(t);
            //assert
            Assert.AreEqual(expectedMatchesGeneratedDoubleRoundRobin, generatematches.Count);

        }

        [TestMethod]
        public void GenerateMatchesRoundRobin_Works()
        {
            //arrange
            Tournament t = test.GetTournamentWithUsers();
            int usersCount = t.Users.Count;
            int expectedMatchesGeneratedRoundRobin = usersCount * (usersCount - 1) / 2;
            GenerateMatchesRoundRobin generateMatchesRoundRobin = new GenerateMatchesRoundRobin();

            //act 
            var GenerateMatches = generateMatchesRoundRobin.GenerateMatches(t);

            //assert
            Assert.AreEqual(expectedMatchesGeneratedRoundRobin, GenerateMatches.Count);
        }
        [TestMethod]
        public void BadmintonRules_Works()
        {
            //arrange
            MatchResult matchResult = new MatchResult(0, 21, 11);
            BadmintonRules badmintonRules = new BadmintonRules();
            //act
            var validate = badmintonRules.ValidateRules(matchResult);
            //assert
            Assert.IsTrue(validate);
        }

        [TestMethod]
        public void BadmintonRulesInvalidGapToScore_NotValid()
        {
            //arrange
            MatchResult matchResult = new MatchResult(0, 21, 25);
            BadmintonRules badmintonRules = new BadmintonRules();

            //act
            var execption = Assert.ThrowsException<InvalidMatchResultInputException>(() => badmintonRules.ValidateRules(matchResult));
            
            //assert
            Assert.AreEqual("Match score is not correct", execption.Message);

        }

        [TestMethod]
        public void BadmintonRulesNegativeScore_NotValid()
        {
            //arrange
            MatchResult matchResult = new MatchResult(0, -1, 21);
            BadmintonRules badmintonRules = new BadmintonRules();

            //act
            var execption = Assert.ThrowsException<InvalidMatchResultInputException>(() => badmintonRules.ValidateRules(matchResult));

            //assert
            Assert.AreEqual("Match score is not correct", execption.Message);

        }

        [TestMethod]
        public void AddTournament_Works()
        {
            //Arrange
            var tournamentAdmin = new TournamentAdmin(mockTournament.Object, mockMatchAdmin.Object);
            Tournament tournament = test.GetTournament();
            //setsup a value for the mocked method
            mockTournament.Setup(x => x.AddTournament(tournament));
            //Act
            var AddTournament = tournamentAdmin.AddTournament(tournament);
            //Assert
            Assert.IsTrue(AddTournament);
        }

        [TestMethod]
        public void CreateMD5_Works()
        {
            //Arrange
            string input = "test";
            string expectedoutput = "098F6BCD4621D373CADE4E832627B4F6";

            //Act
            var CreateMD5 = UserHelper.CreateMD5(input);

            //Assert
            Assert.AreEqual(expectedoutput, CreateMD5);
        }

        [TestMethod]
        public void ValidateEmailReturnsTrue_Works()
        {
            //Arrange
            string email = "lucas.jacobs@gmail.com";
            //Act
            var validate = UserHelper.ValidateEmail(email);
            //Assert
            Assert.IsTrue(validate);
        }
        [TestMethod]
        public void ValidateEmailReturnsFalseEndsWithDot_Works()
        {
            //Arrange
            string email = "lucas@gmail.";
            //Act
            var validate = UserHelper.ValidateEmail(email);
            //Assert
            Assert.IsFalse(validate);
        }

        [TestMethod]
        public void ValidateEmailWrongInput_Works()
        {
            //Arrange
            string email = "test";

            //Act
            var validate = UserHelper.ValidateEmail(email);

            //Assert
            Assert.IsFalse(validate);
        }

        [TestMethod]
        public void RegisterForTournament_Works()
        {
            //Arrange
            Tournament t = test.GetTournamentForRegisterPersonWorks();
            List<User> users = test.GetSampleUsers();
            User RegiserUser = new User(10, "John", "Doe", "john.doe@gmail.com", "Test", 0);
            mockTournament.Setup(x => x.RegisterForTournament(t.Id, RegiserUser.Id));
            mockTournament.Setup(x => x.GetTournamentById(t.Id)).Returns(t);
            mockTournament.Setup(x => x.GetAllUsersOfTournament(t.Id)).Returns(users);
            TournamentAdmin tournamentAdmin = new TournamentAdmin(mockTournament.Object, mockMatchAdmin.Object);

            //Act
            var register = tournamentAdmin.RegisterForTournament(RegiserUser.Id, t.Id);
            //Assert
            Assert.IsTrue(register);
        }
        [TestMethod]
        public void RegisterForTournament_NotWorks()
        {
            //Arrange
            Tournament t = test.GetTournamentForRegisterPersonNotWorksDate();
            List<User> users = test.GetSampleUsers();
            User RegiserUser = new User(10, "John", "Doe", "john.doe@gmail.com", "Test", 0);
            mockTournament.Setup(x => x.RegisterForTournament(t.Id, RegiserUser.Id));
            mockTournament.Setup(x => x.GetTournamentById(t.Id)).Returns(t);
            mockTournament.Setup(x => x.GetAllUsersOfTournament(t.Id)).Returns(users);
            TournamentAdmin tournamentAdmin = new TournamentAdmin(mockTournament.Object, mockMatchAdmin.Object);

            //Act
            var register = Assert.ThrowsException<InvalidRegistrationTournamentInput>(() => tournamentAdmin.RegisterForTournament(RegiserUser.Id, t.Id));
            
            //Assert
            Assert.AreEqual("You can not sign up. minimum is 7 days before the startdate.", register.Message);
        }
        [TestMethod]
        public void RegisterForTournamentIsFull_NotWorks()
        {
            //Arrange
            Tournament t = test.GetTournamentForRegisterPersonNotWorksMaximumPlayers();
            List<User> users = test.GetSampleUsers();
            User RegiserUser = new User(10, "John", "Doe", "john.doe@gmail.com", "Test", 0);
            mockTournament.Setup(x => x.RegisterForTournament(t.Id, RegiserUser.Id));
            mockTournament.Setup(x => x.GetTournamentById(t.Id)).Returns(t);
            mockTournament.Setup(x => x.GetAllUsersOfTournament(t.Id)).Returns(users);
            TournamentAdmin tournamentAdmin = new TournamentAdmin(mockTournament.Object, mockMatchAdmin.Object);

            //Act
            var register = Assert.ThrowsException<InvalidRegistrationTournamentInput>(() => tournamentAdmin.RegisterForTournament(RegiserUser.Id, t.Id));
            
            //Assert
            Assert.AreEqual("The tournament is already full.", register.Message);

        }
        [TestMethod]
        public void SearchTournamentsByLocation_Works()
        {
            mockTournament.Setup(x => x.GetAllTournaments()).Returns(test.GetSampleTournaments());
            string search = "Eind";
            TournamentAdmin tournamentAdmin = new TournamentAdmin(mockTournament.Object, mockMatchAdmin.Object);

            var searchByLocation = tournamentAdmin.SearchTournamentsByLocation(search);

            Assert.IsNotNull(searchByLocation);
        }
        [TestMethod]
        public void MakeLeaderboard_Works()
        {
            //arrange
            List<Leaderboard> ExpecteddLeaderboard = test.ExpectedLeaderboardResult();
            mockTournament.Setup(x => x.GetTournamentById(0)).Returns(test.GetTournamentForLeaderboard());
            mockTournament.Setup(x => x.GetAllUsersOfTournament(0)).Returns(test.GetUsersForLeaderboard());
            mockMatchAdmin.Setup(x => x.GetRegisteredMatchesOfTournament(0)).Returns(test.GetTournamentMatchesForLeaderboard());
            mockMatchAdmin.Setup(x => x.GetUnRegisteredMatchesOfTournament(0)).Returns(test.GetTournamentMatchesUnregistered());
            TournamentAdmin tournamentAdmin = new TournamentAdmin(mockTournament.Object, mockMatchAdmin.Object);
            //act
            var leaderboard = tournamentAdmin.MakeLeaderboard(0);
            //assert
            for (int i = 0; i < ExpecteddLeaderboard.Count; i++)
            {
                Assert.AreEqual(ExpecteddLeaderboard[i].User.FirstName, leaderboard[i].User.FirstName);
            }
        }

        [TestMethod]
        public void AddUserWrongFirstName_Works()
        {
            //arrange
            User testUser = test.GetUserToAddWrongFirstName();
            mockUser.Setup(x => x.CheckEmailExists(testUser.Email)).Returns(false);
            mockUser.Setup(x => x.AddUser(testUser));
            UserAdmin userAdmin = new UserAdmin(mockUser.Object);

            //act
            var exection = Assert.ThrowsException<InvalidUserInputException>(() =>  userAdmin.AddUser(testUser));

            //assert
            Assert.AreEqual("First name must be between 2 and 30 characters", exection.Message);
        }
    }
}
