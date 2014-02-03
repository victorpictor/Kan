using System.Collections.Generic;
using Core.Board.Collections;
using Messages.Collection.Events;
using Messages.Exception;
using Messages.Identities;
using Messages.Markers;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios.Aggregate.IWantToAdd
{
    [TestFixture]
    public class AndTheCollectionIsFull: Specification
    {
        private MyCollection collection;
        private CollectionState collectionState;
        private CollectionIdentity id;
        private UserStoryIdentity usId;

        protected override void Given()
        {
            id = new CollectionIdentity(1);
            usId = new UserStoryIdentity(3);

            collectionState = new CollectionState(new List<IEvent>(){new CollectionCreated(1,"To Do", 1), new UserStoryAdded(2)});
            collection = new MyCollection(collectionState);
        }

       
        [Test]
        [ExpectedException(typeof(ExceedingCollectionLimitException), ExpectedMessage = "")]
        public void ItShouldThrowDomainExceedingCollectionLimitException()
        {
            collection.Add(usId);
        }
    }
}