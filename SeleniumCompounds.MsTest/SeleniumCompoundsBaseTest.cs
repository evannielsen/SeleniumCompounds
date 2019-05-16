using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace SeleniumCompounds.MsTest
{
    [TestClass]
    public class SeleniumCompoundsBaseTest
    {
        [Obsolete("Override the Initialize method instead of using [TestInitialize]", true)]
        public class TestInitializeAttribue : Attribute
        { }

        [Obsolete("User AddCleanupAction method instead of using [TestCleanup]", true)]
        public class TestCleanupAttribute : Attribute
        { }

        private readonly List<Action> cleanupActions = new List<Action>();

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitialize]
        public void TestInitialize()
        {
            cleanupActions.Clear();

            try
            {
                Initialize();
            }
            catch (Exception)
            {
                CallCleanupActions();
                throw;
            }
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanup]
        public void TestCleanup()
        {
            CallCleanupActions();
        }

        /// <summary>
        /// Add an action that will run at the end of the test regardless of the result.
        /// </summary>
        /// <param name="cleanupAction"></param>
        public void AddCleanupAction(Action cleanupAction)
        {
            cleanupActions.Add(cleanupAction);
        }

        protected virtual void Initialize() { }

        private void CallCleanupActions()
        {
            cleanupActions.Reverse();
            var exceptions = new List<Exception>();

            foreach (var action in cleanupActions)
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                    throw;
                }

                if (exceptions.Count == 0)
                {
                    return;
                }

                if (exceptions.Count == 1)
                {
                    ExceptionDispatchInfo.Throw(exceptions.Single());
                }

                throw new AggregateException("Multiple exceptions occured in Cleanup. See test log for more details.", exceptions);
            }
        }
    }
}
