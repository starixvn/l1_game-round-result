FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
WORKDIR /src

ARG DEPLOY_ENV=DEV
RUN echo $DEPLOY_ENV

COPY ./GameRoundResult/GameRoundResult.Core ./GameRoundResult.Core
COPY ./GameRoundResult/GameRoundResult.Web/GameRoundResult.Web/.csproj ./GameRoundResult.Web/.csproj

WORKDIR /src/GameRoundResult.Web/
RUN dotnet restore -v diag

COPY ./GameRoundResult/GameRoundResult.Web/ .
RUN dotnet publish -c $DEPLOY_ENV -r linux-x64 --self-contained false -o /app 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base

WORKDIR /app
COPY --from=builder /app .

ENTRYPOINT ["dotnet", "GameRoundResult.Web.dll"]