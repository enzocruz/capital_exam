using Moq;
using Api.IRepo;
using Api.Models;
using Api.Servcies;
using Api.Repo;

namespace Test
{
    public class Tests
    {
        private Mock<IUserRepo> mck;
        private UserService service;
        [SetUp]
        public void Setup()
        {
            mck = new Mock<IUserRepo>();
            service = new UserService(mck.Object);

        }
        private List<Users> userResult = new List<Users>()
        {
            new Users ()  {
                followers= 21691,
                name= "Chris Wanstrath",
                login= "defunkt",
                company= null,
                public_repos= 107
                },
                new Users(){
                    followers= 543,
                    name= "Ezra Zygmuntowicz",
                    login="ezmobius",
                    company= "Stuffstr PBC",
                    public_repos= 22

                },

                new Users(){
                    followers= 8248,
                    name="PJ Hyett",
                    login= "pjhyett",
                    company="GitHub, Inc.",
                    public_repos= 8,

                },
                new Users(){
                    followers=23528,
                    name="Tom Preston-Werner",
                    login="mojombo",
                    company="@chatterbugapp, @redwoodjs, @preston-werner-ventures ",
                    public_repos= 65,

                },
                new Users()
                {
                    followers= 10145,
                    name="Yehuda Katz",
                    login="wycats",
                    company= "@tildeio ",
                    public_repos= 278,
                 }
            };
        List<string> usernames = new List<string>()
            {
                "mojombo",
                "defunkt",
                "pjhyett",
                "wycats",
                "ezmobius"
            };
        [Test]
        public void TestMocked()
        {
            mck.Setup(f => f.GetUsersByUserNames(usernames)).Returns(userResult);//setup mocked
            var result = service.GetUsersByUsernames(usernames);
            Assert.AreEqual(userResult.Count(), result.Count());
        }
        [Test]
        public void TestActuallApi()
        {
            var service = new UserService(new UserRepository());
            var ac = service.GetUsersByUsernames(usernames);
            Assert.AreEqual(ac.Count(), userResult.Count());//check if it's the same count
        }
        [Test]
        public void Test_ISNameOrdered()
        {
            var service = new UserService(new UserRepository());
            var ac = service.GetUsersByUsernames(usernames).ToArray();
            int i = 0;

            foreach (var user in userResult.OrderBy(f => f.name))
            {
                Users actualUser = ac[i];
                Assert.AreEqual(user.name, actualUser.name);
                i++;
            }
        }

    }



}

