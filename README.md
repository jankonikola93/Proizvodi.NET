# Proizvodi.NET
C# .NET MVC
1) Za slucaj kada su podaci u bazi koristio sam Entity Framework Code First, server je LocalDB,
   za pristup podacima u Data Access Layer (DAL) koristio sam Generic Repository Pattern i Unit Of Work
2) Za slucaj kada su podaci u json fajlu za pristup podacima koristi se DALzaJSON, Business Access Layer i Web deo
   se skoro i ne razlikuju u odnosu na to kada su podaci u bazi. 
   Json file se cuva na putanji D://proizvodi.json (putanja se moze promeniti u Web.config fajlu)
   Pretpostavio sam da u realnom primeru podaci ne bi bili u json fajlu nego bi se u formi json-a dobijali od nekog api-a
   pa sam u fajlovima IApiClient.cs i ApiClient.cs u DALzaJSON assembly napisao i kako bi izgledala implementacija
   za slucaj da se komunicira sa REST API-em (zakomentarisani delovi koda)
Greske koje se loguju cuvaju se u fajlovima na particiji D:// (parametar se moze promeniti u Web.config fajlu)
