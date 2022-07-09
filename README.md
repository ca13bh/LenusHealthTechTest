# LenusHealthTechTest
 Lenus Health Tech Test Book Store

To Run:
Written in Visual Studio 2019
You will need the latest .Net Core 3.1 SDK: https://dotnet.microsoft.com/en-us/download/dotnet/3.1
You will also need several Nuget packages but they should download automatically upon building the application.

Assumptions:
As the Readme did not state that the database needed to be persistent for this test, I have used the InMemoryDB.
So data will not persist outside of each debug session but means it is much simpler to get up and running to evaluate.

I followed the OpenAPI doc but I would like to add that I disagree with the delete endpoint response. 
In my opinion it should return a 204 No Content upon a successful delete not a 200 OK. But to follow the breif, I implemented it as a 200 OK.

If I had used a DB I would of used MySql as thats the one I know best.