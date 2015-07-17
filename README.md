# Message Microservice with Group Router Sample based on examples in getakka.net documentation found here: http://getakka.net/docs/working-with-actors/Routers

Includes: 

-- Console Application (GroupRouterSystem console application)

-- Console Application 2 (For testing Group Router)

-- Data Model - common messages (DataModel class libary)

-- Actors - common actors shared between Console Applications 

-- Data Access using Entity Framework

-- Business Logic Layer

-- Web Application that uses Group Router to send messages to backend cluster called GroupRouterSystem

Actors
- CoordinatorActor and ChildActor - Supervisor Strategry Pattern that write to the console. In a real system
we would write to a database or send an email.

Features

- Clustering
- Hocon configuration from app.config