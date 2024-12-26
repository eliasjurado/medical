# Medical

## EF Migration Ejemplos
- Auth
```sh
dotnet ef migrations add InitIdentity --startup-project ../../Presentation/Medical.UI --context UserIdentityDbContext
dotnet ef database update InitIdentity --startup-project ../../Presentation/Medical.UI --context UserIdentityDbContext
```
- App
```sh
dotnet ef migrations add AddCategoria --startup-project ../../Presentation/Medical.UI --context PersistenceDataContext
dotnet ef database update AddCategoria --startup-project ../../Presentation/Medical.UI --context PersistenceDataContext
```
