00:03:17	install packages (new way by unload project then add libraries to my project file then reload dependencies)
00:08:40	add classes to domain(domain->entity->authentication->ApplicationUse.cs)
00:10:05	add my dtos to my application layer with two parts ( request Dto and response Dto)
00:20:00	add my AppDbContext (infrastructure layer) 
00:21:11	add connection string and JWT to appsettings.json ( api project in presentation layer)
00:22:10	add Dependency injection folder to add Ioc container to my infrastructure layer (in this  class i have	(AddInfrastructureService extension that			contains( AddDbContext , then addIdentity , then add authentication by Jwt bearer			schema , then add authentication services and				authorization services , then add CORS policy )
00:25:40	add my service (AddInfrastructureService ) to Ioc for api project then add migration and update database
00:27:25	add my contracts to my application layer ( )


===========================================================
			IMPORTANT NOTICES
			====================
Register Page : roles list is fill by hardcoded(must contain 1 role atleast )
				add new user ( should implement confirm email)
				must edit the code, so we don't wont to depent on Netcode hup 
				register a user need to admin acceptance 
				then the user can add other information like phone address image .
