#Yap�lmas� Gerekenler

1. Proje githubdan indirilir
2. Solution �zerinde "Restore Nuget Packages" �al��t�r�l�r
3. Solution derlenir
4. RabbitMQ kurulum i�lemleri yap�l�r [www.mshowto.org](https://www.mshowto.org/net-core-rabbitmq-kullanimi.html)
5. Veritaban� ayarlan�r (MSSQL Express ile yap�lm��t�r.) [Microsoft](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)
6. Servis projelerinde veritaban� ba�lant�lar� ayarlan�r
7. PhoneBook.Report servisinde uygulama ayarlar�nda PhoneBook.Person servis adresi ayarlan�r
8. RabbitMQ 'localhost' ile �al��acak �ekilde ayarlanm��t�r.(PhoneBook.Core.RabbitMQ.RabbitMQService.cs)
9. Servisler ve PhoneBook.BackgroundService uygulamas� �al��t�r�l�r
10. Swagger aray�z�nden testler yap�labilir