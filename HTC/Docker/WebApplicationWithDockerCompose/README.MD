#Подготовка к сборке:
1. создание Windows-контейнера с SQL Server (позаимствовано из репозитория https://github.com/microsoft/mssql-docker ):
   - запускаем PowerShell
   - переходим в каталог "HTC\Docker\!Environment\mssql-server-windows-developer";
   - скачиваем SQL Developer по ссылке https://go.microsoft.com/fwlink/?linkid=866662
   - запускаем скачанный файл и выбираем опцию "Скачать носитель" в папку "HTC\Docker\!Environment\mssql-server-windows-developer"
   - исполняем команду: "docker build --memory=4096m -f dockerfile_1 -t sqldeveloper .". Скорость исполнения команды может варьироваться в пределах от минуты до десятка минут
