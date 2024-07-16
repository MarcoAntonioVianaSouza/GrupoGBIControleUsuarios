#FROM mcr.microsoft.com/dotnet/sdk:6.0  AS build
#WORKDIR /app
#
#COPY *.csproj ./
#RUN dotnet restore GrupoGBIControleUsuarios.Infra.IoC.csproj
#
#COPY . ./
#RUN dotnet publish GrupoGBIControleUsuarios.Infra.IoC.csproj -c Release -o out
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
#
#WORKDIR /app
#
#COPY --from=build /app/out .
#
#ENTRYPOINT ["dotnet", "GrupoGBIControleUsuarios.Infra.IoC.dll"]

FROM mcr.microsoft.com/dotnet/sdk:6.0  AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore 

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "GrupoGBIControleUsuarios.Infra.IoC.dll"]