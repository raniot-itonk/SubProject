FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["SubProject/SubProject.csproj", "SubProject/"]
RUN dotnet restore "SubProject/SubProject.csproj"
COPY . .
WORKDIR "/src/SubProject"
RUN dotnet build "SubProject.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SubProject.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SubProject.dll"]