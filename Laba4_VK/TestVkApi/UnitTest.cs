using System.Collections.Generic;
using NUnit.Framework;
using Tests.Models;
using Tests.Repositories;
using Tests.Services;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        
        }

        [Test]
        public void TestGetUser()
        {
            IUsersRepository userRepository = new UsersRepository();
            UserService userService = new UserService(userRepository);
            
            User user = userService.GetUserById("194599671");
            
            Assert.AreEqual("Игорь", user.FirstName);
            Assert.AreEqual("Малахов",user.LastName);
            
        }
        
        [Test]
        public void TestGetUserMock()
        {
            IUsersRepository userRepository = new UsersRepositoryMock();
            UserService userService = new UserService(userRepository);
            User user = userService.GetUserById("194599671");
            
            Assert.AreEqual("Игорь", user.FirstName);
            Assert.AreEqual("Малахов",user.LastName);

        }
        
        [Test]
        public void TestGetGroup()
        {
            IGroupRepository groupRepository = new GroupRepository();
            GroupService groupService = new GroupService(groupRepository);
            Group group = groupService.GetById("167950306");
            
            Assert.AreEqual("Игра Обзоров", group.Name);
            Assert.AreEqual("igraobzorov", group.ScreenName);
            
        }
        [Test]
        public void TestGetGroupMock()
        {
            IGroupRepository groupRepository = new GroupRepositoryMock();
            GroupService groupService = new GroupService(groupRepository);
            Group group = groupService.GetById("167950306");
            
            Assert.AreEqual("Игра Обзоров", group.Name);
            Assert.AreEqual("igraobzorov", group.ScreenName);
            
        }
        
        [Test]
        public void TestGetListGroup()
        {
            IGroupRepository groupRepository = new GroupRepository();
            GroupService groupService = new GroupService(groupRepository);
            List<Group> groups = groupService.Get("194599671", "5");
            
            Assert.AreEqual(5,groups.Count);
            
            Assert.AreEqual("Игра Обзоров", groups[0].Name);
        }
                
        [Test]
        public void TestGetListGroupMock()
        {
            IGroupRepository groupRepository = new GroupRepositoryMock();
            GroupService groupService = new GroupService(groupRepository);
            List<Group> groups = groupService.Get("194599671", "2");

            Assert.AreEqual(2, groups.Count);

            Assert.AreEqual("Игра Обзоров", groups[0].Name);
        }
    }
}