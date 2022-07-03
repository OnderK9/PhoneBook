#Yapılması Gerekenler

1. Proje githubdan indirilir
2. Solution üzerinde "Restore Nuget Packages" çalıştırılır
3. Solution derlenir
4. RabbitMQ kurulum işlemleri yapılır [www.mshowto.org](https://www.mshowto.org/net-core-rabbitmq-kullanimi.html)
5. Veritabanı ayarlanır (MSSQL Express ile yapılmıştır.) [Microsoft](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)
6. Servis projelerinde veritabanı bağlantıları ayarlanır
7. PhoneBook.Report servisinde uygulama ayarlarında PhoneBook.Person servis adresi ayarlanır
8. RabbitMQ 'localhost' ile çalışacak şekilde ayarlanmıştır.(PhoneBook.Core.RabbitMQ.RabbitMQService.cs)
9. Servisler ve PhoneBook.BackgroundService uygulaması çalıştırılır
10. Swagger arayüzünden testler yapılabilir