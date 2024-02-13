#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/aspnetcore:2.0-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1803 AS build
WORKDIR /src
COPY ["Lil.Costumers/Lil.Costumers.csproj", "Lil.Costumers/"]
RUN dotnet restore "Lil.Costumers/Lil.Costumers.csproj"
COPY . .
WORKDIR "/src/Lil.Costumers"
RUN dotnet build "Lil.Costumers.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Lil.Costumers.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Lil.Costumers.dll"]