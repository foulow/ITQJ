# Information Technology Quick Jobs (ITQJ)
Projecto para la construcción de una aplicación de búsqueda de empleo y contratación de profesionales del área de tecnología.

## Pre-requisitos
Siga las instruciones de instalación segun el sistema operativo que utilize para los siguientes herramientas de desarrollo.

  [Windows compatible con .Net core 3.1](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=netcore31)
  
  [.Net core 3.1 LTS (SDK y Runtime)](https://dotnet.microsoft.com/download/dotnet-core/3.1)
  
  [SQL Server 2019 (Developer o Express)](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

  [Una cuenta en Auth0](https://auth0.com/) **opcional/no-opcional**
( si quieres poner tu propio IdP o el que se encuentra en los appconfig.json del proyecto ya no esta disponible)
## Instrucciones para la compilación del proyecto
En la carpeta raiz del proyecto.
  Abra el terminal de su sistema operativo y ejecute el siguiente comando: 

```
  dotnet tool install --global dotnet-ef
  dotnet build
```

Si la compilación del proyecto se realizar sin ningun problema eso quiere decir que todo salio bien, y puede seguir las instrucciones.
en caso de econtrar un error puede compueve que la instalación de los pre-requisitos esten vien realizados y si el problema persiste, puede reportar el bug y
trataremos de resolberlo lo mas pronto posible.

## Configuraciones previas.
A continuacion ejecute los siguientes comandos para poder completar con la configuraciones previa a la ejecución del proyecto.

```
  cd ~/Source/ITQJ.API
  dotnet ef database update
```

## Instrucciones para la ejecución del proyecto
Partiendo desde lo previamente hecho, podemos ejecutar los siguientes comandos.

```
  cd ../..
  dotnet run --project ~/Source/ITQJ.API
```

En otro terminal (la misma carpeta raiz del proyecto)
```
  dotnet run --project ~/Source/ITQJ.WebClient
```

Si todo sale bien, ya puedes habrir el navegador de tu preferencia y visitar la siguiente ruta:

```
  http://localhost:44348
```
