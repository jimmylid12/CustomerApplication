# CustomerApplication

Setup [Development Mode]

Follow these steps to get your development environment setup with live API's:

Clone the repository
Go to the CustomerApplication directory.
At root directory, restore required packages by running:
dotnet restore
Next, to create the solution you need to  run:
dotnet build
The within the CustomerApplication directory, launch the project by running:
dotnet run
If you want to  run and build the API's, SQL server and and test it with the CustomerApplication App for whatever reason you can use docker-compose

Setup Production Mode
Go to the CustomerApplication directory.
Edit the docker-compose.yml file by unchecking which API you would like to run.
At the root directory, restore required packages by running:
docker-compose up --build
Check that  the containers are up an running:
docker ps -a
Check the docker-compose file for the ports that are being shown. Then go to http://localhost:5100
Setup [Docker Compose]

Go to the Startup.cs file.
Add an ! to the _env.IsDevelopment to force it to run in production mode: (example)
if (!_env.IsDevelopment())
At the root directory, restore required packages by running:
dotnet restore
Next, build the solution by running:
dotnet build
Finally, within the CustomerApplication directory, launch the project by running:
dotnet run
