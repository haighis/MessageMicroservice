# Group Router Sample based on examples in getakka.net documentation found here: http://getakka.net/docs/working-with-actors/Routers

Includes: 

-- Console Application (GroupRouterSystem console application)

-- Data Model - common messages (DataModel class libary)

-- Actors - common actors shared between Console Applications 


Actors
- CoordinatorActor and ChildActor - Supervisor Strategry Pattern that write to the console. In a real system
we would write to a database or send an email.

Features

- Clustering
- Hocon configuration from app.config