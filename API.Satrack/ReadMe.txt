1. Para poder realizar el Proyecto, se instalaron los siguientes paquetes NuGet:

API.Satrack
	-Microsoft.EntityFrameworkCore.Design
Application.Satrack
	-AutoMapper
	-AutoMapper.Extensions.Microsoft.DependencyInjection
	-FluentValidation.AspNetCore
Domain.Satrack
	-Microsoft.EntityFrameworkCore.SqlServer
	-Microsoft.EntityFrameworkCore.Tools
Infrastructure.Satrack
	-System.Linq.Dynamic.Core

2. Se tienen que anexar las siguientes referencias de los proyectos:

API.Satrack
	-Application.Satrack
	-Infrastructure.Satrack
	-Utilities.Satrack
Application.Satrack
	-Domain.Satrack
	-Infrastructure.Satrack
	-Utilities.Satrack
Infrastructure.Satrack
	-Domain.Satrack
	-Utilities.Satrack

3. Para realizar el Mapeo de las Tablas de la Base de Datos en el proyecto "Domain.Satrack" se debe "Establecer como Proyecto de Inicio" y se usa el siguiente comando:
	scaffold-DbContext "server=DESKTOP-96J2VOF; Database=InterRapidisimo; Integrated Security=True; Encrypt=false" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Entities

