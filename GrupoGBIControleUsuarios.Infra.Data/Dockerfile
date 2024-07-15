#FROM mcr.microsoft.com/dotnet/sdk:6.0  AS build
#WORKDIR /app
#
#COPY *.csproj ./
#RUN dotnet restore GrupoGBIControleUsuarios.Infra.Data.csproj
#
#COPY . ./
#RUN dotnet publish GrupoGBIControleUsuarios.Infra.Data.csproj -c Release -o out
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
#
#WORKDIR /app
#
#COPY --from=build /app/out .
#
#ENTRYPOINT ["dotnet", "GrupoGBIControleUsuarios.Infra.Data.dll"]
#
#