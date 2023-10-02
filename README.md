# PtmkTest C# .NET 7 + Docker
Тестовое задание

**Запустить БД ``make postgres``**
**Применить миграцию ``make update-database``**

> ### Задание 1
> - Запустить либо ``make run-1`` либо перейти в ``Expect.Ptmk.Main`` и выполнить ``dotnet run 1``
> ### Задание 2
> - Запустить либо ``make run-2`` либо перейти в ``Expect.Ptmk.Main`` и выполнить ``dotnet run 2 "SeocndName FirstName MiddleName" YYYY-MM-DD [Female | Male]``
> ### Задание 3
> - Запустить либо ``make run-3`` либо перейти в ``Expect.Ptmk.Main`` и выполнить ``dotnet run 3``
> ### Задание 4
> - Запустить либо ``make run-4`` либо перейти в ``Expect.Ptmk.Main`` и выполнить ``dotnet run 4``
> ### Задание 5
> - Запустить либо ``make run-5`` либо перейти в ``Expect.Ptmk.Main`` и выполнить ``dotnet run 5``
>

#### Для оптимизации вставки 1 000 000 и 100 сущностей в бд сравнил обычную вставку из EntityFrameworkCore и получил время
> 00:01:40.3865876
#### Далее пробовал использовать BulkInsert с BatchSize = 1000 из пакета Z.EntityFramework.Extensions и получил вермя
> 00:00:35.7184647
