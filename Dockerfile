#FROM mcr.microsoft.com/dotnet/sdk:6.0  AS build
#WORKDIR /app
#
#COPY *.csproj ./
#RUN dotnet restore GrupoGBIControleUsuarios.API.csproj
#
#COPY . ./
#RUN dotnet publish GrupoGBIControleUsuarios.API.csproj -c Release -o out
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
#
#WORKDIR /app
#
#COPY --from=build /app/out .
#
#ENTRYPOINT ["dotnet", "GrupoGBIControleUsuarios.API.dll"]

FROM mcr.microsoft.com/dotnet/sdk:6.0  AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
#COPY GrupoGBIControleUsuarios/. ./GrupoGBIControleUsuarios/
COPY GrupoGBIControleUsuarios.Domain/. ./GrupoGBIControleUsuarios.Domain/
COPY GrupoGBIControleUsuarios.Application/. ./GrupoGBIControleUsuarios.Application/
COPY GrupoGBIControleUsuarios.Infra.Data/. ./GrupoGBIControleUsuarios.Infra.Data/
COPY GrupoGBIControleUsuarios.Infra.IoC/. ./GrupoGBIControleUsuarios.Ingra.IoC/ 
COPY GrupoGBIControleUsuarios.API/. ./GrupoGBIControleUsuarios.API/ 
#
RUN dotnet restore 
#
# copy everything else and build app
#COPY GrupoGBIControleUsuarios/. ./GrupoGBIControleUsuarios/
COPY GrupoGBIControleUsuarios.Domain/. ./GrupoGBIControleUsuarios.Domain/
COPY GrupoGBIControleUsuarios.Application/. ./GrupoGBIControleUsuarios.Application/
COPY GrupoGBIControleUsuarios.Infra.Data/. ./GrupoGBIControleUsuarios.Infra.Data/
COPY GrupoGBIControleUsuarios.Infra.IoC/. ./GrupoGBIControleUsuarios.Infra.IoC/ 
COPY GrupoGBIControleUsuarios.API/. ./GrupoGBIControleUsuarios.API/ 
#
WORKDIR /app/GrupoGBIControleUsuarios
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app 
#
COPY --from=build /app/GrupoGBIControleUsuarios/out ./
ENTRYPOINT ["dotnet", "GrupoGBIControleUsuarios.API.dll"]