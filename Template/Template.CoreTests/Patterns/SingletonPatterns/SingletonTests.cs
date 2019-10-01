using NUnit.Framework;
using Template.Core.Patterns.SingletonPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Patterns.SingletonPatterns.Tests
{
    [TestFixture()]
    public class SingletonTests
    {

        [Test()]
        public void Singleton_DefaultIsNull()
        {
            var model = Singleton.Get<SingletonModel>("test");

            Assert.That(model, Is.Null);


        }
        [Test()]
        public void Singleton_Set()
        {
            var model = new SingletonModel();
            model.KeyName = "AAA";
            Singleton.Set<SingletonModel>("test", model);

            var tempModel = Singleton.Singletons.SingleOrDefault(o => o.KeyName == "test");
            Assert.That(tempModel, Is.Not.Null);
        }
        [Test()]
        public void Singleton_MultipleUse()
        {
            var model = new SingletonModel();
            model.KeyName = "AAA";
            Singleton.Set<SingletonModel>("test", model);
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    var taskModel = Singleton.Get<SingletonModel>("test");
                    taskModel.KeyName = i.ToString();
                });
            }
            var assertModel = Singleton.Get<SingletonModel>("test");
            Assert.AreEqual("10", assertModel.KeyName);
        }


    }
}