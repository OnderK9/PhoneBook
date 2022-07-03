#Yapýlmasý Gerekenler

1. Proje githubdan indirilir
2. Solution üzerinde "Restore Nuget Packages" çalýþtýrýlýr
3. Solution derlenir
4. RabbitMQ kurulum iþlemleri yapýlýr [www.mshowto.org](https://www.mshowto.org/net-core-rabbitmq-kullanimi.html)
5. Veritabaný ayarlanýr (MSSQL Express ile yapýlmýþtýr.) [Microsoft](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)
6. Servis projelerinde veritabaný baðlantýlarý ayarlanýr
7. PhoneBook.Report servisinde uygulama ayarlarýnda PhoneBook.Person servis adresi ayarlanýr
8. RabbitMQ 'localhost' ile çalýþacak þekilde ayarlanmýþtýr.(PhoneBook.Core.RabbitMQ.RabbitMQService.cs)
9. Servisler ve PhoneBook.BackgroundService uygulamasý çalýþtýrýlýr
10. Swagger arayüzünden testler yapýlabilir