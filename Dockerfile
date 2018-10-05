FROM microsoft/aspnetcore-build AS builder
WORKDIR /src

# Copy .sln and .csproj files and restore as distinct layers
COPY *.sln .
COPY Visma.SecureCoding.DataAccess/*.csproj ./Visma.SecureCoding.DataAccess/
COPY Visma.SecureCoding.Domain/*.csproj ./Visma.SecureCoding.Domain/
COPY Visma.SecureCoding.Infrastructure/*.csproj ./Visma.SecureCoding.Infrastructure/
COPY Visma.SecureCoding.Logic/*.csproj ./Visma.SecureCoding.Logic/
COPY Visma.SecureCoding.Web/*.csproj ./Visma.SecureCoding.Web/
RUN dotnet restore

# Copy everything else and build app
COPY Visma.SecureCoding.DataAccess/. ./Visma.SecureCoding.DataAccess/
COPY Visma.SecureCoding.Domain/. ./Visma.SecureCoding.Domain/
COPY Visma.SecureCoding.Infrastructure/. ./Visma.SecureCoding.Infrastructure/
COPY Visma.SecureCoding.Logic/. ./Visma.SecureCoding.Logic/
COPY Visma.SecureCoding.Web/. ./Visma.SecureCoding.Web/
WORKDIR /src/Visma.SecureCoding.Web
RUN dotnet publish -c Release -o out

FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=builder /src/Visma.SecureCoding.Web/out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "Visma.SecureCoding.Web.dll"]