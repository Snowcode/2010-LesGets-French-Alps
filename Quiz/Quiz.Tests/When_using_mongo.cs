using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Linq;
using NBehave.Spec.NUnit;
using NUnit.Framework;


namespace Quiz.Tests
{
	[ TestFixture ]
	public class When_using_mongo
	{
		[ Test ]
		public void Should_be_able_to_connect_to_the_database()
		{
			var mongoConnectionStringBuilder = new MongoConnectionStringBuilder();
			mongoConnectionStringBuilder.AddServer( "localhost" );

			var mongo = new Mongo( mongoConnectionStringBuilder.ToString() );
			mongo.Connect();
		}



		[ Test ]
		public void Should_be_able_to_store_a_document()
		{
			var mongoConnectionStringBuilder = new MongoConnectionStringBuilder();
			mongoConnectionStringBuilder.AddServer( "localhost" );

			var mongo = new Mongo( mongoConnectionStringBuilder.ToString() );
			mongo.Connect();

			var myDb = mongo.GetDatabase( "mydb" );
			myDb["things"].Delete(new Document());

			myDb[ "things" ].Insert( new Document { { "Name", "Ronnie" } } );
			myDb[ "things" ].Insert( new Document { { "Name", "Dan" } } );
			myDb[ "things" ].Insert( new Document { { "Name", "Steve" } } );
			myDb[ "things" ].Insert( new Document { { "Name", "Mike" } } );
			myDb[ "things" ].Insert( new Document { { "Name", "David" } } );

			myDb[ "things" ].Count().ShouldEqual( 5 );
		}



		[ Test ]
		public void Should_be_able_to_use_linq_to_retrieve_the_stuff()
		{
			var mongoConnectionStringBuilder = new MongoConnectionStringBuilder();
			mongoConnectionStringBuilder.AddServer( "localhost" );

			var mongo = new Mongo( mongoConnectionStringBuilder.ToString() );
			mongo.Connect();

			var myDb = mongo.GetDatabase( "mydb" );

			IMongoCollection mongoCollection = myDb[ "things" ];
			var things = from thing in mongoCollection.AsQueryable()
						 where (string)thing["Name"] != "Mike"
						 select thing;

			foreach(var person in things)
			{
				Console.WriteLine( "Name: " + person[ "Name" ] );
			}

		}
	}
}