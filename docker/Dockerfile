FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
EXPOSE 443

ARG SOURCE_FOLDER 
COPY ${SOURCE_FOLDER} .
ENTRYPOINT ["dotnet", "Xhagua.Aks.Backend.Api.dll"]